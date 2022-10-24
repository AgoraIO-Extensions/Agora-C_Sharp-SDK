using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
using Agora.Rtc;
#endif

namespace Agora.Rtm
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
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif

            IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));
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
                    MessageEvent messageEvent = new MessageEvent();
                    messageEvent.channelType = messageEventInternal.channelType;
                    messageEvent.channelName = messageEventInternal.channelName;
                    messageEvent.channelTopic = messageEventInternal.channelTopic;
                    messageEvent.messageLength = messageEventInternal.messageLength;
                    messageEvent.publisher = messageEventInternal.publisher;

                    var byteData = new byte[messageEvent.messageLength];
                    if (messageEvent.messageLength != 0)
                    {
                        Marshal.Copy((IntPtr)messageEventInternal.message, byteData, 0, (int)messageEvent.messageLength);
                        messageEvent.message = System.Text.Encoding.UTF8.GetString(byteData);
                    }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnMessageEvent(messageEvent);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onPresenceEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnPresenceEvent(
                            AgoraJson.JsonToStruct<PresenceEvent>(jsonData, "event")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onJoinResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnJoinResult(
                            (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                            (string)AgoraJson.GetData<string>(jsonData, "userId"),
                            (STREAM_CHANNEL_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onLeaveResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnLeaveResult(
                            (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                            (string)AgoraJson.GetData<string>(jsonData, "userId"),
                            (STREAM_CHANNEL_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onJoinTopicResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnJoinTopicResult(
                            (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                            (string)AgoraJson.GetData<string>(jsonData, "userId"),
                            (string)AgoraJson.GetData<string>(jsonData, "topic"),
                            (string)AgoraJson.GetData<string>(jsonData, "meta"),
                            (STREAM_CHANNEL_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onLeaveTopicResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnLeaveTopicResult(
                            (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                            (string)AgoraJson.GetData<string>(jsonData, "userId"),
                            (string)AgoraJson.GetData<string>(jsonData, "topic"),
                            (string)AgoraJson.GetData<string>(jsonData, "meta"),
                            (STREAM_CHANNEL_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onTopicSubscribed":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnTopicSubscribed(
                            (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                            (string)AgoraJson.GetData<string>(jsonData, "userId"),
                            (string)AgoraJson.GetData<string>(jsonData, "topic"),
                            AgoraJson.JsonToStruct<UserList>(jsonData, "succeedUsers"),
                            AgoraJson.JsonToStruct<UserList>(jsonData, "failedUsers"),
                            (STREAM_CHANNEL_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onTopicUnsubscribed":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnTopicUnsubscribed(
                            (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                            (string)AgoraJson.GetData<string>(jsonData, "userId"),
                            (string)AgoraJson.GetData<string>(jsonData, "topic"),
                            AgoraJson.JsonToStruct<UserList>(jsonData, "succeedUsers"),
                            AgoraJson.JsonToStruct<UserList>(jsonData, "failedUsers"),
                            (STREAM_CHANNEL_ERROR_CODE)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onConnectionStateChange":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnConnectionStateChange(
                            (string)AgoraJson.GetData<string>(jsonData, "channelName"),
                            (RTM_CONNECTION_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                            (RTM_CONNECTION_CHANGE_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
            }
        }
    }
}