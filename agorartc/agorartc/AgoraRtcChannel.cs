//
//  Created by Yiqing Huang on 2020/12/15.
//  Copyright © 2020 Agora. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace agorartc
{
    using uid_t = UInt32;
    using view_t = UInt64;
    using IrisChannelPtr = IntPtr;

    internal static class NativeRtcChannelEventHandler
    {
        private static readonly Dictionary<string, AgoraRtcChannel> Channels =
            new Dictionary<string, AgoraRtcChannel>();

        internal static void AddChannel(string channelId, AgoraRtcChannel _Channel)
        {
            Channels.Add(channelId, _Channel);
        }

        internal static void RemoveChannel(string channelId)
        {
            Channels.Remove(channelId);
        }

        internal static void OnEvent(string @event, string data)
        {
            var channelId = (string) AgoraUtil.GetData<string>(data, "channelId");
            switch (@event)
            {
                case "onChannelWarning":
                    Channels[channelId]?.channelEventHandler?.OnChannelWarning(channelId,
                        (int) AgoraUtil.GetData<int>(data, "warn"), (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onChannelError":
                    Channels[channelId]?.channelEventHandler?.OnChannelError(channelId,
                        (int) AgoraUtil.GetData<int>(data, "err"), (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onJoinChannelSuccess":
                    Channels[channelId]?.channelEventHandler?.OnChannelJoinChannelSuccess(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onRejoinChannelSuccess":
                    Channels[channelId]?.channelEventHandler?.OnChannelReJoinChannelSuccess(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onLeaveChannel":
                    Channels[channelId]?.channelEventHandler?.OnChannelLeaveChannel(channelId,
                        AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onClientRoleChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelClientRoleChanged(channelId,
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "oldRole"),
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "newRole"));
                    break;
                case "onUserJoined":
                    Channels[channelId]?.channelEventHandler?.OnChannelUserJoined(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserOffline":
                    Channels[channelId]?.channelEventHandler?.OnChannelUserOffLine(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (USER_OFFLINE_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onConnectionLost":
                    Channels[channelId]?.channelEventHandler?.OnChannelConnectionLost(channelId);
                    break;
                case "onRequestToken":
                    Channels[channelId]?.channelEventHandler?.OnChannelRequestToken(channelId);
                    break;
                case "onTokenPrivilegeWillExpire":
                    Channels[channelId]?.channelEventHandler?.OnChannelTokenPrivilegeWillExpire(channelId,
                        (string) AgoraUtil.GetData<string>(data, "token"));
                    break;
                case "onRtcStats":
                    Channels[channelId]?.channelEventHandler?.OnChannelRtcStats(channelId,
                        AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onNetworkQuality":
                    Channels[channelId]?.channelEventHandler?.OnChannelNetworkQuality(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "txQuality"),
                        (int) AgoraUtil.GetData<int>(data, "rxQuality"));
                    break;
                case "onRemoteVideoStats":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteVideoStats(channelId,
                        AgoraUtil.JsonToStruct<RemoteVideoStats>(data, "stats"));
                    break;
                case "onRemoteAudioStats":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteAudioStats(channelId,
                        AgoraUtil.JsonToStruct<RemoteAudioStats>(data, "stats"));
                    break;
                case "onRemoteAudioStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteAudioStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_AUDIO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_AUDIO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onAudioPublishStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelAudioPublishStateChanged(channelId,
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoPublishStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelVideoPublishStateChanged(channelId,
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onAudioSubscribeStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelAudioSubscribeStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoSubscribeStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelVideoSubscribeStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onUserSuperResolutionEnabled":
                    Channels[channelId]?.channelEventHandler?.OnChannelUserSuperResolutionEnabled(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (bool) AgoraUtil.GetData<bool>(data, "enabled"),
                        (SUPER_RESOLUTION_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onActiveSpeaker":
                    Channels[channelId]?.channelEventHandler?.OnChannelActiveSpeaker(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"));
                    break;
                case "onVideoSizeChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelVideoSizeChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"), (int) AgoraUtil.GetData<int>(data, "rotation"));
                    break;
                case "onRemoteVideoStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteVideoStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_VIDEO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_VIDEO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onStreamMessageError":
                    Channels[channelId]?.channelEventHandler?.OnChannelStreamMessageError(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "streamId"),
                        (int) AgoraUtil.GetData<int>(data, "code"), (int) AgoraUtil.GetData<int>(data, "missed"),
                        (int) AgoraUtil.GetData<int>(data, "cached"));
                    break;
                case "onChannelMediaRelayStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelMediaRelayStateChanged(channelId,
                        (CHANNEL_MEDIA_RELAY_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (CHANNEL_MEDIA_RELAY_ERROR) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onChannelMediaRelayEvent":
                    Channels[channelId]?.channelEventHandler?.OnChannelMediaRelayEvent(channelId,
                        (CHANNEL_MEDIA_RELAY_EVENT) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onRtmpStreamingStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelRtmpStreamingStateChanged(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (RTMP_STREAM_PUBLISH_ERROR) AgoraUtil.GetData<int>(data, "errCode"));
                    break;
                case "onRtmpStreamingEvent":
                    Channels[channelId]?.channelEventHandler?.OnChannelRtmpStreamingEvent(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAMING_EVENT) AgoraUtil.GetData<int>(data, "eventCode"));
                    break;
                case "onTranscodingUpdated":
                    Channels[channelId]?.channelEventHandler?.OnChannelTranscodingUpdated(channelId);
                    break;
                case "onStreamInjectedStatus":
                    Channels[channelId]?.channelEventHandler?.OnChannelStreamInjectedStatus(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"), (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "status"));
                    break;
                case "onLocalPublishFallbackToAudioOnly":
                    Channels[channelId]?.channelEventHandler?.OnChannelLocalPublishFallbackToAudioOnly(channelId,
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteSubscribeFallbackToAudioOnly(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onConnectionStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelConnectionStateChanged(channelId,
                        (CONNECTION_STATE_TYPE) AgoraUtil.GetData<int>(data, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
            }
        }

        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer)
        {
            var channelId = (string) AgoraUtil.GetData<string>(data, "channelId");
            switch (@event)
            {
                case "onStreamMessage":
                    var length = (uint) AgoraUtil.GetData<uint>(data, "length");
                    var streamData = new byte[length];
                    Marshal.Copy(buffer, streamData, 0, (int) length);
                    Channels[channelId]?.channelEventHandler?.OnChannelStreamMessage(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "streamId"),
                        streamData, length);
                    break;
            }
        }
    }

    public class AgoraRtcChannel : IDisposable
    {
        private IrisChannelPtr _irisChannel;
        private readonly string _channelId;
        private bool disposed = false;
        internal IRtcChannelEventHandlerBase channelEventHandler;
        private char[] result = new char[512];

        public AgoraRtcChannel(string id, AgoraRtcEngine rtcEngine)
        {
            _channelId = id;
            _irisChannel = AgorartcNative.GetIrisChannel(rtcEngine.GetNativeHandler());
            var para = new
            {
                channelId = _channelId
            };
            AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelCreateChannel,
                JsonConvert.SerializeObject(para), result);
        }

        /// <summary>
        /// Releases all IRtcChannel resources.
        /// 
        /// Use this method for apps in which users occasionally make voice or video calls. When users do not make calls, you
        /// can free up resources for other operations.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            ReleaseChannel();

            disposed = true;
        }

        /// <summary>
        /// Add event handler to Rtc Channel instance.
        /// </summary>
        /// 
        /// <param name="channelEventHandlerBase">
        /// @param channelEventHandlerBase
        /// An instance of IRtcChannelEventHandlerBase that contains all callback functions in Rtc Channel.
        /// Either can you create an IRtcChannelEventHandlerBase instance or you can rewrite some of the function.
        /// </param>
        public void InitChannelEventHandler(IRtcChannelEventHandlerBase channelEventHandlerBase)
        {
            channelEventHandler = channelEventHandlerBase;
            NativeRtcChannelEventHandler.AddChannel(_channelId, this);
            var myHandler = new IrisCEventHandler()
            {
                onEvent = NativeRtcEngineEventHandler.OnEvent,
                onEventWithBuffer = NativeRtcEngineEventHandler.OnEventWithBuffer
            };
            SetIrisChannelEventHandler(myHandler);
        }

        private void SetIrisChannelEventHandler(IrisCEventHandler handler)
        {
            AgorartcNative.SetIrisChannelEventHandler(_irisChannel, ref handler);
        }

        /// <summary>
        /// Joins the channel with a user ID.
        /// This method differs from the `joinChannel` method in the `IRtcEngine` class in the following aspects:
        /// | IChannel::joinChannel                                                                                                                    | IRtcEngine::joinChannel                                                                                      |
        /// |------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|
        /// | Does not contain the `channelId` parameter, because `channelId` is specified when creating the `IChannel` object.                              | Contains the `channelId` parameter, which specifies the channel to join.                                       |
        /// | Contains the `options` parameter, which decides whether to subscribe to all streams before joining the channel.                            | Does not contain the `options` parameter. By default, users subscribe to all streams when joining the channel. |
        /// | Users can join multiple channels simultaneously by creating multiple `IChannel` objects and calling the `joinChannel` method of each object. | Users can join only one channel.                                                                             |
        /// | By default, the SDK does not publish any stream after the user joins the channel. You need to call the publish method to do that.        | By default, the SDK publishes streams once the user joins the channel.                                       |
        /// @note
        /// - If you are already in a channel, you cannot rejoin it with the same `uid`.
        /// - We recommend using different UIDs for different channels.
        /// - If you want to join the same channel from different devices, ensure that the UIDs in all devices are different.
        /// - Ensure that the app ID you use to generate the token is the same with the app ID used when creating the `IRtcEngine` object.
        /// </summary>
        ///
        /// <param name="token">
        /// @param token The token for authentication:
        /// - In situations not requiring high security: You can use the temporary token generated at Console. For details, see [Get a temporary token](https://docs.agora.io/en/Agora%20Platform/token?platfor%20*%20m=All%20Platforms#get-a-temporary-token).
        /// - In situations requiring high security: Set it as the token generated at your server. For details, see [Generate a token](https://docs.agora.io/en/Agora%20Platform/token?platfor%20*%20m=All%20Platforms#get-a-token).
        /// </param>
        ///
        /// <param name="info">
        /// @param info (Optional) Additional information about the channel. This parameter can be set as null. Other users in the channel do not receive this information.
        /// </param>
        ///
        /// <param name="uid">
        /// @param uid The user ID. A 32-bit unsigned integer with a value ranging from 1 to (232-1). This parameter must be unique. If `uid` is not assigned (or set as `0`), the SDK assigns a `uid` and reports it in the \ref agora::rtc::IChannelEventHandler::onJoinChannelSuccess "onJoinChannelSuccess" callback. The app must maintain this user ID.
        /// </param>
        ///
        /// <param name="options">
        /// @param options The channel media options: \ref agora::rtc::ChannelMediaOptions::ChannelMediaOptions "ChannelMediaOptions"
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt; 0: Failure.
        /// - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        /// - -3(ERR_NOT_READY): The SDK fails to be initialized. You can try re-initializing the SDK.
        /// - -5(ERR_REFUSED): The request is rejected. This may be caused by the following:
        /// - You have created an IChannel object with the same channel name.
        /// - You have joined and published a stream in a channel created by the IChannel object.
        /// </returns>
        public ERROR_CODE JoinChannel(string token, string info, uid_t uid, ChannelMediaOptions options)
        {
            var para = new
            {
                channelId = _channelId,
                token,
                info,
                uid,
                options
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelJoinChannel,
                JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Joins the channel with a user account.
        /// After the user successfully joins the channel, the SDK triggers the following callbacks:
        /// - The local client: \ref agora::rtc::IRtcEngineEventHandler::onLocalUserRegistered "onLocalUserRegistered" and \ref agora::rtc::IChannelEventHandler::onJoinChannelSuccess "onJoinChannelSuccess" .
        /// - The remote client: \ref agora::rtc::IChannelEventHandler::onUserJoined "onUserJoined" and \ref agora::rtc::IRtcEngineEventHandler::onUserInfoUpdated "onUserInfoUpdated" , if the user joining the channel is in the `COMMUNICATION` profile, or is a host in the `LIVE_BROADCASTING` profile.
        /// @note To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account.
        /// If a user joins the channel with the Agora Web SDK, ensure that the uid of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="token">
        /// @param token The token generated at your server:
        /// - For low-security requirements: You can use the temporary token generated at Console. For details, see [Get a temporary toke](https://docs.agora.io/en/Voice/token?platform=All%20Platforms#get-a-temporary-token).
        /// - For high-security requirements: Set it as the token generated at your server. For details, see [Get a token](https://docs.agora.io/en/Voice/token?platform=All%20Platforms#get-a-token).
        /// </param>
        ///
        /// <param name="userAccount">
        /// @param userAccount The user account. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as null. Supported character scopes are:
        /// - All lowercase English letters: a to z.
        /// - All uppercase English letters: A to Z.
        /// - All numeric characters: 0 to 9.
        /// - The space character.
        /// - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
        /// </param>
        ///
        /// <param name="options">
        /// @param options The channel media options: \ref agora::rtc::ChannelMediaOptions::ChannelMediaOptions “ChannelMediaOptions”.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_INVALID_ARGUMENT (-2)
        /// - #ERR_NOT_READY (-3)
        /// - #ERR_REFUSED (-5)
        /// </returns>
        public ERROR_CODE JoinChannelWithUserAccount(string token, string userAccount,
            ChannelMediaOptions options)
        {
            var para = new
            {
                channelId = _channelId,
                token,
                userAccount,
                options
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelJoinChannelWithUserAccount, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Allows a user to leave a channel, such as hanging up or exiting a call.
        /// After joining a channel, the user must call the *leaveChannel* method to end the call before joining another channel.
        /// This method returns 0 if the user leaves the channel and releases all resources related to the call.
        /// This method call is asynchronous, and the user has not left the channel when the method call returns. Once the user leaves the channel, the SDK triggers the \ref IChannelEventHandler::onLeaveChannel "onLeaveChannel" callback.
        /// A successful \ref agora::rtc::IChannel::leaveChannel "leaveChannel" method call triggers the following callbacks:
        /// - The local client: \ref agora::rtc::IChannelEventHandler::onLeaveChannel "onLeaveChannel"
        /// - The remote client: \ref agora::rtc::IChannelEventHandler::onUserOffline "onUserOffline" , if the user leaving the channel is in the Communication channel, or is a host in the `LIVE_BROADCASTING` profile.
        /// @note
        /// - If you call the \ref IChannel::release "release" method immediately after the *leaveChannel* method, the *leaveChannel* process interrupts, and the \ref IChannelEventHandler::onLeaveChannel "onLeaveChannel" callback is not triggered.
        /// - If you call the *leaveChannel* method during a CDN live streaming, the SDK triggers the \ref IChannel::removePublishStreamUrl "removePublishStreamUrl" method.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt; 0: Failure.
        /// - -1(ERR_FAILED): A general error occurs (no specified reason).
        /// - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        /// - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        public ERROR_CODE LeaveChannel()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelLeaveChannel,
                JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Publishes the local stream to the channel.
        /// You must keep the following restrictions in mind when calling this method. Otherwise, the SDK returns the #ERR_REFUSED (5):
        /// - This method publishes one stream only to the channel corresponding to the current `IChannel` object.
        /// - In the live interactive streaming channel, only a host can call this method. To switch the client role, call \ref agora::rtc::IChannel::setClientRole "setClientRole" of the current `IChannel` object.
        /// - You can publish a stream to only one channel at a time. For details on joining multiple channels, see the advanced guide *Join Multiple Channels*.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_REFUSED (5): The method call is refused.
        /// </returns>
        public ERROR_CODE Publish()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelPublish,
                JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Stops publishing a stream to the channel.
        /// If you call this method in a channel where you are not publishing streams, the SDK returns #ERR_REFUSED (5).
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_REFUSED (5): The method call is refused.
        /// </returns>
        public ERROR_CODE Unpublish()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelUnPublish,
                JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Gets the channel ID of the current `IChannel` object.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - The channel ID of the current `IChannel` object, if the method call succeeds.
        /// - The empty string "", if the method call fails.
        /// </returns>
        public string ChannelId()
        {
            return _channelId;
        }

        /// <summary>
        /// Retrieves the current call ID.
        /// When a user joins a channel on a client, a `callId` is generated to identify the call from the client.
        /// Feedback methods, such as \ref IRtcEngine::rate "rate" and \ref IRtcEngine::complain "complain", must be called after the call ends to submit feedback to the SDK.
        /// The `rate` and `complain` methods require the `callId` parameter retrieved from the `getCallId` method during a call. `callId` is passed as an argument into the `rate` and `complain` methods after the call ends.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - Call ID in string.
        /// </returns>
        public string GetCallId()
        {
            var para = new
            {
                channelId = _channelId
            };
            return AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelGetCallId,
                JsonConvert.SerializeObject(para), result) != 0
                ? "GetCallId Failed."
                : new string(result[..Array.IndexOf(result, '\0')]);
        }

        /// <summary>
        /// Gets a new token when the current token expires after a period of time.
        /// The `token` expires after a period of time once the token schema is enabled when:
        /// - The SDK triggers the \ref IChannelEventHandler::onTokenPrivilegeWillExpire "onTokenPrivilegeWillExpire" callback, or
        /// - The \ref IChannelEventHandler::onConnectionStateChanged "onConnectionStateChanged" reports CONNECTION_CHANGED_TOKEN_EXPIRED(9).
        /// The application should call this method to get the new `token`. Failure to do so will result in the SDK disconnecting from the server.
        /// </summary>
        ///
        /// <param name="token">
        /// @param token Pointer to the new token.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt; 0: Failure.
        /// - -1(ERR_FAILED): A general error occurs (no specified reason).
        /// - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        /// - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        public ERROR_CODE RenewToken(string token)
        {
            var para = new
            {
                channelId = _channelId,
                token
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelRenewToken,
                JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Enables built-in encryption with an encryption password before users join a channel.
        /// @deprecated Deprecated as of v3.1.0. Use the \ref agora::rtc::IChannel::enableEncryption "enableEncryption" instead.
        /// All users in a channel must use the same encryption password. The encryption password is automatically cleared once a user leaves the channel.
        /// If an encryption password is not specified, the encryption functionality will be disabled.
        /// @note
        /// - Do not use this method for CDN live streaming.
        /// - For optimal transmission, ensure that the encrypted data size does not exceed the original data size + 16 bytes. 16 bytes is the maximum padding size for AES encryption.
        /// </summary>
        ///
        /// <param name="secret">
        /// @param secret Pointer to the encryption password.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetEncryptionSecret(string secret)
        {
            var para = new
            {
                channelId = _channelId,
                secret
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetEncryptionSecret, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Sets the built-in encryption mode.
        /// @deprecated Deprecated as of v3.1.0. Use the \ref agora::rtc::IChannel::enableEncryption "enableEncryption" instead.
        /// The Agora SDK supports built-in encryption, which is set to the `aes-128-xts` mode by default. Call this method to use other encryption modes.
        /// All users in the same channel must use the same encryption mode and password.
        /// Refer to the information related to the AES encryption algorithm on the differences between the encryption modes.
        /// @note Call the \ref IChannel::setEncryptionSecret "setEncryptionSecret" method to enable the built-in encryption function before calling this method.
        /// </summary>
        ///
        /// <param name="encryptionMode">
        /// @param encryptionMode The set encryption mode:
        /// - "aes-128-xts": (Default) 128-bit AES encryption, XTS mode.
        /// - "aes-128-ecb": 128-bit AES encryption, ECB mode.
        /// - "aes-256-xts": 256-bit AES encryption, XTS mode.
        /// - "": When encryptionMode is set as NULL, the encryption mode is set as "aes-128-xts" by default.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetEncryptionMode(string encryptionMode)
        {
            var para = new
            {
                channelId = _channelId,
                encryptionMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetEncryptionMode, JsonConvert.SerializeObject(para), result) * -1);
        }
        
        /// <summary>
        /// Enables/Disables the built-in encryption.
        ///
        /// @since v3.1.0
        ///
        /// In scenarios requiring high security, Agora recommends calling this method to enable the built-in encryption before joining a channel.
        ///
        /// All users in the same channel must use the same encryption mode and encryption key. Once all users leave the channel, the encryption key of this channel is automatically cleared.
        ///
        /// @note
        /// - If you enable the built-in encryption, you cannot use the RTMP streaming function.
        /// - Agora supports four encryption modes. If you choose an encryption mode (excepting `SM4_128_ECB` mode), you need to add an external encryption library when integrating the Android and iOS SDK. See the advanced guide *Channel Encryption*.
        ///
        /// </summary>
        ///
        /// <param name="enabled">
        /// @param enabled Whether to enable the built-in encryption:
        /// - true: Enable the built-in encryption.
        /// - false: Disable the built-in encryption.
        /// </param>
        ///
        /// <param name="config">
        /// @param config Configurations of built-in encryption schemas. See EncryptionConfig.
        ///
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - -2(ERR_INVALID_ARGUMENT): An invalid parameter is used. Set the parameter with a valid value.
        /// - -4(ERR_NOT_SUPPORTED): The encryption mode is incorrect or the SDK fails to load the external encryption library. Check the enumeration or reload the external encryption library.
        /// - -7(ERR_NOT_INITIALIZED): The SDK is not initialized. Initialize the `IRtcEngine` instance before calling this method.
        /// </returns>
        public ERROR_CODE EnableEncryption(bool enabled, EncryptionConfig config)
        {
            var para = new
            {
                channelId = _channelId,
                enabled,
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelEnableEncryption, JsonConvert.SerializeObject(para), result) * -1);
        }
        
        /// <summary>
        /// Registers the metadata observer.
        /// Registers the metadata observer. You need to implement the IMetadataObserver class and specify the metadata type in this method. A successful call of this method triggers the \ref agora::rtc::IMetadataObserver::getMaxMetadataSize "getMaxMetadataSize" callback.
        /// This method enables you to add synchronized metadata in the video stream for more diversified live interactive streaming, such as sending shopping links, digital coupons, and online quizzes.
        /// @note
        /// - Call this method before the joinChannel method.
        /// - This method applies to the `LIVE_BROADCASTING` channel profile.
        /// </summary>
        ///
        /// <param name="type">
        /// @param type See \ref IMetadataObserver::METADATA_TYPE "METADATA_TYPE". The SDK supports VIDEO_METADATA (0) only for now.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE RegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var para = new
            {
                channelId = _channelId,
                type
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelRegisterMediaMetadataObserver, JsonConvert.SerializeObject(para), result) * -1);
        }
        
        public ERROR_CODE UnRegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var para = new
            {
                channelId = _channelId,
                type
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelUnRegisterMediaMetadataObserver, JsonConvert.SerializeObject(para), result) * -1);
        }
        
        public ERROR_CODE SetMaxMetadataSize(int size)
        {
            var para = new
            {
                channelId = _channelId,
                size
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetMaxMetadataSize, JsonConvert.SerializeObject(para), result) * -1);
        }
        
        public ERROR_CODE SendMetadata(Metadata metadata)
        {
            var para = new
            {
                channelId = _channelId,
                metadata = new
                {
                    metadata.uid,
                    metadata.size,
                    metadata.timeStampMs
                }
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApiWithBuffer(_irisChannel,
                CApiTypeChannel.kChannelSendMetadata, JsonConvert.SerializeObject(para), metadata.buffer, result) * -1);
        }

        /// <summary>
        /// Sets the role of the user, such as a host or an audience (default), before joining a channel in the interactive live streaming.
        /// This method can be used to switch the user role in the interactive live streaming after the user joins a channel.
        /// In the `LIVE_BROADCASTING` profile, when a user switches user roles after joining a channel, a successful \ref agora::rtc::IChannel::setClientRole "setClientRole" method call triggers the following callbacks:
        /// - The local client: \ref agora::rtc::IChannelEventHandler::onClientRoleChanged "onClientRoleChanged"
        /// - The remote client: \ref agora::rtc::IChannelEventHandler::onUserJoined "onUserJoined" or \ref agora::rtc::IChannelEventHandler::onUserOffline "onUserOffline" (BECOME_AUDIENCE)
        /// @note
        /// This method applies only to the `LIVE_BROADCASTING` profile.
        /// </summary>
        ///
        /// <param name="role">
        /// @param role Sets the role of the user. See #CLIENT_ROLE_TYPE.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetClientRole(CLIENT_ROLE_TYPE role)
        {
            var para = new
            {
                channelId = _channelId,
                role
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelSetClientRole,
                JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Prioritizes a remote user's stream.
        /// Use this method with the \ref IRtcEngine::setRemoteSubscribeFallbackOption "setRemoteSubscribeFallbackOption" method.
        /// If the fallback function is enabled for a subscribed stream, the SDK ensures the high-priority user gets the best possible stream quality.
        /// @note The Agora SDK supports setting `serPriority` as high for one user only.
        /// </summary>
        ///
        /// <param name="uid">
        /// @param  uid  The ID of the remote user.
        /// </param>
        ///
        /// <param name="userPriority">
        /// @param  userPriority Sets the priority of the remote user. See #PRIORITY_TYPE.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteUserPriority(uid_t uid, PRIORITY_TYPE userPriority)
        {
            var para = new
            {
                channelId = _channelId,
                uid,
                userPriority
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteUserPriority, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Sets the sound position and gain of a remote user.
        /// When the local user calls this method to set the sound position of a remote user, the sound difference between the left and right channels allows the
        /// local user to track the real-time position of the remote user, creating a real sense of space. This method applies to massively multiplayer online games,
        /// such as Battle Royale games.
        /// @note
        /// - For this method to work, enable stereo panning for remote users by calling the \ref agora::rtc::IRtcEngine::enableSoundPositionIndication "enableSoundPositionIndication" method before joining a channel.
        /// - This method requires hardware support. For the best sound positioning, we recommend using a stereo speaker.
        /// </summary>
        ///
        /// <param name="uid">
        /// @param uid The ID of the remote user.
        /// </param>
        ///
        /// <param name="pan">
        /// @param pan The sound position of the remote user. The value ranges from -1.0 to 1.0:
        /// - 0.0: the remote sound comes from the front.
        /// - -1.0: the remote sound comes from the left.
        /// - 1.0: the remote sound comes from the right.
        /// </param>
        ///
        /// <param name="gain">
        /// @param gain Gain of the remote user. The value ranges from 0.0 to 100.0. The default value is 100.0 (the original gain of the remote user).
        /// The smaller the value, the less the gain.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteVoicePosition(uid_t uid, double pan, double gain)
        {
            var para = new
            {
                channelId = _channelId,
                uid,
                pan,
                gain
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteVoicePosition, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Updates the display mode of the video view of a remote user.
        /// After initializing the video view of a remote user, you can call this method to update its rendering and mirror modes.
        /// This method affects only the video view that the local user sees.
        /// @note
        /// - Call this method after calling the \ref agora::rtc::IRtcEngine::setupRemoteVideo "setupRemoteVideo" method to initialize the remote video view.
        /// - During a call, you can call this method as many times as necessary to update the display mode of the video view of a remote user.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The ID of the remote user.
        /// </param>
        ///
        /// <param name="renderMode">
        /// @param renderMode The rendering mode of the remote video view. See #RENDER_MODE_TYPE.
        /// </param>
        ///
        /// <param name="mirrorMode">
        /// @param mirrorMode
        /// - The mirror mode of the remote video view. See #VIDEO_MIRROR_MODE_TYPE.
        /// - **Note**: The SDK disables the mirror mode by default.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteRenderMode(uid_t userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                renderMode,
                mirrorMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteRenderMode, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Sets whether to receive all remote audio streams by default.
        /// You can call this method either before or after joining a channel. If you call `setDefaultMuteAllRemoteAudioStreams (true)` after joining a channel, the remote audio streams of all subsequent users are not received.
        /// @note If you want to resume receiving the audio stream, call \ref agora::rtc::IChannel::muteRemoteAudioStream "muteRemoteAudioStream (false)",
        /// and specify the ID of the remote user whose audio stream you want to receive.
        /// To receive the audio streams of multiple remote users, call `muteRemoteAudioStream (false)` as many times.
        /// Calling `setDefaultMuteAllRemoteAudioStreams (false)` resumes receiving the audio streams of subsequent users only.
        /// </summary>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' audio streams by default:
        /// - true:  Stops receiving all remote users' audio streams by default.
        /// - false: (Default) Receives all remote users' audio streams by default.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetDefaultMuteAllRemoteAudioStreams,
                JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Sets whether to receive all remote video streams by default.
        /// You can call this method either before or after joining a channel. If you
        /// call `setDefaultMuteAllRemoteVideoStreams (true)` after joining a channel,
        /// the remote video streams of all subsequent users are not received.
        /// @note If you want to resume receiving the video stream, call
        /// \ref agora::rtc::IChannel::muteRemoteVideoStream "muteRemoteVideoStream (false)",
        /// and specify the ID of the remote user whose video stream you want to receive.
        /// To receive the video streams of multiple remote users, call `muteRemoteVideoStream (false)`
        /// as many times. Calling `setDefaultMuteAllRemoteVideoStreams (false)` resumes
        /// receiving the video streams of subsequent users only.
        /// </summary>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' video streams by default:
        /// - true: Stop receiving all remote users' video streams by default.
        /// - false: (Default) Receive all remote users' video streams by default.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetDefaultMuteAllRemoteVideoStreams,
                JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Stops/Resumes receiving all remote users' audio streams.
        /// </summary>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' audio streams.
        /// - true: Stops receiving all remote users' audio streams.
        /// - false: (Default) Receives all remote users' audio streams.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE MuteAllRemoteAudioStreams(bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelMuteAllRemoteAudioStreams, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Adjust the playback volume of the specified remote user.
        /// After joining a channel, call \ref agora::rtc::IRtcEngine::adjustPlaybackSignalVolume "adjustPlaybackSignalVolume" to adjust the playback volume of different remote users,
        /// or adjust multiple times for one remote user.
        /// @note
        /// - Call this method after joining a channel.
        /// - This method adjusts the playback volume, which is the mixed volume for the specified remote user.
        /// - This method can only adjust the playback volume of one specified remote user at a time. If you want to adjust the playback volume of several remote users,
        /// call the method multiple times, once for each remote user.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The user ID, which should be the same as the `uid` of \ref agora::rtc::IChannel::joinChannel "joinChannel"
        /// </param>
        ///
        /// <param name="volume">
        /// @param volume The playback volume of the voice. The value ranges from 0 to 100:
        /// - 0: Mute.
        /// - 100: Original volume.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE AdjustUserPlaybackSignalVolume(uid_t userId, int volume)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelAdjustUserPlaybackSignalVolume, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Stops/Resumes receiving a specified remote user's audio stream.
        /// @note If you called the \ref agora::rtc::IChannel::muteAllRemoteAudioStreams "muteAllRemoteAudioStreams" method and set `mute` as `true` to stop
        /// receiving all remote users' audio streams, call the `muteAllRemoteAudioStreams` method and set `mute` as `false` before calling this method.
        /// The `muteAllRemoteAudioStreams` method sets all remote audio streams, while the `muteRemoteAudioStream` method sets a specified remote audio stream.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The user ID of the specified remote user sending the audio.
        /// </param>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving a specified remote user's audio stream:
        /// - true: Stops receiving the specified remote user's audio stream.
        /// - false: (Default) Receives the specified remote user's audio stream.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE MuteRemoteAudioStream(uid_t userId, bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelMuteRemoteAudioStream, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Stops/Resumes receiving all video stream from a specified remote user.
        /// </summary>
        ///
        /// <param name="mute">
        /// @param  mute Sets whether to receive/stop receiving all remote users' video streams:
        /// - true: Stop receiving all remote users' video streams.
        /// - false: (Default) Receive all remote users' video streams.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE MuteAllRemoteVideoStreams(bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelMuteAllRemoteVideoStreams, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Stops/Resumes receiving the video stream from a specified remote user.
        /// @note If you called the \ref agora::rtc::IChannel::muteAllRemoteVideoStreams "muteAllRemoteVideoStreams" method and
        /// set `mute` as `true` to stop receiving all remote video streams, call the `muteAllRemoteVideoStreams` method and
        /// set `mute` as `false` before calling this method.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The user ID of the specified remote user.
        /// </param>
        ///
        /// <param name="mute">
        /// @param mute Sets whether to stop/resume receiving the video stream from a specified remote user:
        /// - true: Stop receiving the specified remote user's video stream.
        /// - false: (Default) Receive the specified remote user's video stream.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE MuteRemoteVideoStream(uid_t userId, bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelMuteRemoteVideoStream, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Sets the stream type of the remote video.
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using
        /// \ref agora::rtc::IRtcEngine::enableDualStreamMode "enableDualStreamMode" (false),
        /// the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or
        /// the low-video stream (the low resolution, and low bitrate video stream).
        /// By default, users receive the high-quality video stream. Call this method if you want to switch to the low-video stream.
        /// This method allows the app to adjust the corresponding video stream type based on the size of the video window to
        /// reduce the bandwidth and resources.
        /// The aspect ratio of the low-video stream is the same as the high-quality video stream. Once the resolution of the high-quality video
        /// stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-video stream.
        /// The method result returns in the \ref agora::rtc::IRtcEngineEventHandler::onApiCallExecuted "onApiCallExecuted" callback.
        /// </summary>
        ///
        /// <param name="userId">
        /// @param userId The ID of the remote user sending the video stream.
        /// </param>
        ///
        /// <param name="streamType">
        /// @param streamType  Sets the video-stream type. See #REMOTE_VIDEO_STREAM_TYPE.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteVideoStreamType(uid_t userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                streamType
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteVideoStreamType, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Sets the default stream type of remote videos.
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using
        /// \ref agora::rtc::IRtcEngine::enableDualStreamMode "enableDualStreamMode" (false),
        /// the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or
        /// the low-video stream (the low resolution, and low bitrate video stream).
        /// By default, users receive the high-quality video stream. Call this method if you want to switch to the low-video stream.
        /// This method allows the app to adjust the corresponding video stream type based on the size of the video window to
        /// reduce the bandwidth and resources. The aspect ratio of the low-video stream is the same as the high-quality video stream.
        /// Once the resolution of the high-quality video
        /// stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-video stream.
        /// The method result returns in the \ref agora::rtc::IRtcEngineEventHandler::onApiCallExecuted "onApiCallExecuted" callback.
        /// </summary>
        ///
        /// <param name="streamType">
        /// @param streamType Sets the default video-stream type. See #REMOTE_VIDEO_STREAM_TYPE.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var para = new
            {
                channelId = _channelId,
                streamType
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteDefaultVideoStreamType, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Publishes the local stream to a specified CDN live RTMP address.  (CDN live only.)
        /// The SDK returns the result of this method call in the \ref IRtcEngineEventHandler::onStreamPublished "onStreamPublished" callback.
        /// The \ref agora::rtc::IChannel::addPublishStreamUrl "addPublishStreamUrl" method call triggers
        /// the \ref agora::rtc::IChannelEventHandler::onRtmpStreamingStateChanged "onRtmpStreamingStateChanged" callback on the local client
        /// to report the state of adding a local stream to the CDN.
        /// @note
        /// - Ensure that the user joins the channel before calling this method.
        /// - Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in the advanced guide *Push Streams to CDN*.
        /// - This method adds only one stream RTMP URL address each time it is called.
        /// </summary>
        ///
        /// <param name="url">
        /// @param url The CDN streaming URL in the RTMP format. The maximum length of this parameter is 1024 bytes. The RTMP URL address must not contain special characters, such as Chinese language characters.
        /// </param>
        ///
        /// <param name="transcodingEnabled">
        /// @param  transcodingEnabled Sets whether transcoding is enabled/disabled:
        /// - true: Enable transcoding. To [transcode](https://docs.agora.io/en/Agora%20Platform/terms?platform=All%20Platforms#transcoding) the audio or video streams when publishing them to CDN live, often used for combining the audio and video streams of multiple hosts in CDN live. If you set this parameter as `true`, ensure that you call the \ref IChannel::setLiveTranscoding "setLiveTranscoding" method before this method.
        /// - false: Disable transcoding.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_INVALID_ARGUMENT (2): The RTMP URL address is NULL or has a string length of 0.
        /// - #ERR_NOT_INITIALIZED (7): You have not initialized `IChannel` when publishing the stream.
        /// </returns>
        public ERROR_CODE AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            var para = new
            {
                channelId = _channelId,
                url,
                transcodingEnabled
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelAddPublishStreamUrl, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Removes an RTMP stream from the CDN.
        /// This method removes the RTMP URL address (added by the \ref IChannel::addPublishStreamUrl "addPublishStreamUrl" method) from a CDN live stream.
        /// The SDK returns the result of this method call in the \ref IRtcEngineEventHandler::onStreamUnpublished "onStreamUnpublished" callback.
        /// The \ref agora::rtc::IChannel::removePublishStreamUrl "removePublishStreamUrl" method call triggers
        /// the \ref agora::rtc::IChannelEventHandler::onRtmpStreamingStateChanged "onRtmpStreamingStateChanged" callback on the local client to report the state of removing an RTMP stream from the CDN.
        /// @note
        /// - This method removes only one RTMP URL address each time it is called.
        /// - The RTMP URL address must not contain special characters, such as Chinese language characters.
        /// </summary>
        ///
        /// <param name="url">
        /// @param url The RTMP URL address to be removed. The maximum length of this parameter is 1024 bytes.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE RemovePublishStreamUrl(string url)
        {
            var para = new
            {
                channelId = _channelId,
                url
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelRemovePublishStreamUrl, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Sets the video layout and audio settings for CDN live. (CDN live only.)
        /// The SDK triggers the \ref agora::rtc::IChannelEventHandler::onTranscodingUpdated "onTranscodingUpdated" callback when you
        /// call the `setLiveTranscoding` method to update the transcoding setting.
        /// @note
        /// - Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in the advanced guide *Push Streams to CDN*..
        /// - If you call the `setLiveTranscoding` method to set the transcoding setting for the first time, the SDK does not trigger the `onTranscodingUpdated` callback.
        /// </summary>
        ///
        /// <param name="transcoding">
        /// @param transcoding Sets the CDN live audio/video transcoding settings. See LiveTranscoding.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetLiveTranscoding(LiveTranscoding transcoding)
        {
            var para = new
            {
                channelId = _channelId,
                transcoding
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetLiveTranscoding, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Adds a voice or video stream URL address to the interactive live streaming.
        /// The \ref IRtcEngineEventHandler::onStreamPublished "onStreamPublished" callback returns the inject status.
        /// If this method call is successful, the server pulls the voice or video stream and injects it into a live channel.
        /// This is applicable to scenarios where all audience members in the channel can watch a live show and interact with each other.
        /// The \ref agora::rtc::IChannel::addInjectStreamUrl "addInjectStreamUrl" method call triggers the following callbacks:
        /// - The local client:
        /// - \ref agora::rtc::IChannelEventHandler::onStreamInjectedStatus "onStreamInjectedStatus" , with the state of the injecting the online stream.
        /// - \ref agora::rtc::IChannelEventHandler::onUserJoined "onUserJoined" (uid: 666), if the method call is successful and the online media stream is injected into the channel.
        /// - The remote client:
        /// - \ref agora::rtc::IChannelEventHandler::onUserJoined "onUserJoined" (uid: 666), if the method call is successful and the online media stream is injected into the channel.
        /// @note
        /// - Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in the advanced guide *Push Streams to CDN*.
        /// - This method applies to the Native SDK v2.4.1 and later.
        /// - This method applies to the `LIVE_BROADCASTING` profile only.
        /// - You can inject only one media stream into the channel at the same time.
        /// </summary>
        ///
        /// <param name="url">
        /// @param url The URL address to be added to the ongoing live streaming. Valid protocols are RTMP, HLS, and HTTP-FLV.
        /// - Supported audio codec type: AAC.
        /// - Supported video codec type: H264 (AVC).
        /// </param>
        ///
        /// <param name="config">
        /// @param config The InjectStreamConfig object that contains the configuration of the added voice or video stream.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - #ERR_INVALID_ARGUMENT (2): The injected URL does not exist. Call this method again to inject the stream and ensure that the URL is valid.
        /// - #ERR_NOT_READY (3): The user is not in the channel.
        /// - #ERR_NOT_SUPPORTED (4): The channel profile is not `LIVE_BROADCASTING`. Call the \ref IRtcEngine::setChannelProfile "setChannelProfile" method and set the channel profile to `LIVE_BROADCASTING` before calling this method.
        /// - #ERR_NOT_INITIALIZED (7): The SDK is not initialized. Ensure that the IChannel object is initialized before calling this method.
        /// </returns>
        public ERROR_CODE AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            var para = new
            {
                channelId = _channelId,
                url,
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelAddInjectStreamUrl, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Removes the voice or video stream URL address from a live streaming.
        /// This method removes the URL address (added by the \ref IChannel::addInjectStreamUrl "addInjectStreamUrl" method) from the live streaming.
        /// @note If this method is called successfully, the SDK triggers the \ref IChannelEventHandler::onUserOffline "onUserOffline" callback and returns a stream uid of 666.
        /// </summary>
        ///
        /// <param name="url">
        /// @param url Pointer to the URL address of the added stream to be removed.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE RemoveInjectStreamUrl(string url)
        {
            var para = new
            {
                channelId = _channelId,
                url
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelRemoveInjectStreamUrl, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Starts to relay media streams across channels.
        ///
        /// After a successful method call, the SDK triggers the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" and
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayEvent
        /// "onChannelMediaRelayEvent" callbacks, and these callbacks return the
        /// state and events of the media stream relay.
        /// - If the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" callback returns
        /// #RELAY_STATE_RUNNING (2) and #RELAY_OK (0), and the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayEvent
        /// "onChannelMediaRelayEvent" callback returns
        /// #RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4), the host starts
        /// sending data to the destination channel.
        /// - If the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" callback returns
        /// #RELAY_STATE_FAILURE (3), an exception occurs during the media stream
        /// relay.
        ///
        /// @note
        /// - Call this method after the \ref joinChannel() "joinChannel" method.
        /// - This method takes effect only when you are a host in a
        /// `LIVE_BROADCASTING` channel.
        /// - After a successful method call, if you want to call this method
        /// again, ensure that you call the
        /// \ref stopChannelMediaRelay() "stopChannelMediaRelay" method to quit the
        /// current relay.
        /// - Contact sales-us@agora.io before implementing this function.
        /// - We do not support string user accounts in this API.
        ///
        /// </summary>
        ///
        /// <param name="configuration">
        /// @param configuration The configuration of the media stream relay:
        /// ChannelMediaRelayConfiguration.
        ///
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var para = new
            {
                channelId = _channelId,
                configuration
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelStartChannelMediaRelay, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Updates the channels for media stream relay.
        ///
        /// After a successful
        /// \ref startChannelMediaRelay() "startChannelMediaRelay" method call, if
        /// you want to relay the media stream to more channels, or leave the
        /// current relay channel, you can call the
        /// \ref updateChannelMediaRelay() "updateChannelMediaRelay" method.
        ///
        /// After a successful method call, the SDK triggers the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayEvent
        /// "onChannelMediaRelayEvent" callback with the
        /// #RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL (7) state code.
        ///
        /// @note
        /// Call this method after the
        /// \ref startChannelMediaRelay() "startChannelMediaRelay" method to update
        /// the destination channel.
        ///
        /// </summary>
        ///
        /// <param name="configuration">
        /// @param configuration The media stream relay configuration:
        /// ChannelMediaRelayConfiguration.
        ///
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var para = new
            {
                channelId = _channelId,
                configuration
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelUpdateChannelMediaRelay, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Stops the media stream relay.
        ///
        /// Once the relay stops, the host quits all the destination
        /// channels.
        ///
        /// After a successful method call, the SDK triggers the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" callback. If the callback returns
        /// #RELAY_STATE_IDLE (0) and #RELAY_OK (0), the host successfully
        /// stops the relay.
        ///
        /// @note
        /// If the method call fails, the SDK triggers the
        /// \ref agora::rtc::IChannelEventHandler::onChannelMediaRelayStateChanged
        /// "onChannelMediaRelayStateChanged" callback with the
        /// #RELAY_ERROR_SERVER_NO_RESPONSE (2) or
        /// #RELAY_ERROR_SERVER_CONNECTION_LOST (8) state code. You can leave the
        /// channel by calling the \ref leaveChannel() "leaveChannel" method, and
        /// the media stream relay automatically stops.
        ///
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE StopChannelMediaRelay()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelStopChannelMediaRelay, JsonConvert.SerializeObject(para), result) * -1);
        }

        /// <summary>
        /// Creates a data stream.
        /// Each user can create up to five data streams during the lifecycle of the IChannel.
        /// @note Set both the `reliable` and `ordered` parameters to `true` or `false`. Do not set one as `true` and the other as `false`.
        /// </summary>
        ///
        /// <param name="streamId">
        /// @param [out]streamId The ID of the created data stream.
        /// </param>
        ///
        /// <param name="reliable">
        /// @param reliable Sets whether or not the recipients are guaranteed to receive the data stream from the sender within five seconds:
        /// - true: The recipients receive the data stream from the sender within five seconds. If the recipient does not receive the data stream within five seconds,
        /// an error is reported to the application.
        /// - false: There is no guarantee that the recipients receive the data stream within five seconds and no error message is reported for
        /// any delay or missing data stream.
        /// </param>
        ///
        /// <param name="ordered">
        /// @param ordered Sets whether or not the recipients receive the data stream in the sent order:
        /// - true: The recipients receive the data stream in the sent order.
        /// - false: The recipients do not receive the data stream in the sent order.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - Returns 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE CreateDataStream(out int streamId, bool reliable, bool ordered)
        {
            var para = new
            {
                channelId = _channelId,
                reliable,
                ordered
            };
            var ret = AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelCreateDataStream, JsonConvert.SerializeObject(para), result);
            streamId = ret < 0 ? -1 : ret;
            return ret < 0 ? (ERROR_CODE) (ret * -1) : ERROR_CODE.ERR_OK;
        }

        /// <summary>
        /// Sends data stream messages to all users in a channel.
        /// The SDK has the following restrictions on this method:
        /// - Up to 30 packets can be sent per second in a channel with each packet having a maximum size of 1 kB.
        /// - Each client can send up to 6 kB of data per second.
        /// - Each user can have up to five data streams simultaneously.
        /// A successful \ref agora::rtc::IChannel::sendStreamMessage "sendStreamMessage" method call triggers
        /// the \ref agora::rtc::IChannelEventHandler::onStreamMessage "onStreamMessage" callback on the remote client, from which the remote user gets the stream message.
        /// A failed \ref agora::rtc::IChannel::sendStreamMessage "sendStreamMessage" method call triggers
        /// the \ref agora::rtc::IChannelEventHandler::onStreamMessageError "onStreamMessage" callback on the remote client.
        /// @note
        /// - This method applies only to the `COMMUNICATION` profile or to the hosts in the `LIVE_BROADCASTING` profile. If an audience in the `LIVE_BROADCASTING` profile calls this method, the audience may be switched to a host.
        /// - Ensure that you have created the data stream using \ref agora::rtc::IChannel::createDataStream "createDataStream" before calling this method.
        /// </summary>
        ///
        /// <param name="streamId">
        /// @param  streamId  The ID of the sent data stream, returned in the \ref IChannel::createDataStream "createDataStream" method.
        /// </param>
        ///
        /// <param name="data">
        /// @param data The sent data.
        /// </param>
        ///
        /// <param name="length">
        /// @param length The length of the sent data.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SendStreamMessage(int streamId, byte[] data)
        {
            var para = new
            {
                channelId = _channelId,
                streamId,
                length = data.Length
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApiWithBuffer(_irisChannel,
                CApiTypeChannel.kChannelSendStreamMessage, JsonConvert.SerializeObject(para), data, result) * -1);
        }

        /// <summary>
        /// Gets the current connection state of the SDK.
        /// </summary>
        ///
        /// <returns>
        /// @return #CONNECTION_STATE_TYPE.
        /// </returns>
        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (CONNECTION_STATE_TYPE) AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelGetConnectionState, JsonConvert.SerializeObject(para), result);
        }

        public ERROR_CODE EnableRemoteSuperResolution(uint userId, bool enable)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                enable
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelEnableRemoteSuperResolution, JsonConvert.SerializeObject(para), result) * -1);
        }

        private void ReleaseChannel()
        {
            var para = new
            {
                channelId = _channelId
            };
            AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelRelease,
                JsonConvert.SerializeObject(para), result);
            NativeRtcChannelEventHandler.RemoveChannel(_channelId);
            _irisChannel = IntPtr.Zero;
            channelEventHandler = null;
            AgoraRtcEngine.CreateRtcEngine().ReleaseChannel(_channelId);
        }

        ~AgoraRtcChannel()
        {
            Dispose(false);
        }
    }
}