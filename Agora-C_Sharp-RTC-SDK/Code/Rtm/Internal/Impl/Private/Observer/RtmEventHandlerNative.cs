#define AGORA_RTC
#define AGORA_RTM

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

#if AGORA_RTC
using Agora.Rtc;
#elif AGORA_RTM
using Agora.Rtm;
#endif

namespace Agora.Rtm.Internal
{
    internal static class RtmEventHandlerNative
    {
        private static IRtmEventHandler rtmEventHandler = null;

        internal static void SetEventHandler(IRtmEventHandler handler)
        {
            rtmEventHandler = handler;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Rtm_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null)
                return;
#endif

            IrisCRtmEventParam eventParam = (IrisCRtmEventParam)Marshal.PtrToStructure(param, typeof(IrisCRtmEventParam));
            var @event = eventParam.@event;
            var data = eventParam.data;
            var buffer = eventParam.buffer;
            var length = eventParam.length;
            var buffer_count = eventParam.buffer_count;
            var jsonData = AgoraJson.ToObject(data);

            switch (@event)
            {
            case "RtmEventHandler_onMessageEvent":
                MessageEventInternal messageEventInternal = AgoraJson.JsonToStruct<MessageEventInternal>(jsonData, "event");
                MessageEvent messageEvent = messageEventInternal.GenerateMessageEvent();

                var byteData = new byte[messageEventInternal.messageLength];
                if (messageEventInternal.messageLength != 0)
                {
                    Marshal.Copy((IntPtr)messageEventInternal.message, byteData, 0, (int)messageEventInternal.messageLength);
                }
                messageEvent.message = new RtmMessage(byteData);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                CallbackObject._CallbackQueue.EnQueue(() =>
                                                      {
#endif
                                                          if (rtmEventHandler == null)
                                                              return;
                                                          rtmEventHandler.OnMessageEvent(messageEvent);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                      });
#endif
                break;

                    case "RtmEventHandler_onPresenceEvent" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnPresenceEvent(
                                                                  AgoraJson.JsonToStruct<PresenceEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onTopicEvent" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnTopicEvent(
                                                                  AgoraJson.JsonToStruct<TopicEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onLockEvent" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnLockEvent(
                                                                  AgoraJson.JsonToStruct<LockEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onStorageEvent" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnStorageEvent(
                                                                  AgoraJson.JsonToStruct<StorageEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onJoinResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnJoinResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onLeaveResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnLeaveResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onJoinTopicResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnJoinTopicResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "topic"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "meta"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onLeaveTopicResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnLeaveTopicResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "topic"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "meta"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onSubscribeTopicResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnSubscribeTopicResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "topic"),
                                                                  AgoraJson.JsonToStruct<UserList>(jsonData, "succeedUsers"),
                                                                  AgoraJson.JsonToStruct<UserList>(jsonData, "failedUsers"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onConnectionStateChange" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnConnectionStateChange(
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CONNECTION_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                                                                  (RTM_CONNECTION_CHANGE_REASON)AgoraJson.GetData<int>(jsonData, "reason"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onTokenPrivilegeWillExpire" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnTokenPrivilegeWillExpire(
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onSubscribeResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnSubscribeResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onPublishResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnPublishResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onLoginResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnLoginResult(
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onSetChannelMetadataResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnSetChannelMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onUpdateChannelMetadataResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnUpdateChannelMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onRemoveChannelMetadataResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnRemoveChannelMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onGetChannelMetadataResult" :

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnGetChannelMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  AgoraJson.JsonToStruct<RtmMetadata>(jsonData, "data"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onSetUserMetadataResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnSetUserMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onUpdateUserMetadataResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnUpdateUserMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onRemoveUserMetadataResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnRemoveUserMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onGetUserMetadataResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnGetUserMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  AgoraJson.JsonToStruct<RtmMetadata>(jsonData, "data"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onSubscribeUserMetadataResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnSubscribeUserMetadataResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "userId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onSetLockResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnSetLockResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "lockName"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onRemoveLockResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnRemoveLockResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "lockName"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onReleaseLockResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnReleaseLockResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "lockName"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onAcquireLockResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnAcquireLockResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "lockName"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "errorDetails"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onRevokeLockResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnRevokeLockResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "lockName"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onGetLocksResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnGetLocksResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                                                                  (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                                                                  AgoraJson.JsonToStructArray<LockDetail>(jsonData, "lockDetailList"),
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "count"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onWhoNowResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnWhoNowResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  AgoraJson.JsonToStructArray<UserState>(jsonData, "userStateList"),
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "count"),
                                                                  (string)AgoraJson.GetData<string>(jsonData, "nextPage"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onWhereNowResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnWhereNowResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  AgoraJson.JsonToStructArray<ChannelInfo>(jsonData, "channels"),
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "count"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onPresenceSetStateResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnPresenceSetStateResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onPresenceRemoveStateResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnPresenceRemoveStateResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    case "RtmEventHandler_onPresenceGetStateResult" :
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                                                              if (rtmEventHandler == null)
                                                                  return;
                                                              rtmEventHandler.OnPresenceGetStateResult(
                                                                  (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                                                                  AgoraJson.JsonToStruct<UserState>(jsonData, "state"),
                                                                  (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                          });
#endif
                break;

                    default : AgoraLog.LogError("unexcpect event: " + @event);
                    break;
            }
        }
    }
}