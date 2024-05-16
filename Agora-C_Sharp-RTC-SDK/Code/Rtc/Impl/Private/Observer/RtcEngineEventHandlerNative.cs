using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
using UnityEngine;
#endif

namespace Agora.Rtc
{
    internal static class RtcEngineEventHandlerNative
    {
        private static IRtcEngineEventHandler rtcEngineEventHandler = null;

        internal static void SetEventHandler(IRtcEngineEventHandler handler)
        {
            rtcEngineEventHandler = handler;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {

            if (rtcEngineEventHandler == null)
                return;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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

            OnRtcEngineEvent(@event, jsonData);
        }

        private static void OnRtcEngineEvent(string @event, LitJson.JsonData jsonData)
        {
            switch (@event)
            {
                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGE:
                    {
                        var byteLength = (uint)AgoraJson.GetData<uint>(jsonData, "length");
                        var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "data");
                        var byteData = new byte[byteLength];
                        if (byteLength != 0)
                        {
                            Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() =>{
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOMETADATARECEIVED:
                    {
                        var metadataLength = (uint)AgoraJson.GetData<uint>(jsonData, "length");
                        var metadataPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "metadata");
                        var metadata = new byte[metadataLength];
                        if (metadataLength != 0)
                        {
                            Marshal.Copy(metadataPtr, metadata, 0, (int)metadataLength);
                        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioMetadataReceived(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        metadata,
                        metadataLength
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                #region terra IRtcEngineEventHandler
                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONPROXYCONNECTED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnProxyConnected(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (PROXY_TYPE)AgoraJson.GetData<int>(jsonData, "proxyType"),
                        (string)AgoraJson.GetData<string>(jsonData, "localProxyIp"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONERROR:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnError(
                        (int)AgoraJson.GetData<int>(jsonData, "err"),
                        (string)AgoraJson.GetData<string>(jsonData, "msg")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEPROBERESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLastmileProbeResult(
                        AgoraJson.JsonToStruct<LastmileProbeResult>(jsonData, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICESTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioDeviceStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "deviceId"),
                        (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGPOSITIONCHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioMixingPositionChanged(
                        (long)AgoraJson.GetData<long>(jsonData, "position")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGFINISHED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioMixingFinished(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOEFFECTFINISHED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioEffectFinished(
                        (int)AgoraJson.GetData<int>(jsonData, "soundId")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEODEVICESTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoDeviceStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "deviceId"),
                        (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONUPLINKNETWORKINFOUPDATED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUplinkNetworkInfoUpdated(
                        AgoraJson.JsonToStruct<UplinkNetworkInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONDOWNLINKNETWORKINFOUPDATED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnDownlinkNetworkInfoUpdated(
                        AgoraJson.JsonToStruct<DownlinkNetworkInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEQUALITY:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLastmileQuality(
                        (int)AgoraJson.GetData<int>(jsonData, "quality")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONFIRSTLOCALVIDEOFRAME:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstLocalVideoFrame(
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "source"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalVideoStateChanged(
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "source"),
                        (LOCAL_VIDEO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_VIDEO_STREAM_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAREADY:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnCameraReady(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAFOCUSAREACHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnCameraFocusAreaChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "x"),
                        (int)AgoraJson.GetData<int>(jsonData, "y"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAEXPOSUREAREACHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnCameraExposureAreaChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "x"),
                        (int)AgoraJson.GetData<int>(jsonData, "y"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONFACEPOSITIONCHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFacePositionChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "imageWidth"),
                        (int)AgoraJson.GetData<int>(jsonData, "imageHeight"),
                        AgoraJson.JsonToStructArray<Rectangle>(jsonData, "vecRectangle"),
                        AgoraJson.GetDataArrayInt(jsonData, "vecDistance"),
                        (int)AgoraJson.GetData<int>(jsonData, "numFaces")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSTOPPED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoStopped(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioMixingStateChanged(
                        (AUDIO_MIXING_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "state"),
                        (AUDIO_MIXING_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRHYTHMPLAYERSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRhythmPlayerStateChanged(
                        (RHYTHM_PLAYER_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "state"),
                        (RHYTHM_PLAYER_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCONTENTINSPECTRESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnContentInspectResult(
                        (CONTENT_INSPECT_RESULT)AgoraJson.GetData<int>(jsonData, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICEVOLUMECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioDeviceVolumeChanged(
                        (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceType"),
                        (int)AgoraJson.GetData<int>(jsonData, "volume"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRtmpStreamingStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "url"),
                        (RTMP_STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (RTMP_STREAM_PUBLISH_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGEVENT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRtmpStreamingEvent(
                        (string)AgoraJson.GetData<string>(jsonData, "url"),
                        (RTMP_STREAMING_EVENT)AgoraJson.GetData<int>(jsonData, "eventCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONTRANSCODINGUPDATED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnTranscodingUpdated(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOROUTINGCHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioRoutingChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "routing")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCHANNELMEDIARELAYSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnChannelMediaRelayStateChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "state"),
                        (int)AgoraJson.GetData<int>(jsonData, "code")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALPUBLISHFALLBACKTOAUDIOONLY:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalPublishFallbackToAudioOnly(
                        (bool)AgoraJson.GetData<bool>(jsonData, "isFallbackOrRecover")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteSubscribeFallbackToAudioOnly(
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "isFallbackOrRecover")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONPERMISSIONERROR:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnPermissionError(
                        (PERMISSION_TYPE)AgoraJson.GetData<int>(jsonData, "permissionType")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALUSERREGISTERED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalUserRegistered(
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONUSERINFOUPDATED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserInfoUpdated(
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        AgoraJson.JsonToStruct<UserInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOTRANSCODERERROR:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalVideoTranscoderError(
                        AgoraJson.JsonToStruct<TranscodingVideoStream>(jsonData, "stream"),
                        (VIDEO_TRANSCODER_ERROR)AgoraJson.GetData<int>(jsonData, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOSUBSCRIBESTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioSubscribeStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSUBSCRIBESTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoSubscribeStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOPUBLISHSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioPublishStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOPUBLISHSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONEVENT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnExtensionEvent(
                        (string)AgoraJson.GetData<string>(jsonData, "provider"),
                        (string)AgoraJson.GetData<string>(jsonData, "extension"),
                        (string)AgoraJson.GetData<string>(jsonData, "key"),
                        (string)AgoraJson.GetData<string>(jsonData, "value")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTARTED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnExtensionStarted(
                        (string)AgoraJson.GetData<string>(jsonData, "provider"),
                        (string)AgoraJson.GetData<string>(jsonData, "extension")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTOPPED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnExtensionStopped(
                        (string)AgoraJson.GetData<string>(jsonData, "provider"),
                        (string)AgoraJson.GetData<string>(jsonData, "extension")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONERROR:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnExtensionError(
                        (string)AgoraJson.GetData<string>(jsonData, "provider"),
                        (string)AgoraJson.GetData<string>(jsonData, "extension"),
                        (int)AgoraJson.GetData<int>(jsonData, "error"),
                        (string)AgoraJson.GetData<string>(jsonData, "message")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONJOINCHANNELSUCCESS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnJoinChannelSuccess(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREJOINCHANNELSUCCESS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRejoinChannelSuccess(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOQUALITY:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioQuality(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "quality"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "delay"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "lost")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOVOLUMEINDICATION:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioVolumeIndication(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStructArray<AudioVolumeInfo>(jsonData, "speakers"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "speakerNumber"),
                        (int)AgoraJson.GetData<int>(jsonData, "totalVolume")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLEAVECHANNEL:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLeaveChannel(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONRTCSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRtcStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKQUALITY:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnNetworkQuality(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "txQuality"),
                        (int)AgoraJson.GetData<int>(jsonData, "rxQuality")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONINTRAREQUESTRECEIVED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnIntraRequestReceived(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALVIDEOFRAMEPUBLISHED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstLocalVideoFramePublished(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEODECODED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstRemoteVideoDecoded(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEOSIZECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoSizeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "sourceType"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "rotation")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalVideoStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (LOCAL_VIDEO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_VIDEO_STREAM_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteVideoStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (REMOTE_VIDEO_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (REMOTE_VIDEO_STATE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEOFRAME:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstRemoteVideoFrame(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERJOINED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserJoined(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSEROFFLINE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserOffline(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (USER_OFFLINE_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEAUDIO:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserMuteAudio(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEVIDEO:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserMuteVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLEVIDEO:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserEnableVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "enabled")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLELOCALVIDEO:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserEnableLocalVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "enabled")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "state")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalAudioStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<LocalAudioStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteAudioStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RemoteAudioStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalVideoStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<LocalVideoStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteVideoStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RemoteVideoStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONLOST:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnConnectionLost(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONINTERRUPTED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnConnectionInterrupted(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONBANNED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnConnectionBanned(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGEERROR:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnStreamMessageError(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "streamId"),
                        (int)AgoraJson.GetData<int>(jsonData, "code"),
                        (int)AgoraJson.GetData<int>(jsonData, "missed"),
                        (int)AgoraJson.GetData<int>(jsonData, "cached")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREQUESTTOKEN:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRequestToken(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLICENSEVALIDATIONFAILURE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLicenseValidationFailure(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (LICENSE_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONTOKENPRIVILEGEWILLEXPIRE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnTokenPrivilegeWillExpire(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (string)AgoraJson.GetData<string>(jsonData, "token")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALAUDIOFRAMEPUBLISHED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstLocalAudioFramePublished(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIOFRAME:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstRemoteAudioFrame(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "userId"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIODECODED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstRemoteAudioDecoded(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (LOCAL_AUDIO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_AUDIO_STREAM_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (REMOTE_AUDIO_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (REMOTE_AUDIO_STATE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONACTIVESPEAKER:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnActiveSpeaker(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnClientRoleChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "oldRole"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "newRole"),
                        AgoraJson.JsonToStruct<ClientRoleOptions>(jsonData, "newRoleOptions")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGEFAILED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnClientRoleChangeFailed(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CLIENT_ROLE_CHANGE_FAILED_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "currentRole")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOTRANSPORTSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteAudioTransportStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "delay"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "lost"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "rxKBitRate")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOTRANSPORTSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteVideoTransportStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "delay"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "lost"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "rxKBitRate")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnConnectionStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCMESSAGE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnWlAccMessage(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (WLACC_MESSAGE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (WLACC_SUGGEST_ACTION)AgoraJson.GetData<int>(jsonData, "action"),
                        (string)AgoraJson.GetData<string>(jsonData, "wlAccMsg")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnWlAccStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<WlAccStats>(jsonData, "currentStats"),
                        AgoraJson.JsonToStruct<WlAccStats>(jsonData, "averageStats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKTYPECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnNetworkTypeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (NETWORK_TYPE)AgoraJson.GetData<int>(jsonData, "type")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONENCRYPTIONERROR:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnEncryptionError(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (ENCRYPTION_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "errorType")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUPLOADLOGRESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUploadLogResult(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "success"),
                        (UPLOAD_ERROR_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERACCOUNTUPDATED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserAccountUpdated(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSNAPSHOTTAKEN:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnSnapshotTaken(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (string)AgoraJson.GetData<string>(jsonData, "filePath"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "errCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEORENDERINGTRACINGRESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoRenderingTracingResult(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (MEDIA_TRACE_EVENT)AgoraJson.GetData<int>(jsonData, "currentEvent"),
                        AgoraJson.JsonToStruct<VideoRenderingTracingInfo>(jsonData, "tracingInfo")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSETRTMFLAGRESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnSetRtmFlagResult(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "code")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONTRANSCODEDSTREAMLAYOUTINFO:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnTranscodedStreamLayoutInfo(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "layoutCount"),
                        AgoraJson.JsonToStructArray<VideoLayout>(jsonData, "layoutlist")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }
                    #endregion terra IRtcEngineEventHandler
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEventForDirectCdnStreaming(IntPtr param)
        {
            if (rtcEngineEventHandler == null)
                return;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
                case AgoraEventType.EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnDirectCdnStreamingStateChanged(
                        (DIRECT_CDN_STREAMING_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (DIRECT_CDN_STREAMING_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (string)AgoraJson.GetData<string>(jsonData, "message")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnDirectCdnStreamingStats(
                        AgoraJson.JsonToStruct<DirectCdnStreamingStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
}); 
#endif
                        break;
                    }
                    #endregion terra IDirectCdnStreamingEventHandler
            }
        }
    }
}
