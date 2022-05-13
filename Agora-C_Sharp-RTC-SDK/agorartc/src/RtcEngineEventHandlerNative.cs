using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    internal static class RtcEngineEventHandlerNative
    {
        internal static IAgoraRtcEngineEventHandler EngineEventHandler = null;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif 
        internal static void OnEvent(string @event, string data)
        {
            if (EngineEventHandler == null) return;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
            CallbackObject._CallbackQueue.EnQueue(() =>
            {
#endif
            //switch (@event)
            //{

            //}
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            });
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_EventWithBuffer_Native))]
#endif
        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer, uint length)
        {
            if (EngineEventHandler == null) return;
            var byteData = new byte[length];
            if (buffer != IntPtr.Zero) Marshal.Copy(buffer, byteData, 0, (int)length);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
            CallbackObject._CallbackQueue.EnQueue(() =>
            {
#endif
            switch (@event)
            {
                #region no buffer start
                case "onWarning":
                    EngineEventHandler.OnWarning(
                        (int)AgoraJson.GetData<int>(data, "warn"),
                        (string)AgoraJson.GetData<string>(data, "msg")
                    );
                    break;
                case "onError":
                    EngineEventHandler.OnError(
                        (int)AgoraJson.GetData<int>(data, "err"),
                        (string)AgoraJson.GetData<string>(data, "msg")
                    );
                    break;
                case "onJoinChannelSuccess":
                    EngineEventHandler.OnJoinChannelSuccess(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (int)AgoraJson.GetData<int>(data, "elapsed")
                    );
                    break;
                case "onRejoinChannelSuccess":
                    EngineEventHandler.OnRejoinChannelSuccess(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (int)AgoraJson.GetData<int>(data, "elapsed")
                    );
                    break;
                case "onAudioQuality":
                    EngineEventHandler.OnAudioQuality(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (int)AgoraJson.GetData<int>(data, "elapsed"),
                        (UInt16)AgoraJson.GetData<UInt16>(data, "delay"),
                        (UInt16)AgoraJson.GetData<UInt16>(data, "lost")
                    );
                    break;
                case "onLeaveChannel":
                    EngineEventHandler.OnLeaveChannel(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        AgoraJson.JsonToStruct<RtcStats>(data, "stats")
                    );
                    break;
                case "onClientRoleChanged":
                    EngineEventHandler.OnClientRoleChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(data, "oldRole"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(data, "newRole")
                    );
                    break;
                case "onUserJoined":
                    EngineEventHandler.OnUserJoined(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (int)AgoraJson.GetData<int>(data, "elapsed")
                    );
                    break;
                case "onUserOffline":
                    EngineEventHandler.OnUserOffline(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (USER_OFFLINE_REASON_TYPE)AgoraJson.GetData<int>(data, "reason")
                    );
                    break;
                case "onLastmileQuality":
                    EngineEventHandler.OnLastmileQuality(
                        (int)AgoraJson.GetData<int>(data, "quality")
                    );
                    break;
                case "onLastmileProbeResult":
                    EngineEventHandler.OnLastmileProbeResult(
                        AgoraJson.JsonToStruct<LastmileProbeResult>(data, "result")
                    );
                    break;
                case "onConnectionInterrupted":
                    EngineEventHandler.OnConnectionInterrupted(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                    );
                    break;
                case "onConnectionLost":
                    EngineEventHandler.OnConnectionLost(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                    );
                    break;
                case "onConnectionBanned":
                    EngineEventHandler.OnConnectionBanned(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                    );
                    break;
                case "onApiCallExecuted":
                    EngineEventHandler.OnApiCallExecuted(
                        (int)AgoraJson.GetData<int>(data, "err"),
                        (string)AgoraJson.GetData<string>(data, "api"),
                        (string)AgoraJson.GetData<string>(data, "result")
                    );
                    break;
                case "onRequestToken":
                    EngineEventHandler.OnRequestToken(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                    );
                    break;
                case "onTokenPrivilegeWillExpire":
                    EngineEventHandler.OnTokenPrivilegeWillExpire(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (string)AgoraJson.GetData<string>(data, "token")
                    );
                    break;
                case "onRtcStats":
                    EngineEventHandler.OnRtcStats(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        AgoraJson.JsonToStruct<RtcStats>(data, "stats")
                    );
                    break;
                case "onNetworkQuality":
                    EngineEventHandler.OnNetworkQuality(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (int)AgoraJson.GetData<int>(data, "txQuality"),
                        (int)AgoraJson.GetData<int>(data, "rxQuality")
                    );
                    break;
                case "onLocalVideoStats":
                    EngineEventHandler.OnLocalVideoStats(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        AgoraJson.JsonToStruct<LocalVideoStats>(data, "stats")
                    );
                    break;
                case "onRemoteVideoStats":
                    EngineEventHandler.OnRemoteVideoStats(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        AgoraJson.JsonToStruct<RemoteVideoStats>(data, "stats")
                    );
                    break;
                case "onLocalAudioStats":
                    EngineEventHandler.OnLocalAudioStats(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        AgoraJson.JsonToStruct<LocalAudioStats>(data, "stats")
                    );
                    break;
                case "onRemoteAudioStats":
                    EngineEventHandler.OnRemoteAudioStats(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        AgoraJson.JsonToStruct<RemoteAudioStats>(data, "stats")
                    );
                    break;
                case "onLocalAudioStateChanged":
                    EngineEventHandler.OnLocalAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (LOCAL_AUDIO_STREAM_STATE)AgoraJson.GetData<int>(data, "state"),
                        (LOCAL_AUDIO_STREAM_ERROR)AgoraJson.GetData<int>(data, "error")
                    );
                    break;
                case "onRemoteAudioStateChanged":
                    EngineEventHandler.OnRemoteAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (REMOTE_AUDIO_STATE)AgoraJson.GetData<int>(data, "state"),
                        (REMOTE_AUDIO_STATE_REASON)AgoraJson.GetData<int>(data, "reason"),
                        (int)AgoraJson.GetData<int>(data, "elapsed")
                    );
                    break;
                case "onAudioPublishStateChanged":
                    EngineEventHandler.OnAudioPublishStateChanged(
                        (string)AgoraJson.GetData<string>(data, "channel"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "newState"),
                        (int)AgoraJson.GetData<int>(data, "elapseSinceLastState")
                    );
                    break;
                case "onVideoPublishStateChanged":
                    EngineEventHandler.OnVideoPublishStateChanged(
                        (string)AgoraJson.GetData<string>(data, "channel"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "newState"),
                        (int)AgoraJson.GetData<int>(data, "elapseSinceLastState")
                    );
                    break;
                case "onAudioSubscribeStateChanged":
                    EngineEventHandler.OnAudioSubscribeStateChanged(
                        (string)AgoraJson.GetData<string>(data, "channel"),
                        (uint)AgoraJson.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(data, "newState"),
                        (int)AgoraJson.GetData<int>(data, "elapseSinceLastState")
                    );
                    break;
                case "onVideoSubscribeStateChanged":
                    EngineEventHandler.OnVideoSubscribeStateChanged(
                        (string)AgoraJson.GetData<string>(data, "channel"),
                        (uint)AgoraJson.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(data, "newState"),
                        (int)AgoraJson.GetData<int>(data, "elapseSinceLastState")
                    );
                    break;
                case "onAudioVolumeIndication":
                    var speakerNumber = (uint)AgoraJson.GetData<uint>(data, "speakerNumber");
                    var speakers = AgoraJson.JsonToStructArray<AudioVolumeInfo>(data, "speakers", speakerNumber);
                    var totalVolume = (int)AgoraJson.GetData<int>(data, "totalVolume");
                    EngineEventHandler.OnAudioVolumeIndication(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        speakers,
                        speakerNumber,
                        totalVolume
                    );
                    break;
                case "onActiveSpeaker":
                    EngineEventHandler.OnActiveSpeaker((uint)AgoraJson.GetData<uint>(data, "userId"));
                    break;
                case "onVideoStopped":
                    EngineEventHandler.OnVideoStopped();
                    break;
                case "onFirstLocalVideoFramePublished":
                    EngineEventHandler.OnFirstLocalVideoFramePublished(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (int)AgoraJson.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstRemoteVideoDecoded":
                    EngineEventHandler.OnFirstRemoteVideoDecoded(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (int)AgoraJson.GetData<int>(data, "width"),
                        (int)AgoraJson.GetData<int>(data, "height"),
                        (int)AgoraJson.GetData<int>(data, "elapsed")
                    );
                    break;
                case "onUserMuteVideo":
                    EngineEventHandler.OnUserMuteVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(data, "muted")
                    );
                    break;
                case "onUserEnableVideo":
                    EngineEventHandler.OnUserEnableVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(data, "enabled")
                    );
                    break;
                case "onAudioDeviceStateChanged":
                    EngineEventHandler.OnAudioDeviceStateChanged(
                        (string)AgoraJson.GetData<string>(data, "deviceId"),
                        (int)AgoraJson.GetData<int>(data, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE)AgoraJson.GetData<int>(data, "deviceState")
                    );
                    break;
                case "onAudioDeviceVolumeChanged":
                    EngineEventHandler.OnAudioDeviceVolumeChanged(
                        (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(data, "deviceType"),
                        (int)AgoraJson.GetData<int>(data, "volume"),
                        (bool)AgoraJson.GetData<bool>(data, "muted")
                    );
                    break;
                case "onCameraReady":
                    EngineEventHandler.OnCameraReady();
                    break;
                case "onCameraFocusAreaChanged":
                    EngineEventHandler.OnCameraFocusAreaChanged(
                        (int)AgoraJson.GetData<int>(data, "x"),
                        (int)AgoraJson.GetData<int>(data, "y"),
                        (int)AgoraJson.GetData<int>(data, "width"),
                        (int)AgoraJson.GetData<int>(data, "height")
                    );
                    break;
                case "onFacePositionChanged":
                    var numFaces = (int)AgoraJson.GetData<int>(data, "numFaces");
                    EngineEventHandler.OnFacePositionChanged(
                        (int)AgoraJson.GetData<int>(data, "imageWidth"),
                        (int)AgoraJson.GetData<int>(data, "imageHeight"),
                        AgoraJson.JsonToStruct<Rectangle>(
                            (string)AgoraJson.GetData<string>(data, "vecRectangle")),
                        AgoraJson.JsonToStructArray<int>(data, "vecDistance", (uint)numFaces), numFaces);
                    break;
                case "onCameraExposureAreaChanged":
                    EngineEventHandler.OnCameraExposureAreaChanged(
                        (int)AgoraJson.GetData<int>(data, "x"),
                        (int)AgoraJson.GetData<int>(data, "y"),
                        (int)AgoraJson.GetData<int>(data, "width"),
                        (int)AgoraJson.GetData<int>(data, "height")
                    );
                    break;
                case "onAudioMixingFinished":
                    EngineEventHandler.OnAudioMixingFinished();
                    break;
                case "onAudioMixingStateChanged":
                    EngineEventHandler.OnAudioMixingStateChanged(
                        (AUDIO_MIXING_STATE_TYPE)AgoraJson.GetData<int>(data, "state"),
                        (AUDIO_MIXING_ERROR_TYPE)AgoraJson.GetData<int>(data, "errorCode")
                    );
                    break;
                case "onAudioEffectFinished":
                    EngineEventHandler.OnAudioEffectFinished(
                        (int)AgoraJson.GetData<int>(data, "soundId")
                    );
                    break;
                case "onVideoDeviceStateChanged":
                    EngineEventHandler.OnVideoDeviceStateChanged(
                        (string)AgoraJson.GetData<string>(data, "deviceId"),
                        (int)AgoraJson.GetData<int>(data, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE)AgoraJson.GetData<int>(data, "deviceState")
                    );
                    break;
                case "onLocalVideoStateChanged":
                    EngineEventHandler.OnLocalVideoStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (LOCAL_VIDEO_STREAM_STATE)AgoraJson.GetData<int>(data, "state"),
                        (LOCAL_VIDEO_STREAM_ERROR)AgoraJson.GetData<int>(data, "errorCode")
                    );
                    break;
                case "onVideoSizeChanged":
                    EngineEventHandler.OnVideoSizeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "uid"),
                        (int)AgoraJson.GetData<int>(data, "width"),
                        (int)AgoraJson.GetData<int>(data, "height"),
                        (int)AgoraJson.GetData<int>(data, "rotation")
                    );
                    break;
                case "onRemoteVideoStateChanged":
                    EngineEventHandler.OnRemoteVideoStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (REMOTE_VIDEO_STATE)AgoraJson.GetData<int>(data, "state"),
                        (REMOTE_VIDEO_STATE_REASON)AgoraJson.GetData<int>(data, "reason"),
                        (int)AgoraJson.GetData<int>(data, "elapsed")
                    );
                    break;
                case "onUserEnableLocalVideo":
                    EngineEventHandler.OnUserEnableLocalVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(data, "enabled")
                    );
                    break;
                case "onStreamMessageError":
                    EngineEventHandler.OnStreamMessageError(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (int)AgoraJson.GetData<int>(data, "streamId"),
                        (int)AgoraJson.GetData<int>(data, "code"),
                        (int)AgoraJson.GetData<int>(data, "missed"),
                        (int)AgoraJson.GetData<int>(data, "cached")
                    );
                    break;
                case "onChannelMediaRelayStateChanged":
                    EngineEventHandler.OnChannelMediaRelayStateChanged(
                        (int)AgoraJson.GetData<int>(data, "state"),
                        (int)AgoraJson.GetData<int>(data, "code")  // int ?
                    );
                    break;
                case "onChannelMediaRelayEvent":
                    EngineEventHandler.OnChannelMediaRelayEvent(
                        (int)AgoraJson.GetData<int>(data, "code") // int ?
                    );
                    break;
                case "onFirstLocalAudioFramePublished":
                    EngineEventHandler.OnFirstLocalAudioFramePublished(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (int)AgoraJson.GetData<int>(data, "elapsed")
                    );
                    break;
                case "onRtmpStreamingStateChanged":
                    EngineEventHandler.OnRtmpStreamingStateChanged(
                        (string)AgoraJson.GetData<string>(data, "url"),
                        (RTMP_STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "state"),
                        (RTMP_STREAM_PUBLISH_ERROR_TYPE)AgoraJson.GetData<int>(data, "errCode")
                    );
                    break;
                case "onStreamPublished":
                    EngineEventHandler.OnStreamPublished(
                        (string)AgoraJson.GetData<string>(data, "url"),
                        (int)AgoraJson.GetData<int>(data, "error")
                    );
                    break;
                case "onStreamUnpublished":
                    EngineEventHandler.OnStreamUnpublished(
                        (string)AgoraJson.GetData<string>(data, "url")
                    );
                    break;
                case "onTranscodingUpdated":
                    EngineEventHandler.OnTranscodingUpdated();
                    break;

                case "onLocalPublishFallbackToAudioOnly":
                    EngineEventHandler.OnLocalPublishFallbackToAudioOnly(
                        (bool)AgoraJson.GetData<bool>(data, "isFallbackOrRecover")
                    );
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
                    EngineEventHandler.OnRemoteSubscribeFallbackToAudioOnly(
                        (uint)AgoraJson.GetData<uint>(data, "uid"),
                        (bool)AgoraJson.GetData<bool>(data, "isFallbackOrRecover")
                    );
                    break;
                case "onRemoteAudioTransportStats":
                    EngineEventHandler.OnRemoteAudioTransportStats(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (UInt16)AgoraJson.GetData<UInt16>(data, "delay"),
                        (UInt16)AgoraJson.GetData<UInt16>(data, "lost"),
                        (UInt16)AgoraJson.GetData<UInt16>(data, "rxKBitRate")
                    );
                    break;
                case "onRemoteVideoTransportStats":
                    EngineEventHandler.OnRemoteVideoTransportStats(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (UInt16)AgoraJson.GetData<UInt16>(data, "delay"),
                        (UInt16)AgoraJson.GetData<UInt16>(data, "lost"),
                        (UInt16)AgoraJson.GetData<UInt16>(data, "rxKBitRate")
                    );
                    break;
                case "onConnectionStateChanged":
                    EngineEventHandler.OnConnectionStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(data, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE)AgoraJson.GetData<int>(data, "reason")
                    );
                    break;
                case "onNetworkTypeChanged":
                    EngineEventHandler.OnNetworkTypeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (NETWORK_TYPE)AgoraJson.GetData<int>(data, "type")
                    );
                    break;
                case "onLocalUserRegistered":
                    EngineEventHandler.OnLocalUserRegistered(
                        (uint)AgoraJson.GetData<uint>(data, "uid"),
                        (string)AgoraJson.GetData<string>(data, "userAccount")
                    );
                    break;
                case "onUserInfoUpdated":
                    EngineEventHandler.OnUserInfoUpdated(
                        (uint)AgoraJson.GetData<uint>(data, "uid"),
                        AgoraJson.JsonToStruct<UserInfo>(data, "info")
                    );
                    break;
                case "onMediaDeviceChanged":
                    EngineEventHandler.OnMediaDeviceChanged(
                        (int)AgoraJson.GetData<int>(data, "deviceType")
                    );
                    break;
                case "onIntraRequestReceived":
                    EngineEventHandler.OnIntraRequestReceived(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                    );
                    break;
                case "onUplinkNetworkInfoUpdated":
                    EngineEventHandler.OnUplinkNetworkInfoUpdated(
                        AgoraJson.JsonToStruct<UplinkNetworkInfo>(data, "info")
                    );
                    break;
                case "onDownlinkNetworkInfoUpdated":
                    EngineEventHandler.OnDownlinkNetworkInfoUpdated(
                        AgoraJson.JsonToStruct<DownlinkNetworkInfo>(data, "info")
                    );
                    break;
                case "onVideoSourceFrameSizeChanged":
                    EngineEventHandler.OnVideoSourceFrameSizeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(data, "sourceType"),
                        (int)AgoraJson.GetData<int>(data, "width"),
                        (int)AgoraJson.GetData<int>(data, "height")
                    );
                    break;
                case "onEncryptionError":
                    EngineEventHandler.OnEncryptionError(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (ENCRYPTION_ERROR_TYPE)AgoraJson.GetData<int>(data, "info")
                    );
                    break;
                case "onAudioRoutingChanged":
                    EngineEventHandler.OnAudioRoutingChanged(
                        (int)AgoraJson.GetData<int>(data, "routing")
                    );
                    break;
                case "onAudioSessionRestrictionResume":
                    EngineEventHandler.OnAudioSessionRestrictionResume();
                    break;
                case "onPermissionError":
                    EngineEventHandler.OnPermissionError(
                        (PERMISSION_TYPE)AgoraJson.GetData<int>(data, "permissionType")
                    );
                    break;
                case "onExtensionEvent":
                    EngineEventHandler.OnExtensionEvent(
                        (string)AgoraJson.GetData<string>(data, "provider"),
                        (string)AgoraJson.GetData<string>(data, "extension"),
                        (string)AgoraJson.GetData<string>(data, "key"),
                        (string)AgoraJson.GetData<string>(data, "value")
                    );
                    break;
                case "onExtensionStarted":
                    EngineEventHandler.OnExtensionStarted(
                        (string)AgoraJson.GetData<string>(data, "provider"),
                        (string)AgoraJson.GetData<string>(data, "extension")
                    );
                    break;
                case "onExtensionStopped":
                    EngineEventHandler.OnExtensionStopped(
                        (string)AgoraJson.GetData<string>(data, "provider"),
                        (string)AgoraJson.GetData<string>(data, "extension")
                    );
                    break;
                case "onUserAccountUpdated":
                    EngineEventHandler.OnUserAccountUpdated(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (string)AgoraJson.GetData<string>(data, "userAccount")
                    );
                    break;
                case "onRhythmPlayerStateChanged":
                    EngineEventHandler.OnRhythmPlayerStateChanged(
                        (RHYTHM_PLAYER_STATE_TYPE)AgoraJson.GetData<uint>(data, "state"),
                        (RHYTHM_PLAYER_ERROR_TYPE)AgoraJson.GetData<uint>(data, "errorCode")
                    );
                    break;
                case "onSnapshotTaken":
                    EngineEventHandler.OnSnapshotTaken(
                        (string)AgoraJson.GetData<string>(data, "channel"),
                        (uint)AgoraJson.GetData<uint>(data, "uid"),
                        (string)AgoraJson.GetData<string>(data, "filePath"),
                        (int)AgoraJson.GetData<int>(data, "width"),
                        (int)AgoraJson.GetData<int>(data, "height"),
                        (int)AgoraJson.GetData<int>(data, "errorCode")
                    );
                    break;
                #endregion no buffer end

                #region withBuffer start
                case "onStreamMessage":
                    EngineEventHandler.OnStreamMessage(
                        AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                        (int)AgoraJson.GetData<int>(data, "streamId"), byteData, length,
                        (uint)AgoraJson.GetData<uint>(data, "sentTs"));
                    break;
                    #endregion withBuffer end
            }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            });
#endif
        }
    }
}
