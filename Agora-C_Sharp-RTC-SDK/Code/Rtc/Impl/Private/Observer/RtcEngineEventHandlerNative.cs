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
        private static IRtcEngineEventHandler rtcEngineEventHandler = null;

        internal static void SetEventHandler(IRtcEngineEventHandler handler)
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

            switch (@event)
            {

                case "RtcEngineEventHandler_onStreamMessageEx":
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
                        rtcEngineEventHandler.OnStreamMessage(
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

                case "RtcEngineEventHandler_onJoinChannelSuccessEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnJoinChannelSuccess(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onRejoinChannelSuccessEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRejoinChannelSuccess(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onProxyConnected":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onAudioQualityEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onAudioVolumeIndicationEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioVolumeIndication(
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

                case "RtcEngineEventHandler_onAudioMixingFinished":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioMixingFinished(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onNetworkQualityEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnNetworkQuality(
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

                case "RtcEngineEventHandler_onFirstRemoteVideoDecodedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onRemoteVideoStateChangedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onVideoSizeChangedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onFirstRemoteVideoFrameEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserJoinedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserJoined(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                            (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserOfflineEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserOffline(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                            (USER_OFFLINE_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserMuteAudioEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserMuteAudio(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                            (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserMuteVideoEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserMuteVideo(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                            (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserEnableVideoEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserEnableVideo(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                            (bool)AgoraJson.GetData<bool>(jsonData, "enabled")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserStateChangedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserStateChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "state")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserEnableLocalVideoEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserEnableLocalVideo(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                            (bool)AgoraJson.GetData<bool>(jsonData, "enabled")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onRemoteAudioStatsEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteAudioStats(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            AgoraJson.JsonToStruct<RemoteAudioStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onLocalVideoStatsEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalVideoStats(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            AgoraJson.JsonToStruct<LocalVideoStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onRemoteVideoStatsEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRemoteVideoStats(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            AgoraJson.JsonToStruct<RemoteVideoStats>(jsonData, "stats")
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
                        rtcEngineEventHandler.OnCameraReady(

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
                        rtcEngineEventHandler.OnVideoStopped(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onConnectionInterruptedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnConnectionInterrupted(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onConnectionBannedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnConnectionBanned(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onStreamMessageErrorEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onFirstRemoteAudioFrameEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstRemoteAudioFrame(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "userId"),
                            (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onFirstRemoteAudioDecodedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstRemoteAudioDecoded(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                            (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onRemoteAudioStateChangedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onActiveSpeakerEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnActiveSpeaker(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "uid")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onSnapshotTakenEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
                        rtcEngineEventHandler.OnRemoteSubscribeFallbackToAudioOnly(
                            (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                            (bool)AgoraJson.GetData<bool>(jsonData, "isFallbackOrRecover")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onRemoteAudioTransportStatsEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onRemoteVideoTransportStatsEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
                        rtcEngineEventHandler.OnLocalUserRegistered(
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
                        rtcEngineEventHandler.OnUserInfoUpdated(
                            (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                            AgoraJson.JsonToStruct<UserInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserAccountUpdatedEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUserAccountUpdated(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                            (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount")
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
                        rtcEngineEventHandler.OnAudioSubscribeStateChanged(
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
                        rtcEngineEventHandler.OnVideoSubscribeStateChanged(
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

                case "RtcEngineEventHandler_onVideoRenderingTracingResultEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoRenderingTracingResult(
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

                case "RtcEngineEventHandler_onLocalVideoTranscoderError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalVideoTranscoderError(
                            AgoraJson.JsonToStruct<TranscodingVideoStream>(jsonData, "stream"),
                            (VIDEO_TRANSCODER_ERROR)AgoraJson.GetData<int>(jsonData, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onVideoLayoutInfoEx":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoLayoutInfo(
                            AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                            (int)AgoraJson.GetData<int>(jsonData, "width"),
                            (int)AgoraJson.GetData<int>(jsonData, "height"),
                            (int)AgoraJson.GetData<int>(jsonData, "layoutNumber"),
                            AgoraJson.JsonToStruct < VideoLayout const*> (jsonData, "layoutlist")
                );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
});
#endif
                        break;
                    }

                    #endregion terra IRtcEngineEventHandler
            }
        }

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
