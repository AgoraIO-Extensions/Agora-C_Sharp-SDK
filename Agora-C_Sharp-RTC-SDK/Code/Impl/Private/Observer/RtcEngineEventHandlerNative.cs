using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class RtcEngineEventHandlerNative
    {
        internal static IRtcEngineEventHandler EngineEventHandler = null;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(string @event, string data, IntPtr buffer, IntPtr length, uint buffer_count)
        {
            if (EngineEventHandler == null) return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            switch (@event)
            {
                #region no buffer start
                case "onWarning":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnWarning(
                            (int)AgoraJson.GetData<int>(data, "warn"),
                            (string)AgoraJson.GetData<string>(data, "msg")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnError(
                            (int)AgoraJson.GetData<int>(data, "err"),
                            (string)AgoraJson.GetData<string>(data, "msg")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onJoinChannelSuccessEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnJoinChannelSuccess(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRejoinChannelSuccessEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRejoinChannelSuccess(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioQualityEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioQuality(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (int)AgoraJson.GetData<int>(data, "elapsed"),
                            (UInt16)AgoraJson.GetData<UInt16>(data, "delay"),
                            (UInt16)AgoraJson.GetData<UInt16>(data, "lost")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLeaveChannelEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLeaveChannel(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            AgoraJson.JsonToStruct<RtcStats>(data, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onClientRoleChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnClientRoleChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(data, "oldRole"),
                            (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(data, "newRole")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onClientRoleChangeFailedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnClientRoleChangeFailed(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (CLIENT_ROLE_CHANGE_FAILED_REASON)AgoraJson.GetData<int>(data, "reason"),
                            (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(data, "currentRole")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onUserJoinedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnUserJoined(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onUserOfflineEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnUserOffline(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (USER_OFFLINE_REASON_TYPE)AgoraJson.GetData<int>(data, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLastmileQuality":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLastmileQuality(
                            (int)AgoraJson.GetData<int>(data, "quality")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLastmileProbeResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLastmileProbeResult(
                            AgoraJson.JsonToStruct<LastmileProbeResult>(data, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onConnectionInterruptedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnConnectionInterrupted(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onConnectionLostEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnConnectionLost(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onConnectionBannedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnConnectionBanned(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onApiCallExecuted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnApiCallExecuted(
                            (int)AgoraJson.GetData<int>(data, "err"),
                            (string)AgoraJson.GetData<string>(data, "api"),
                            (string)AgoraJson.GetData<string>(data, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRequestTokenEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRequestToken(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onTokenPrivilegeWillExpireEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnTokenPrivilegeWillExpire(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (string)AgoraJson.GetData<string>(data, "token")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRtcStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRtcStats(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            AgoraJson.JsonToStruct<RtcStats>(data, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onNetworkQualityEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnNetworkQuality(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (int)AgoraJson.GetData<int>(data, "txQuality"),
                            (int)AgoraJson.GetData<int>(data, "rxQuality")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLocalVideoStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLocalVideoStats(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            AgoraJson.JsonToStruct<LocalVideoStats>(data, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRemoteVideoStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRemoteVideoStats(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            AgoraJson.JsonToStruct<RemoteVideoStats>(data, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLocalAudioStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLocalAudioStats(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            AgoraJson.JsonToStruct<LocalAudioStats>(data, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRemoteAudioStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRemoteAudioStats(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            AgoraJson.JsonToStruct<RemoteAudioStats>(data, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLocalAudioStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLocalAudioStateChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (LOCAL_AUDIO_STREAM_STATE)AgoraJson.GetData<int>(data, "state"),
                            (LOCAL_AUDIO_STREAM_ERROR)AgoraJson.GetData<int>(data, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRemoteAudioStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRemoteAudioStateChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (REMOTE_AUDIO_STATE)AgoraJson.GetData<int>(data, "state"),
                            (REMOTE_AUDIO_STATE_REASON)AgoraJson.GetData<int>(data, "reason"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioPublishStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioPublishStateChanged(
                            (string)AgoraJson.GetData<string>(data, "channel"),
                            (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "oldState"),
                            (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "newState"),
                            (int)AgoraJson.GetData<int>(data, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onVideoPublishStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnVideoPublishStateChanged(
                            (string)AgoraJson.GetData<string>(data, "channel"),
                            (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "oldState"),
                            (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "newState"),
                            (int)AgoraJson.GetData<int>(data, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioSubscribeStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioSubscribeStateChanged(
                            (string)AgoraJson.GetData<string>(data, "channel"),
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(data, "oldState"),
                            (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(data, "newState"),
                            (int)AgoraJson.GetData<int>(data, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onVideoSubscribeStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnVideoSubscribeStateChanged(
                            (string)AgoraJson.GetData<string>(data, "channel"),
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(data, "oldState"),
                            (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(data, "newState"),
                            (int)AgoraJson.GetData<int>(data, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioVolumeIndicationEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        var speakerNumber = (uint)AgoraJson.GetData<uint>(data, "speakerNumber");
                        var speakers = AgoraJson.JsonToStructArray<AudioVolumeInfo>(data, "speakers", speakerNumber);
                        var totalVolume = (int)AgoraJson.GetData<int>(data, "totalVolume");
                        EngineEventHandler.OnAudioVolumeIndication(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            speakers,
                            speakerNumber,
                            totalVolume
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onActiveSpeakerEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnActiveSpeaker(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "uid")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onVideoStopped":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnVideoStopped();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onFirstLocalVideoFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnFirstLocalVideoFrame(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onFirstLocalVideoFramePublishedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnFirstLocalVideoFramePublished(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onFirstRemoteVideoFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnFirstRemoteVideoFrame(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onFirstRemoteVideoDecodedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnFirstRemoteVideoDecoded(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioDeviceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioDeviceStateChanged(
                            (string)AgoraJson.GetData<string>(data, "deviceId"),
                            (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(data, "deviceType"),
                            (MEDIA_DEVICE_STATE_TYPE)AgoraJson.GetData<int>(data, "deviceState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioDeviceVolumeChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioDeviceVolumeChanged(
                            (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(data, "deviceType"),
                            (int)AgoraJson.GetData<int>(data, "volume"),
                            (bool)AgoraJson.GetData<bool>(data, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onCameraReady":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnCameraReady();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onCameraFocusAreaChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnCameraFocusAreaChanged(
                            (int)AgoraJson.GetData<int>(data, "x"),
                            (int)AgoraJson.GetData<int>(data, "y"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onFacePositionChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        var numFaces = (int)AgoraJson.GetData<int>(data, "numFaces");
                        EngineEventHandler.OnFacePositionChanged(
                            (int)AgoraJson.GetData<int>(data, "imageWidth"),
                            (int)AgoraJson.GetData<int>(data, "imageHeight"),
                            AgoraJson.JsonToStruct<Rectangle>(
                                (string)AgoraJson.GetData<string>(data, "vecRectangle")),
                            AgoraJson.JsonToStructArray<int>(data, "vecDistance", (uint)numFaces), numFaces);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onCameraExposureAreaChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnCameraExposureAreaChanged(
                            (int)AgoraJson.GetData<int>(data, "x"),
                            (int)AgoraJson.GetData<int>(data, "y"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioMixingFinished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioMixingFinished();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioMixingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioMixingStateChanged(
                            (AUDIO_MIXING_STATE_TYPE)AgoraJson.GetData<int>(data, "state"),
                            (AUDIO_MIXING_ERROR_TYPE)AgoraJson.GetData<int>(data, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRhythmPlayerStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRhythmPlayerStateChanged(
                            (RHYTHM_PLAYER_STATE_TYPE)AgoraJson.GetData<int>(data, "state"),
                            (RHYTHM_PLAYER_ERROR_TYPE)AgoraJson.GetData<int>(data, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioEffectFinished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioEffectFinished(
                            (int)AgoraJson.GetData<int>(data, "soundId")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onVideoDeviceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnVideoDeviceStateChanged(
                            (string)AgoraJson.GetData<string>(data, "deviceId"),
                            (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(data, "deviceType"),
                            (MEDIA_DEVICE_STATE_TYPE)AgoraJson.GetData<int>(data, "deviceState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLocalVideoStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLocalVideoStateChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (LOCAL_VIDEO_STREAM_STATE)AgoraJson.GetData<int>(data, "state"),
                            (LOCAL_VIDEO_STREAM_ERROR)AgoraJson.GetData<int>(data, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onVideoSizeChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnVideoSizeChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height"),
                            (int)AgoraJson.GetData<int>(data, "rotation")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onContentInspectResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnContentInspectResult(
                            (CONTENT_INSPECT_RESULT)AgoraJson.GetData<int>(data, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onSnapshotTaken":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnSnapshotTaken(
                            (string)AgoraJson.GetData<string>(data, "channel"),
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            (string)AgoraJson.GetData<string>(data, "filePath"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height"),
                            (int)AgoraJson.GetData<int>(data, "errCode")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onSnapshotTakenEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnSnapshotTaken(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (string)AgoraJson.GetData<string>(data, "filePath"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height"),
                            (int)AgoraJson.GetData<int>(data, "errCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRemoteVideoStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRemoteVideoStateChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (REMOTE_VIDEO_STATE)AgoraJson.GetData<int>(data, "state"),
                            (REMOTE_VIDEO_STATE_REASON)AgoraJson.GetData<int>(data, "reason"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onUserStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnUserStateChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (uint)AgoraJson.GetData<uint>(data, "state")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onStreamMessageErrorEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnStreamMessageError(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (int)AgoraJson.GetData<int>(data, "streamId"),
                            (int)AgoraJson.GetData<int>(data, "code"),
                            (int)AgoraJson.GetData<int>(data, "missed"),
                            (int)AgoraJson.GetData<int>(data, "cached")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onChannelMediaRelayStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnChannelMediaRelayStateChanged(
                            (int)AgoraJson.GetData<int>(data, "state"),
                            (int)AgoraJson.GetData<int>(data, "code")  // int ?
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onChannelMediaRelayEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnChannelMediaRelayEvent(
                            (int)AgoraJson.GetData<int>(data, "code") // int ?
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onFirstLocalAudioFramePublishedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnFirstLocalAudioFramePublished(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onFirstRemoteAudioFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnFirstRemoteAudioFrame(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onFirstRemoteAudioDecodedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnFirstRemoteAudioDecoded(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRtmpStreamingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRtmpStreamingStateChanged(
                            (string)AgoraJson.GetData<string>(data, "url"),
                            (RTMP_STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "state"),
                            (RTMP_STREAM_PUBLISH_ERROR_TYPE)AgoraJson.GetData<int>(data, "errCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRtmpStreamingEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRtmpStreamingEvent(
                            (string)AgoraJson.GetData<string>(data, "url"),
                            (RTMP_STREAMING_EVENT)AgoraJson.GetData<int>(data, "eventCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onStreamPublished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnStreamPublished(
                            (string)AgoraJson.GetData<string>(data, "url"),
                            (int)AgoraJson.GetData<int>(data, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onStreamUnpublished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnStreamUnpublished(
                            (string)AgoraJson.GetData<string>(data, "url")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onTranscodingUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnTranscodingUpdated();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLocalPublishFallbackToAudioOnly":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLocalPublishFallbackToAudioOnly(
                            (bool)AgoraJson.GetData<bool>(data, "isFallbackOrRecover")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRemoteSubscribeFallbackToAudioOnly":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRemoteSubscribeFallbackToAudioOnly(
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            (bool)AgoraJson.GetData<bool>(data, "isFallbackOrRecover")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRemoteAudioTransportStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRemoteAudioTransportStats(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (UInt16)AgoraJson.GetData<UInt16>(data, "delay"),
                            (UInt16)AgoraJson.GetData<UInt16>(data, "lost"),
                            (UInt16)AgoraJson.GetData<UInt16>(data, "rxKBitRate")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onRemoteVideoTransportStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnRemoteVideoTransportStats(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (UInt16)AgoraJson.GetData<UInt16>(data, "delay"),
                            (UInt16)AgoraJson.GetData<UInt16>(data, "lost"),
                            (UInt16)AgoraJson.GetData<UInt16>(data, "rxKBitRate")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onConnectionStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnConnectionStateChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(data, "state"),
                            (CONNECTION_CHANGED_REASON_TYPE)AgoraJson.GetData<int>(data, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onNetworkTypeChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnNetworkTypeChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (NETWORK_TYPE)AgoraJson.GetData<int>(data, "type")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onLocalUserRegistered":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnLocalUserRegistered(
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            (string)AgoraJson.GetData<string>(data, "userAccount")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onUserInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnUserInfoUpdated(
                            (uint)AgoraJson.GetData<uint>(data, "uid"),
                            AgoraJson.JsonToStruct<UserInfo>(data, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onMediaDeviceChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnMediaDeviceChanged(
                            (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(data, "deviceType")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onIntraRequestReceivedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnIntraRequestReceived(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onUplinkNetworkInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnUplinkNetworkInfoUpdated(
                            AgoraJson.JsonToStruct<UplinkNetworkInfo>(data, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onDownlinkNetworkInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnDownlinkNetworkInfoUpdated(
                            AgoraJson.JsonToStruct<DownlinkNetworkInfo>(data, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onVideoSourceFrameSizeChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnVideoSourceFrameSizeChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(data, "sourceType"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onEncryptionErrorEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnEncryptionError(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (ENCRYPTION_ERROR_TYPE)AgoraJson.GetData<int>(data, "errorType")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onUploadLogResultEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnUploadLogResult(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (string)AgoraJson.GetData<string>(data, "requestId"),
                            (bool)AgoraJson.GetData<bool>(data, "success"),
                            (UPLOAD_ERROR_REASON)AgoraJson.GetData<int>(data, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onUserAccountUpdatedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnUserAccountUpdated(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (string)AgoraJson.GetData<string>(data, "userAccount")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onAudioRoutingChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnAudioRoutingChanged(
                            (int)AgoraJson.GetData<int>(data, "routing")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onPermissionError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnPermissionError(
                            (PERMISSION_TYPE)AgoraJson.GetData<int>(data, "permissionType")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onExtensionEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnExtensionEvent(
                            (string)AgoraJson.GetData<string>(data, "provider"),
                            (string)AgoraJson.GetData<string>(data, "ext_name"),
                            (string)AgoraJson.GetData<string>(data, "key"),
                            (string)AgoraJson.GetData<string>(data, "value")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onExtensionStarted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnExtensionStarted(
                            (string)AgoraJson.GetData<string>(data, "provider"),
                            (string)AgoraJson.GetData<string>(data, "ext_name")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onExtensionStopped":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnExtensionStopped(
                            (string)AgoraJson.GetData<string>(data, "provider"),
                            (string)AgoraJson.GetData<string>(data, "ext_name")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "onExtensionErrored":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnExtensionErrored(
                            (string)AgoraJson.GetData<string>(data, "provider"),
                            (string)AgoraJson.GetData<string>(data, "ext_name"),
                            (int)AgoraJson.GetData<int>(data, "error"),
                            (string)AgoraJson.GetData<string>(data, "msg")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "DirectCdnStreamingEventHandler_onDirectCdnStreamingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnDirectCdnStreamingStateChanged(
                            (DIRECT_CDN_STREAMING_STATE)AgoraJson.GetData<int>(data, "state"),
                            (DIRECT_CDN_STREAMING_ERROR)AgoraJson.GetData<int>(data, "error"),
                            (string)AgoraJson.GetData<string>(data, "message")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "DirectCdnStreamingEventHandler_onDirectCdnStreamingStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnDirectCdnStreamingStats(
                            AgoraJson.JsonToStruct<DirectCdnStreamingStats>(data, "stats")
                            );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                #endregion no buffer end

                #region withBuffer start
                case "onStreamMessageEx":
                    var byteLength = (uint)AgoraJson.GetData<uint>(data, "length");
                    var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(data, "data");
                    var byteData = new byte[byteLength];
                    if (byteLength != 0)
                    {
                        Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                    }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler == null) return;
                        EngineEventHandler.OnStreamMessage(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (int)AgoraJson.GetData<int>(data, "streamId"),
                            byteData,
                            byteLength,
                            (UInt64)AgoraJson.GetData<UInt64>(data, "sentTs"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                 #endregion withBuffer end
            }
        }
    }
}
