#define AGORA_RTC
#define AGORA_RTM

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtm_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETHISTORYMESSAGESRESULT:
                    UInt64 requestId = (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId");
                    Internal.HistoryMessage[] messageListInternal = AgoraJson.JsonToStructArray<Internal.HistoryMessage>(jsonData, "messageList");
                    UInt64 count = (UInt64)AgoraJson.GetData<UInt64>(jsonData, "count");
                    UInt64 newStart = (UInt64)AgoraJson.GetData<UInt64>(jsonData, "newStart");
                    RTM_ERROR_CODE errorCode = (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode");
                    Rtm.HistoryMessage[] messageList = new Rtm.HistoryMessage[messageListInternal.Length];
                    for (int i = 0; i < messageListInternal.Length; i++)
                    {
                        messageList[i] = messageListInternal[i].GenerateHistoryMessage();
                    }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                CallbackObject._CallbackQueue.EnQueue(() =>
                                                      {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnGetHistoryMessagesResult(requestId, messageList, count, newStart, errorCode);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                      });
#endif
                    break;
                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONMESSAGEEVENT:
                    Internal.MessageEvent messageEventInternal = AgoraJson.JsonToStruct<Internal.MessageEvent>(jsonData, "event");
                    Rtm.MessageEvent messageEvent = messageEventInternal.GenerateMessageEvent();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                CallbackObject._CallbackQueue.EnQueue(() =>
                                                      {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnMessageEvent(messageEvent);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                      });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONLINKSTATEEVENT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnLinkStateEvent(
                        AgoraJson.JsonToStruct<LinkStateEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONPRESENCEEVENT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnPresenceEvent(
                        AgoraJson.JsonToStruct<PresenceEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONTOPICEVENT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnTopicEvent(
                        AgoraJson.JsonToStruct<TopicEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONLOCKEVENT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnLockEvent(
                        AgoraJson.JsonToStruct<LockEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONSTORAGEEVENT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnStorageEvent(
                        AgoraJson.JsonToStruct<StorageEvent>(jsonData, "event"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONJOINRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONLEAVERESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONPUBLISHTOPICMESSAGERESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnPublishTopicMessageResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                        (string)AgoraJson.GetData<string>(jsonData, "topic"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONJOINTOPICRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONLEAVETOPICRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONSUBSCRIBETOPICRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONUNSUBSCRIBETOPICRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnUnsubscribeTopicResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                        (string)AgoraJson.GetData<string>(jsonData, "topic"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETSUBSCRIBEDUSERLISTRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnGetSubscribedUserListResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                        (string)AgoraJson.GetData<string>(jsonData, "topic"),
                        AgoraJson.JsonToStruct<UserList>(jsonData, "users"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONCONNECTIONSTATECHANGED:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnConnectionStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                        (RTM_CONNECTION_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (RTM_CONNECTION_CHANGE_REASON)AgoraJson.GetData<int>(jsonData, "reason"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONTOKENPRIVILEGEWILLEXPIRE:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnTokenPrivilegeWillExpire(
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONSUBSCRIBERESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnSubscribeResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONUNSUBSCRIBERESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnUnsubscribeResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONPUBLISHRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnPublishResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONLOGINRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnLoginResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONLOGOUTRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnLogoutResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONRENEWTOKENRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnRenewTokenResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (RTM_SERVICE_TYPE)AgoraJson.GetData<int>(jsonData, "serverType"),
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONSETCHANNELMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONUPDATECHANNELMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONREMOVECHANNELMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETCHANNELMETADATARESULT:

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnGetChannelMetadataResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                        (RTM_CHANNEL_TYPE)AgoraJson.GetData<int>(jsonData, "channelType"),
                        AgoraJson.JsonToStruct<Rtm.Metadata>(jsonData, "data"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONSETUSERMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnSetUserMetadataResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "userId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONUPDATEUSERMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnUpdateUserMetadataResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "userId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONREMOVEUSERMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnRemoveUserMetadataResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "userId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETUSERMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnGetUserMetadataResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "userId"),
                        AgoraJson.JsonToStruct<Rtm.Metadata>(jsonData, "data"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONSUBSCRIBEUSERMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnSubscribeUserMetadataResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "userId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONUNSUBSCRIBEUSERMETADATARESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnUnsubscribeUserMetadataResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "userId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONSETLOCKRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONREMOVELOCKRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONRELEASELOCKRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONACQUIRELOCKRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONREVOKELOCKRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETLOCKSRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONWHONOWRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETONLINEUSERSRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnGetOnlineUsersResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        AgoraJson.JsonToStructArray<UserState>(jsonData, "userStateList"),
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "count"),
                        (string)AgoraJson.GetData<string>(jsonData, "nextPage"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONWHERENOWRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETUSERCHANNELSRESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnGetUserChannelsResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        AgoraJson.JsonToStructArray<ChannelInfo>(jsonData, "channels"),
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "count"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONPRESENCESETSTATERESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnPresenceSetStateResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONPRESENCEREMOVESTATERESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnPresenceRemoveStateResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                case AgoraApiType.FUNC_RTMEVENTHANDLER_ONPRESENCEGETSTATERESULT:
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                                                          {
#endif
                    if (rtmEventHandler == null)
                        return;
                    rtmEventHandler.OnPresenceGetStateResult(
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "requestId"),
                        AgoraJson.JsonToStruct<UserState>(jsonData, "state"),
                        (RTM_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                          });
#endif
                    break;

                default:
                    AgoraLog.LogError("unexcpect event: " + @event);
                    break;
            }
        }
    }
}