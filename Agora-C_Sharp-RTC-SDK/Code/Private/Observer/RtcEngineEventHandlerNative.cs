using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace agora.rtc
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

            int[] len = new int[buffer_count];
            if (length != IntPtr.Zero)
            {
                Marshal.Copy(length, len, 0, (int)buffer_count);
            }

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
                        EngineEventHandler.OnClientRoleChanged(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(data, "oldRole"),
                            (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(data, "newRole")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnClientRoleChangeFailedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                        EngineEventHandler.OnVideoStopped();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnFirstLocalVideoFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                        EngineEventHandler.OnFirstLocalVideoFramePublished(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnFirstRemoteVideoFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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

                // case "OnUserMuteAudioEx":
                //     EngineEventHandler.OnUserMuteAudio(
                //         AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                //         (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                //         (bool)AgoraJson.GetData<bool>(data, "muted")
                //     );
                //     break;


                // case "onUserMuteVideoEx":
                //     EngineEventHandler.OnUserMuteVideo(
                //         AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                //         (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                //         (bool)AgoraJson.GetData<bool>(data, "muted")
                //     );
                //     break;

                // case "onUserEnableVideoEx":
                //     EngineEventHandler.OnUserEnableVideo(
                //         AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                //         (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                //         (bool)AgoraJson.GetData<bool>(data, "enabled")
                //     );
                //     break;

                case "onAudioDeviceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                        EngineEventHandler.OnAudioMixingStateChanged(
                            (AUDIO_MIXING_STATE_TYPE)AgoraJson.GetData<int>(data, "state"),
                            (AUDIO_MIXING_ERROR_TYPE)AgoraJson.GetData<int>(data, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnRhythmPlayerStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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

                case "OnContentInspectResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        EngineEventHandler.OnContentInspectResult(
                            (CONTENT_INSPECT_RESULT)AgoraJson.GetData<int>(data, "result")
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
                        EngineEventHandler.OnSnapshotTaken(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (string)AgoraJson.GetData<string>(data, "filePath"),
                            (int)AgoraJson.GetData<int>(data, "width"),
                            (int)AgoraJson.GetData<int>(data, "height"),
                            (int)AgoraJson.GetData<int>(data, "errorCode")
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

                // case "onUserEnableLocalVideoEx":
                //     UnityEngine.Debug.Log(data);
                //     EngineEventHandler.OnUserEnableLocalVideo(
                //         AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                //         (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                //         (bool)AgoraJson.GetData<bool>(data, "enabled")
                //     );
                //     break;

                case "OnUserStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                        EngineEventHandler.OnFirstLocalAudioFramePublished(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnFirstRemoteAudioFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        EngineEventHandler.OnFirstRemoteAudioFrame(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (int)AgoraJson.GetData<int>(data, "userId"),
                            (int)AgoraJson.GetData<int>(data, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnFirstRemoteAudioDecodedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                        EngineEventHandler.OnRtmpStreamingStateChanged(
                            (string)AgoraJson.GetData<string>(data, "url"),
                            (RTMP_STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(data, "state"),
                            (RTMP_STREAM_PUBLISH_ERROR_TYPE)AgoraJson.GetData<int>(data, "errCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnRtmpStreamingEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                        EngineEventHandler.OnEncryptionError(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (ENCRYPTION_ERROR_TYPE)AgoraJson.GetData<int>(data, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnUploadLogResultEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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

                case "OnUserAccountUpdatedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                        EngineEventHandler.OnAudioRoutingChanged(
                            (int)AgoraJson.GetData<int>(data, "routing")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                //case "onAudioSessionRestrictionResume":
                //    EngineEventHandler.OnAudioSessionRestrictionResume();
                //    break;

                case "onPermissionError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                        EngineEventHandler.OnExtensionStopped(
                            (string)AgoraJson.GetData<string>(data, "provider"),
                            (string)AgoraJson.GetData<string>(data, "ext_name")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "OnExtensionErrored":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
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
                #endregion no buffer end

                #region withBuffer start
                case "onStreamMessageEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        EngineEventHandler.OnStreamMessage(
                            AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            (uint)AgoraJson.GetData<uint>(data, "remoteUid"),
                            (int)AgoraJson.GetData<int>(data, "streamId"), buffer, (uint)len[0],
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
