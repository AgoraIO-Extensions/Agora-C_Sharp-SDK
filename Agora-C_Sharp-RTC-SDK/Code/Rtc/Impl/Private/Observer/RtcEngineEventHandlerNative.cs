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
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            if (rtcEngineEventHandler == null) return;


            IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));

            string @event = eventParam.@event;
            string data = eventParam.data;
            IntPtr buffer = eventParam.buffer;
            IntPtr length = eventParam.length;
            uint buffer_count = eventParam.buffer_count;

            LitJson.JsonData jsonData = null;
            if (data != null)
            {
                jsonData = AgoraJson.ToObject(data);
            }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif

            switch (@event)
            {
                #region no buffer start

                case "RtcEngineEventHandler_onError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onJoinChannelSuccessEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onRejoinChannelSuccessEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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


                case "RtcEngineEventHandler_onProxyConnected":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onAudioQualityEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnAudioQuality(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "quality"),
                        (UInt16)AgoraJson.GetData<UInt16>(jsonData, "delay"),
                        (UInt16)AgoraJson.GetData<UInt16>(jsonData, "lost")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onLeaveChannelEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnLeaveChannel(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onClientRoleChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnClientRoleChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "oldRole"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "newRole"),
                        (ClientRoleOptions)AgoraJson.JsonToStruct<ClientRoleOptions>(jsonData, "newRoleOptions")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onClientRoleChangeFailedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnClientRoleChangeFailed(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CLIENT_ROLE_CHANGE_FAILED_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "currentRole")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onUserJoinedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onUserOfflineEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onUserMuteAudioEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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


                case "RtcEngineEventHandler_onUserMuteVideoEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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


                case "RtcEngineEventHandler_onUserEnableVideoEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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


                case "RtcEngineEventHandler_onUserEnableLocalVideoEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onLastmileQuality":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnLastmileQuality(
                        (int)AgoraJson.GetData<int>(jsonData, "quality")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onLastmileProbeResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnLastmileProbeResult(
                        AgoraJson.JsonToStruct<LastmileProbeResult>(jsonData, "result")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onConnectionInterruptedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnConnectionInterrupted(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onConnectionLostEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnConnectionLost(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onConnectionBannedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnConnectionBanned(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onApiCallExecuted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnApiCallExecuted(
                        (int)AgoraJson.GetData<int>(jsonData, "err"),
                        (string)AgoraJson.GetData<string>(jsonData, "api"),
                        (string)AgoraJson.GetData<string>(jsonData, "result")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onRequestTokenEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnRequestToken(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onTokenPrivilegeWillExpireEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnTokenPrivilegeWillExpire(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (string)AgoraJson.GetData<string>(jsonData, "token")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onLicenseValidationFailureEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnLicenseValidationFailure(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (LICENSE_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onRtcStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnRtcStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onNetworkQualityEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onLocalVideoStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onRemoteVideoStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onLocalAudioStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnLocalAudioStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<LocalAudioStats>(jsonData, "stats")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onRemoteAudioStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onLocalAudioStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnLocalAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (LOCAL_AUDIO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_AUDIO_STREAM_ERROR)AgoraJson.GetData<int>(jsonData, "error")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onRemoteAudioStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onAudioPublishStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onVideoPublishStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onAudioSubscribeStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onVideoSubscribeStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onAudioVolumeIndicationEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    var speakerNumber = (uint)AgoraJson.GetData<uint>(jsonData, "speakerNumber");
                    var speakers = AgoraJson.JsonToStructArray<AudioVolumeInfo>(jsonData, "speakers", speakerNumber);
                    var totalVolume = (int)AgoraJson.GetData<int>(jsonData, "totalVolume");
                    rtcEngineEventHandler.OnAudioVolumeIndication(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        speakers,
                        speakerNumber,
                        totalVolume
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onActiveSpeakerEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onVideoStopped":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnVideoStopped();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onFirstLocalVideoFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnFirstLocalVideoFrame(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onFirstLocalVideoFramePublishedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnFirstLocalVideoFramePublished(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onFirstRemoteVideoFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onFirstRemoteVideoDecodedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onAudioDeviceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onAudioMixingPositionChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnAudioMixingPositionChanged(
                        (long)AgoraJson.GetData<long>(jsonData, "position")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onAudioDeviceVolumeChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onCameraReady":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnCameraReady();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onCameraFocusAreaChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onFacePositionChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    var numFaces = (int)AgoraJson.GetData<int>(jsonData, "numFaces");
                    rtcEngineEventHandler.OnFacePositionChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "imageWidth"),
                        (int)AgoraJson.GetData<int>(jsonData, "imageHeight"),
                        AgoraJson.JsonToStruct<Rectangle>(
                            (string)AgoraJson.GetData<string>(jsonData, "vecRectangle")),
                        AgoraJson.JsonToStructArray<int>(jsonData, "vecDistance", (uint)numFaces), numFaces);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onCameraExposureAreaChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onAudioMixingFinished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnAudioMixingFinished();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onAudioMixingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onRhythmPlayerStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onAudioEffectFinished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnAudioEffectFinished(
                        (int)AgoraJson.GetData<int>(jsonData, "soundId")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onVideoDeviceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onLocalVideoStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onVideoSizeChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onContentInspectResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnContentInspectResult(
                        (CONTENT_INSPECT_RESULT)AgoraJson.GetData<int>(jsonData, "result")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onSnapshotTakenEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onRemoteVideoStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onUserStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onStreamMessageErrorEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onChannelMediaRelayStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnChannelMediaRelayStateChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "state"),
                        (int)AgoraJson.GetData<int>(jsonData, "code")  // int ?
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onChannelMediaRelayEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnChannelMediaRelayEvent(
                        (int)AgoraJson.GetData<int>(jsonData, "code") // int ?
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onFirstLocalAudioFramePublishedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnFirstLocalAudioFramePublished(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onFirstRemoteAudioFrameEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnFirstRemoteAudioFrame(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onFirstRemoteAudioDecodedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onRtmpStreamingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onRtmpStreamingEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                //                case "RtcEngineEventHandler_onStreamPublished":
                //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                //                    CallbackObject._CallbackQueue.EnQueue(() =>
                //                    {
                //#endif
                //                    if (EngineEventHandler == null) return;
                //                    EngineEventHandler.OnStreamPublished(
                //                        (string)AgoraJson.GetData<string>(data, "url"),
                //                        (int)AgoraJson.GetData<int>(data, "error")
                //                    );
                //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                //                    });
                //#endif
                //                    break;

                //                case "RtcEngineEventHandler_onStreamUnpublished":
                //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                //                    CallbackObject._CallbackQueue.EnQueue(() =>
                //                    {
                //#endif
                //                    if (EngineEventHandler == null) return;
                //                    EngineEventHandler.OnStreamUnpublished(
                //                        (string)AgoraJson.GetData<string>(data, "url")
                //                    );
                //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                //                    });
                //#endif
                //                    break;

                case "RtcEngineEventHandler_onTranscodingUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnTranscodingUpdated();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onLocalPublishFallbackToAudioOnly":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnLocalPublishFallbackToAudioOnly(
                        (bool)AgoraJson.GetData<bool>(jsonData, "isFallbackOrRecover")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onRemoteSubscribeFallbackToAudioOnly":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onRemoteAudioTransportStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnRemoteAudioTransportStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (UInt16)AgoraJson.GetData<UInt16>(jsonData, "delay"),
                        (UInt16)AgoraJson.GetData<UInt16>(jsonData, "lost"),
                        (UInt16)AgoraJson.GetData<UInt16>(jsonData, "rxKBitRate")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onRemoteVideoTransportStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnRemoteVideoTransportStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (UInt16)AgoraJson.GetData<UInt16>(jsonData, "delay"),
                        (UInt16)AgoraJson.GetData<UInt16>(jsonData, "lost"),
                        (UInt16)AgoraJson.GetData<UInt16>(jsonData, "rxKBitRate")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onConnectionStateChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnConnectionStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onWlAccMessageEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnWlAccMessage(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (WLACC_MESSAGE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (WLACC_SUGGEST_ACTION)AgoraJson.GetData<int>(jsonData, "action"),
                        (string)AgoraJson.GetData<string>(jsonData, "wlAccMsg")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onWlAccStatsEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnWlAccStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (WlAccStats)AgoraJson.JsonToStruct<WlAccStats>(jsonData, "currentStats"),
                        (WlAccStats)AgoraJson.JsonToStruct<WlAccStats>(jsonData, "averageStats")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;


                case "RtcEngineEventHandler_onNetworkTypeChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnNetworkTypeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (NETWORK_TYPE)AgoraJson.GetData<int>(jsonData, "type")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onLocalUserRegistered":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onUserInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onIntraRequestReceivedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnIntraRequestReceived(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onUplinkNetworkInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnUplinkNetworkInfoUpdated(
                        AgoraJson.JsonToStruct<UplinkNetworkInfo>(jsonData, "info")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onDownlinkNetworkInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnDownlinkNetworkInfoUpdated(
                        AgoraJson.JsonToStruct<DownlinkNetworkInfo>(jsonData, "info")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onVideoSourceFrameSizeChangedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnVideoSourceFrameSizeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "sourceType"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onEncryptionErrorEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnEncryptionError(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (ENCRYPTION_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "errorType")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onUploadLogResultEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnUploadLogResult(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "success"),
                        (UPLOAD_ERROR_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onUserAccountUpdatedEx":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnUserAccountUpdated(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onAudioRoutingChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnAudioRoutingChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "routing")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onPermissionError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnPermissionError(
                        (PERMISSION_TYPE)AgoraJson.GetData<int>(jsonData, "permissionType")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "RtcEngineEventHandler_onExtensionEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onExtensionStarted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onExtensionStopped":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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

                case "RtcEngineEventHandler_onExtensionError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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
                case "DirectCdnStreamingEventHandler_onDirectCdnStreamingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
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
                case "DirectCdnStreamingEventHandler_onDirectCdnStreamingStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (rtcEngineEventHandler == null) return;
                    rtcEngineEventHandler.OnDirectCdnStreamingStats(
                        AgoraJson.JsonToStruct<DirectCdnStreamingStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                #endregion no buffer end

                #region withBuffer start
                case "RtcEngineEventHandler_onStreamMessageEx":
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
                    if (rtcEngineEventHandler == null) return;
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
                    #endregion withBuffer end
            }
        }


    }

}
