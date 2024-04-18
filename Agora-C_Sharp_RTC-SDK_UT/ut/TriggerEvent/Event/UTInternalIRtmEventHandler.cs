
using System;
using Agora.Rtc.Ut;
namespace Agora.Rtm.Ut
{
    public class UTInternalRtmEventHandler : Internal.IRtmEventHandler
    {

        public bool OnLinkStateEvent_be_trigger = false;
        public LinkStateEvent OnLinkStateEvent_event = null;

        public override void OnLinkStateEvent(LinkStateEvent @event)
        {
            OnLinkStateEvent_be_trigger = true;
        }


        public bool OnLinkStateEventPassed(LinkStateEvent @event)
        {
            if (OnLinkStateEvent_be_trigger == false)
                return false;

            return true;
        }
        ///////////////////////////////////

        public bool OnMessageEvent_be_trigger = false;
        public MessageEvent OnMessageEvent_event = null;

        public override void OnMessageEvent(MessageEvent @event)
        {
            OnMessageEvent_be_trigger = true;
            OnMessageEvent_event = @event;
        }

        public bool OnMessageEventPassed(MessageEvent @event)
        {
            if (OnMessageEvent_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<MessageEvent>(OnMessageEvent_event, @event) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPresenceEvent_be_trigger = false;
        public Internal.PresenceEvent OnPresenceEvent_event = null;

        public override void OnPresenceEvent(Internal.PresenceEvent @event)
        {
            OnPresenceEvent_be_trigger = true;
            OnPresenceEvent_event = @event;
        }

        public bool OnPresenceEventPassed(Internal.PresenceEvent @event)
        {
            if (OnPresenceEvent_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<Internal.PresenceEvent>(OnPresenceEvent_event, @event) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnTopicEvent_be_trigger = false;
        public TopicEvent OnTopicEvent_event = null;

        public override void OnTopicEvent(TopicEvent @event)
        {
            OnTopicEvent_be_trigger = true;
            OnTopicEvent_event = @event;
        }

        public bool OnTopicEventPassed(TopicEvent @event)
        {
            if (OnTopicEvent_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLockEvent_be_trigger = false;
        public LockEvent OnLockEvent_event = null;

        public override void OnLockEvent(LockEvent @event)
        {
            OnLockEvent_be_trigger = true;
            OnLockEvent_event = @event;
        }

        public bool OnLockEventPassed(LockEvent @event)
        {
            if (OnLockEvent_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<LockEvent>(OnLockEvent_event, @event) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnStorageEvent_be_trigger = false;
        public StorageEvent OnStorageEvent_event = null;

        public override void OnStorageEvent(StorageEvent @event)
        {
            OnStorageEvent_be_trigger = true;
            OnStorageEvent_event = @event;
        }

        public bool OnStorageEventPassed(StorageEvent @event)
        {
            if (OnStorageEvent_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<StorageEvent>(OnStorageEvent_event, @event) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnJoinResult_be_trigger = false;
        public UInt64 OnJoinResult_requestId = 0;
        public string OnJoinResult_channelName = null;
        public string OnJoinResult_userId = null;
        public RTM_ERROR_CODE OnJoinResult_errorCode = Rtm.RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnJoinResult(UInt64 requestId, string channelName, string userId, RTM_ERROR_CODE errorCode)
        {
            OnJoinResult_be_trigger = true;
            OnJoinResult_requestId = requestId;
            OnJoinResult_channelName = channelName;
            OnJoinResult_userId = userId;
            OnJoinResult_errorCode = errorCode;
        }

        public bool OnJoinResultPassed(UInt64 requestId, string channelName, string userId, RTM_ERROR_CODE errorCode)
        {
            if (OnJoinResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnJoinResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnJoinResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnJoinResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnJoinResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLeaveResult_be_trigger = false;
        public UInt64 OnLeaveResult_requestId = 0;
        public string OnLeaveResult_channelName = null;
        public string OnLeaveResult_userId = null;
        public RTM_ERROR_CODE OnLeaveResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnLeaveResult(UInt64 requestId, string channelName, string userId, RTM_ERROR_CODE errorCode)
        {
            OnLeaveResult_be_trigger = true;
            OnLeaveResult_requestId = requestId;
            OnLeaveResult_channelName = channelName;
            OnLeaveResult_userId = userId;
            OnLeaveResult_errorCode = errorCode;
        }

        public bool OnLeaveResultPassed(UInt64 requestId, string channelName, string userId, RTM_ERROR_CODE errorCode)
        {
            if (OnLeaveResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnLeaveResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnLeaveResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnLeaveResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnLeaveResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPublishTopicMessageResult_be_trigger = false;
        public UInt64 OnPublishTopicMessageResult_requestId = 0;
        public string OnPublishTopicMessageResult_channelName = null;
        public string OnPublishTopicMessageResult_topic = null;
        public RTM_ERROR_CODE OnPublishTopicMessageResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnPublishTopicMessageResult(UInt64 requestId, string channelName, string topic, RTM_ERROR_CODE errorCode)
        {
            OnPublishTopicMessageResult_be_trigger = true;
            OnPublishTopicMessageResult_requestId = requestId;
            OnPublishTopicMessageResult_channelName = channelName;
            OnPublishTopicMessageResult_topic = topic;
            OnPublishTopicMessageResult_errorCode = errorCode;
        }

        public bool OnPublishTopicMessageResultPassed(UInt64 requestId, string channelName, string topic, RTM_ERROR_CODE errorCode)
        {
            if (OnPublishTopicMessageResult_be_trigger == false)
                return false;



            return true;
        }

        ///////////////////////////////////


        public bool OnJoinTopicResult_be_trigger = false;
        public UInt64 OnJoinTopicResult_requestId = 0;
        public string OnJoinTopicResult_channelName = null;
        public string OnJoinTopicResult_userId = null;
        public string OnJoinTopicResult_topic = null;
        public string OnJoinTopicResult_meta = null;
        public RTM_ERROR_CODE OnJoinTopicResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnJoinTopicResult(UInt64 requestId, string channelName, string userId, string topic, string meta, RTM_ERROR_CODE errorCode)
        {
            OnJoinTopicResult_be_trigger = true;
            OnJoinTopicResult_requestId = requestId;
            OnJoinTopicResult_channelName = channelName;
            OnJoinTopicResult_userId = userId;
            OnJoinTopicResult_topic = topic;
            OnJoinTopicResult_meta = meta;
            OnJoinTopicResult_errorCode = errorCode;
        }

        public bool OnJoinTopicResultPassed(UInt64 requestId, string channelName, string userId, string topic, string meta, RTM_ERROR_CODE errorCode)
        {
            if (OnJoinTopicResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnJoinTopicResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnJoinTopicResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnJoinTopicResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnJoinTopicResult_topic, topic) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnJoinTopicResult_meta, meta) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnJoinTopicResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLeaveTopicResult_be_trigger = false;
        public UInt64 OnLeaveTopicResult_requestId = 0;
        public string OnLeaveTopicResult_channelName = null;
        public string OnLeaveTopicResult_userId = null;
        public string OnLeaveTopicResult_topic = null;
        public string OnLeaveTopicResult_meta = null;
        public RTM_ERROR_CODE OnLeaveTopicResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnLeaveTopicResult(UInt64 requestId, string channelName, string userId, string topic, string meta, RTM_ERROR_CODE errorCode)
        {
            OnLeaveTopicResult_be_trigger = true;
            OnLeaveTopicResult_requestId = requestId;
            OnLeaveTopicResult_channelName = channelName;
            OnLeaveTopicResult_userId = userId;
            OnLeaveTopicResult_topic = topic;
            OnLeaveTopicResult_meta = meta;
            OnLeaveTopicResult_errorCode = errorCode;
        }

        public bool OnLeaveTopicResultPassed(UInt64 requestId, string channelName, string userId, string topic, string meta, RTM_ERROR_CODE errorCode)
        {
            if (OnLeaveTopicResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnLeaveTopicResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnLeaveTopicResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnLeaveTopicResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnLeaveTopicResult_topic, topic) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnLeaveTopicResult_meta, meta) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnLeaveTopicResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSubscribeTopicResult_be_trigger = false;
        public UInt64 OnSubscribeTopicResult_requestId = 0;
        public string OnSubscribeTopicResult_channelName = null;
        public string OnSubscribeTopicResult_userId = null;
        public string OnSubscribeTopicResult_topic = null;
        public Agora.Rtm.Internal.UserList OnSubscribeTopicResult_succeedUsers = null;
        public Agora.Rtm.Internal.UserList OnSubscribeTopicResult_failedUsers = null;
        public RTM_ERROR_CODE OnSubscribeTopicResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnSubscribeTopicResult(UInt64 requestId, string channelName, string userId, string topic, Agora.Rtm.Internal.UserList succeedUsers, Agora.Rtm.Internal.UserList failedUsers, RTM_ERROR_CODE errorCode)
        {
            OnSubscribeTopicResult_be_trigger = true;
            OnSubscribeTopicResult_requestId = requestId;
            OnSubscribeTopicResult_channelName = channelName;
            OnSubscribeTopicResult_userId = userId;
            OnSubscribeTopicResult_topic = topic;
            OnSubscribeTopicResult_succeedUsers = succeedUsers;
            OnSubscribeTopicResult_failedUsers = failedUsers;
            OnSubscribeTopicResult_errorCode = errorCode;
        }

        public bool OnSubscribeTopicResultPassed(UInt64 requestId, string channelName, string userId, string topic, Agora.Rtm.Internal.UserList succeedUsers, Agora.Rtm.Internal.UserList failedUsers, RTM_ERROR_CODE errorCode)
        {
            if (OnSubscribeTopicResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnSubscribeTopicResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSubscribeTopicResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSubscribeTopicResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSubscribeTopicResult_topic, topic) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnSubscribeTopicResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUnsubscribeTopicResult_be_trigger = false;
        public UInt64 OnUnsubscribeTopicResult_requestId = 0;
        public string OnUnsubscribeTopicResult_channelName = null;
        public string OnUnsubscribeTopicResult_topic = null;
        public RTM_ERROR_CODE OnUnsubscribeTopicResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnUnsubscribeTopicResult(UInt64 requestId, string channelName, string topic, RTM_ERROR_CODE errorCode)
        {
            OnUnsubscribeTopicResult_be_trigger = true;
            OnUnsubscribeTopicResult_requestId = requestId;
            OnUnsubscribeTopicResult_channelName = channelName;
            OnUnsubscribeTopicResult_topic = topic;
            OnUnsubscribeTopicResult_errorCode = errorCode;
        }

        public bool OnUnsubscribeTopicResultPassed(UInt64 requestId, string channelName, string topic, RTM_ERROR_CODE errorCode)
        {
            if (OnUnsubscribeTopicResult_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnGetSubscribedUserListResult_be_trigger = false;
        public UInt64 OnGetSubscribedUserListResult_requestId = 0;
        public string OnGetSubscribedUserListResult_channelName = null;
        public string OnGetSubscribedUserListResult_topic = null;
        public Internal.UserList OnGetSubscribedUserListResult_users = null;
        public RTM_ERROR_CODE OnGetSubscribedUserListResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnGetSubscribedUserListResult(UInt64 requestId, string channelName, string topic, Internal.UserList users, RTM_ERROR_CODE errorCode)
        {
            OnGetSubscribedUserListResult_be_trigger = true;
            OnGetSubscribedUserListResult_requestId = requestId;
            OnGetSubscribedUserListResult_channelName = channelName;
            OnGetSubscribedUserListResult_topic = topic;
            OnGetSubscribedUserListResult_users = users;
            OnGetSubscribedUserListResult_errorCode = errorCode;
        }

        public bool OnGetSubscribedUserListResultPassed(UInt64 requestId, string channelName, string topic, Internal.UserList users, RTM_ERROR_CODE errorCode)
        {
            if (OnGetSubscribedUserListResult_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnConnectionStateChanged_be_trigger = false;
        public string OnConnectionStateChanged_channelName = null;
        public RTM_CONNECTION_STATE OnConnectionStateChanged_state = RTM_CONNECTION_STATE.CONNECTING;
        public RTM_CONNECTION_CHANGE_REASON OnConnectionStateChanged_reason = RTM_CONNECTION_CHANGE_REASON.BANNED_BY_SERVER;

        public override void OnConnectionStateChanged(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason)
        {
            OnConnectionStateChanged_be_trigger = true;
            OnConnectionStateChanged_channelName = channelName;
            OnConnectionStateChanged_state = state;
            OnConnectionStateChanged_reason = reason;
        }

        public bool OnConnectionStateChangePassed(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason)
        {
            if (OnConnectionStateChanged_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<string>(OnConnectionStateChanged_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CONNECTION_STATE>(OnConnectionStateChanged_state, state) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CONNECTION_CHANGE_REASON>(OnConnectionStateChanged_reason, reason) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnTokenPrivilegeWillExpire_be_trigger = false;
        public string OnTokenPrivilegeWillExpire_channelName = null;

        public override void OnTokenPrivilegeWillExpire(string channelName)
        {
            OnTokenPrivilegeWillExpire_be_trigger = true;
            OnTokenPrivilegeWillExpire_channelName = channelName;
        }

        public bool OnTokenPrivilegeWillExpirePassed(string channelName)
        {
            if (OnTokenPrivilegeWillExpire_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnTokenPrivilegeWillExpire_channelName, channelName) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSubscribeResult_be_trigger = false;
        public UInt64 OnSubscribeResult_requestId = 0;
        public string OnSubscribeResult_channelName = null;
        public RTM_ERROR_CODE OnSubscribeResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnSubscribeResult(UInt64 requestId, string channelName, RTM_ERROR_CODE errorCode)
        {
            OnSubscribeResult_be_trigger = true;
            OnSubscribeResult_requestId = requestId;
            OnSubscribeResult_channelName = channelName;
            OnSubscribeResult_errorCode = errorCode;
        }

        public bool OnSubscribeResultPassed(UInt64 requestId, string channelName, RTM_ERROR_CODE errorCode)
        {
            if (OnSubscribeResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnSubscribeResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSubscribeResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnSubscribeResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUnsubscribeResult_be_trigger = false;
        public UInt64 OnUnsubscribeResult_requestId = 0;
        public string OnUnsubscribeResult_channelName = null;
        public RTM_ERROR_CODE OnUnsubscribeResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnUnsubscribeResult(UInt64 requestId, string channelName, RTM_ERROR_CODE errorCode)
        {
            OnUnsubscribeResult_be_trigger = true;
            OnUnsubscribeResult_requestId = requestId;
            OnUnsubscribeResult_channelName = channelName;
            OnUnsubscribeResult_errorCode = errorCode;
        }

        public bool OnUnsubscribeResultPassed(UInt64 requestId, string channelName, RTM_ERROR_CODE errorCode)
        {
            if (OnUnsubscribeResult_be_trigger == false)
                return false;



            return true;
        }

        ///////////////////////////////////


        public bool OnPublishResult_be_trigger = false;
        public UInt64 OnPublishResult_requestId = 0;
        public RTM_ERROR_CODE OnPublishResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnPublishResult(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            OnPublishResult_be_trigger = true;
            OnPublishResult_requestId = requestId;
            OnPublishResult_errorCode = errorCode;
        }

        public bool OnPublishResultPassed(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            if (OnPublishResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnPublishResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnPublishResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLoginResult_be_trigger = false;
        public UInt64 OnLoginResult_requestId = 0;
        public RTM_ERROR_CODE OnLoginResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnLoginResult(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            OnLoginResult_be_trigger = true;
            OnLoginResult_requestId = requestId;
            OnLoginResult_errorCode = errorCode;
        }

        public bool OnLoginResultPassed(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            if (OnLoginResult_be_trigger == false)
                return false;


            return true;
        }

        ///////////////////////////////////

        public bool OnLogoutResult_be_trigger = false;
        public UInt64 OnLogoutResult_requestId = 0;
        public RTM_ERROR_CODE OnLogoutResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnLogoutResult(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            OnLogoutResult_be_trigger = true;
            OnLogoutResult_requestId = requestId;
            OnLogoutResult_errorCode = errorCode;
        }

        public bool OnLogoutResultPassed(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            if (OnLogoutResult_be_trigger == false)
                return false;


            return true;
        }

        ///////////////////////////////////

        public bool OnRenewTokenResult_be_trigger = false;
        public UInt64 OnRenewTokenResult_requestId = 0;
        public RTM_SERVICE_TYPE OnRenewTokenResult_serverType = RTM_SERVICE_TYPE.RTM_SERVICE_TYPE_NONE;
        public string OnRenewTokenResult_channelName = "";
        public RTM_ERROR_CODE OnRenewTokenResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnRenewTokenResult(UInt64 requestId, RTM_SERVICE_TYPE serverType, string channelName, RTM_ERROR_CODE errorCode)
        {
            OnRenewTokenResult_be_trigger = true;
            OnRenewTokenResult_requestId = requestId;
            OnRenewTokenResult_serverType = serverType;
            OnRenewTokenResult_channelName = channelName;
            OnRenewTokenResult_errorCode = errorCode;
        }

        public bool OnRenewTokenResultPassed(UInt64 requestId, RTM_SERVICE_TYPE serverType, string channelName, RTM_ERROR_CODE errorCode)
        {
            if (OnRenewTokenResult_be_trigger == false)
                return false;


            return true;
        }

        ///////////////////////////////////


        public bool OnSetChannelMetadataResult_be_trigger = false;
        public UInt64 OnSetChannelMetadataResult_requestId = 0;
        public string OnSetChannelMetadataResult_channelName = null;
        public RTM_CHANNEL_TYPE OnSetChannelMetadataResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public RTM_ERROR_CODE OnSetChannelMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnSetChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode)
        {
            OnSetChannelMetadataResult_be_trigger = true;
            OnSetChannelMetadataResult_requestId = requestId;
            OnSetChannelMetadataResult_channelName = channelName;
            OnSetChannelMetadataResult_channelType = channelType;
            OnSetChannelMetadataResult_errorCode = errorCode;
        }

        public bool OnSetChannelMetadataResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode)
        {
            if (OnSetChannelMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnSetChannelMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSetChannelMetadataResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnSetChannelMetadataResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnSetChannelMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnUpdateChannelMetadataResult_be_trigger = false;
        public UInt64 OnUpdateChannelMetadataResult_requestId = 0;
        public string OnUpdateChannelMetadataResult_channelName = null;
        public RTM_CHANNEL_TYPE OnUpdateChannelMetadataResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public RTM_ERROR_CODE OnUpdateChannelMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnUpdateChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode)
        {
            OnUpdateChannelMetadataResult_be_trigger = true;
            OnUpdateChannelMetadataResult_requestId = requestId;
            OnUpdateChannelMetadataResult_channelName = channelName;
            OnUpdateChannelMetadataResult_channelType = channelType;
            OnUpdateChannelMetadataResult_errorCode = errorCode;
        }

        public bool OnUpdateChannelMetadataResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode)
        {
            if (OnUpdateChannelMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnUpdateChannelMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnUpdateChannelMetadataResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnUpdateChannelMetadataResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnUpdateChannelMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRemoveChannelMetadataResult_be_trigger = false;
        public UInt64 OnRemoveChannelMetadataResult_requestId = 0;
        public string OnRemoveChannelMetadataResult_channelName = null;
        public RTM_CHANNEL_TYPE OnRemoveChannelMetadataResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public RTM_ERROR_CODE OnRemoveChannelMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnRemoveChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode)
        {
            OnRemoveChannelMetadataResult_be_trigger = true;
            OnRemoveChannelMetadataResult_requestId = requestId;
            OnRemoveChannelMetadataResult_channelName = channelName;
            OnRemoveChannelMetadataResult_channelType = channelType;
            OnRemoveChannelMetadataResult_errorCode = errorCode;
        }

        public bool OnRemoveChannelMetadataResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode)
        {
            if (OnRemoveChannelMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnRemoveChannelMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnRemoveChannelMetadataResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnRemoveChannelMetadataResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnRemoveChannelMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnGetChannelMetadataResult_be_trigger = false;
        public UInt64 OnGetChannelMetadataResult_requestId = 0;
        public string OnGetChannelMetadataResult_channelName = null;
        public RTM_CHANNEL_TYPE OnGetChannelMetadataResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public Metadata OnGetChannelMetadataResult_data = null;
        public RTM_ERROR_CODE OnGetChannelMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnGetChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, Metadata data, RTM_ERROR_CODE errorCode)
        {
            OnGetChannelMetadataResult_be_trigger = true;
            OnGetChannelMetadataResult_requestId = requestId;
            OnGetChannelMetadataResult_channelName = channelName;
            OnGetChannelMetadataResult_channelType = channelType;
            OnGetChannelMetadataResult_data = data;
            OnGetChannelMetadataResult_errorCode = errorCode;
        }

        public bool OnGetChannelMetadataResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, Metadata data, RTM_ERROR_CODE errorCode)
        {
            if (OnGetChannelMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnGetChannelMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnGetChannelMetadataResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnGetChannelMetadataResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<RtmMetadata>(OnGetChannelMetadataResult_data, data) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnGetChannelMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSetUserMetadataResult_be_trigger = false;
        public UInt64 OnSetUserMetadataResult_requestId = 0;
        public string OnSetUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnSetUserMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnSetUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            OnSetUserMetadataResult_be_trigger = true;
            OnSetUserMetadataResult_requestId = requestId;
            OnSetUserMetadataResult_userId = userId;
            OnSetUserMetadataResult_errorCode = errorCode;
        }

        public bool OnSetUserMetadataResultPassed(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            if (OnSetUserMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnSetUserMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSetUserMetadataResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnSetUserMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnUpdateUserMetadataResult_be_trigger = false;
        public UInt64 OnUpdateUserMetadataResult_requestId = 0;
        public string OnUpdateUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnUpdateUserMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnUpdateUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            OnUpdateUserMetadataResult_be_trigger = true;
            OnUpdateUserMetadataResult_requestId = requestId;
            OnUpdateUserMetadataResult_userId = userId;
            OnUpdateUserMetadataResult_errorCode = errorCode;
        }

        public bool OnUpdateUserMetadataResultPassed(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            if (OnUpdateUserMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnUpdateUserMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnUpdateUserMetadataResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnUpdateUserMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRemoveUserMetadataResult_be_trigger = false;
        public UInt64 OnRemoveUserMetadataResult_requestId = 0;
        public string OnRemoveUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnRemoveUserMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnRemoveUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            OnRemoveUserMetadataResult_be_trigger = true;
            OnRemoveUserMetadataResult_requestId = requestId;
            OnRemoveUserMetadataResult_userId = userId;
            OnRemoveUserMetadataResult_errorCode = errorCode;
        }

        public bool OnRemoveUserMetadataResultPassed(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            if (OnRemoveUserMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnRemoveUserMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnRemoveUserMetadataResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnRemoveUserMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnGetUserMetadataResult_be_trigger = false;
        public UInt64 OnGetUserMetadataResult_requestId = 0;
        public string OnGetUserMetadataResult_userId = null;
        public Metadata OnGetUserMetadataResult_data = null;
        public RTM_ERROR_CODE OnGetUserMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnGetUserMetadataResult(UInt64 requestId, string userId, Metadata data, RTM_ERROR_CODE errorCode)
        {
            OnGetUserMetadataResult_be_trigger = true;
            OnGetUserMetadataResult_requestId = requestId;
            OnGetUserMetadataResult_userId = userId;
            OnGetUserMetadataResult_data = data;
            OnGetUserMetadataResult_errorCode = errorCode;
        }

        public bool OnGetUserMetadataResultPassed(UInt64 requestId, string userId, Metadata data, RTM_ERROR_CODE errorCode)
        {
            if (OnGetUserMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnGetUserMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnGetUserMetadataResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RtmMetadata>(OnGetUserMetadataResult_data, data) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnGetUserMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSubscribeUserMetadataResult_be_trigger = false;
        public UInt64 OnSubscribeUserMetadataResult_requestId = 0;
        public string OnSubscribeUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnSubscribeUserMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnSubscribeUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            OnSubscribeUserMetadataResult_be_trigger = true;
            OnSubscribeUserMetadataResult_requestId = requestId;
            OnSubscribeUserMetadataResult_userId = userId;
            OnSubscribeUserMetadataResult_errorCode = errorCode;
        }

        public bool OnSubscribeUserMetadataResultPassed(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            if (OnSubscribeUserMetadataResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnSubscribeUserMetadataResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSubscribeUserMetadataResult_userId, userId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnSubscribeUserMetadataResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUnsubscribeUserMetadataResult_be_trigger = false;
        public UInt64 OnUnsubscribeUserMetadataResult_requestId = 0;
        public string OnUnsubscribeUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnUnsubscribeUserMetadataResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnUnsubscribeUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            OnUnsubscribeUserMetadataResult_be_trigger = true;
            OnUnsubscribeUserMetadataResult_requestId = requestId;
            OnUnsubscribeUserMetadataResult_userId = userId;
            OnUnsubscribeUserMetadataResult_errorCode = errorCode;
        }

        public bool OnUnsubscribeUserMetadataResultPassed(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode)
        {
            if (OnUnsubscribeUserMetadataResult_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSetLockResult_be_trigger = false;
        public UInt64 OnSetLockResult_requestId = 0;
        public string OnSetLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnSetLockResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public string OnSetLockResult_lockName = null;
        public RTM_ERROR_CODE OnSetLockResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnSetLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode)
        {
            OnSetLockResult_be_trigger = true;
            OnSetLockResult_requestId = requestId;
            OnSetLockResult_channelName = channelName;
            OnSetLockResult_channelType = channelType;
            OnSetLockResult_lockName = lockName;
            OnSetLockResult_errorCode = errorCode;
        }

        public bool OnSetLockResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode)
        {
            if (OnSetLockResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnSetLockResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSetLockResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnSetLockResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnSetLockResult_lockName, lockName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnSetLockResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRemoveLockResult_be_trigger = false;
        public UInt64 OnRemoveLockResult_requestId = 0;
        public string OnRemoveLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnRemoveLockResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public string OnRemoveLockResult_lockName = null;
        public RTM_ERROR_CODE OnRemoveLockResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnRemoveLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode)
        {
            OnRemoveLockResult_be_trigger = true;
            OnRemoveLockResult_requestId = requestId;
            OnRemoveLockResult_channelName = channelName;
            OnRemoveLockResult_channelType = channelType;
            OnRemoveLockResult_lockName = lockName;
            OnRemoveLockResult_errorCode = errorCode;
        }

        public bool OnRemoveLockResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode)
        {
            if (OnRemoveLockResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnRemoveLockResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnRemoveLockResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnRemoveLockResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnRemoveLockResult_lockName, lockName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnRemoveLockResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnReleaseLockResult_be_trigger = false;
        public UInt64 OnReleaseLockResult_requestId = 0;
        public string OnReleaseLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnReleaseLockResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public string OnReleaseLockResult_lockName = null;
        public RTM_ERROR_CODE OnReleaseLockResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnReleaseLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode)
        {
            OnReleaseLockResult_be_trigger = true;
            OnReleaseLockResult_requestId = requestId;
            OnReleaseLockResult_channelName = channelName;
            OnReleaseLockResult_channelType = channelType;
            OnReleaseLockResult_lockName = lockName;
            OnReleaseLockResult_errorCode = errorCode;
        }

        public bool OnReleaseLockResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode)
        {
            if (OnReleaseLockResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnReleaseLockResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnReleaseLockResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnReleaseLockResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnReleaseLockResult_lockName, lockName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnReleaseLockResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnAcquireLockResult_be_trigger = false;
        public UInt64 OnAcquireLockResult_requestId = 0;
        public string OnAcquireLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnAcquireLockResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public string OnAcquireLockResult_lockName = null;
        public RTM_ERROR_CODE OnAcquireLockResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;
        public string OnAcquireLockResult_errorDetails = null;

        public override void OnAcquireLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode, string errorDetails)
        {
            OnAcquireLockResult_be_trigger = true;
            OnAcquireLockResult_requestId = requestId;
            OnAcquireLockResult_channelName = channelName;
            OnAcquireLockResult_channelType = channelType;
            OnAcquireLockResult_lockName = lockName;
            OnAcquireLockResult_errorCode = errorCode;
            OnAcquireLockResult_errorDetails = errorDetails;
        }

        public bool OnAcquireLockResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode, string errorDetails)
        {
            if (OnAcquireLockResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnAcquireLockResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnAcquireLockResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnAcquireLockResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnAcquireLockResult_lockName, lockName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnAcquireLockResult_errorCode, errorCode) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnAcquireLockResult_errorDetails, errorDetails) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRevokeLockResult_be_trigger = false;
        public UInt64 OnRevokeLockResult_requestId = 0;
        public string OnRevokeLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnRevokeLockResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public string OnRevokeLockResult_lockName = null;
        public RTM_ERROR_CODE OnRevokeLockResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnRevokeLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode)
        {
            OnRevokeLockResult_be_trigger = true;
            OnRevokeLockResult_requestId = requestId;
            OnRevokeLockResult_channelName = channelName;
            OnRevokeLockResult_channelType = channelType;
            OnRevokeLockResult_lockName = lockName;
            OnRevokeLockResult_errorCode = errorCode;
        }

        public bool OnRevokeLockResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, RTM_ERROR_CODE errorCode)
        {
            if (OnRevokeLockResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnRevokeLockResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnRevokeLockResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnRevokeLockResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnRevokeLockResult_lockName, lockName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnRevokeLockResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnGetLocksResult_be_trigger = false;
        public UInt64 OnGetLocksResult_requestId = 0;
        public string OnGetLocksResult_channelName = null;
        public RTM_CHANNEL_TYPE OnGetLocksResult_channelType = RTM_CHANNEL_TYPE.STREAM;
        public LockDetail[] OnGetLocksResult_lockDetailList = null;
        public UInt64 OnGetLocksResult_count = 0;
        public RTM_ERROR_CODE OnGetLocksResult_errorCode = Rtm.RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnGetLocksResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, LockDetail[] lockDetailList, UInt64 count, RTM_ERROR_CODE errorCode)
        {
            OnGetLocksResult_be_trigger = true;
            OnGetLocksResult_requestId = requestId;
            OnGetLocksResult_channelName = channelName;
            OnGetLocksResult_channelType = channelType;
            OnGetLocksResult_lockDetailList = lockDetailList;
            OnGetLocksResult_count = count;
            OnGetLocksResult_errorCode = errorCode;
        }

        public bool OnGetLocksResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, LockDetail[] lockDetailList, UInt64 count, RTM_ERROR_CODE errorCode)
        {
            if (OnGetLocksResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnGetLocksResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnGetLocksResult_channelName, channelName) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_CHANNEL_TYPE>(OnGetLocksResult_channelType, channelType) == false)
            //    return false;
            //if (ParamsHelper.Compare<LockDetail[]>(OnGetLocksResult_lockDetailList, lockDetailList) == false)
            //    return false;
            //if (ParamsHelper.Compare<ulong>(OnGetLocksResult_count, count) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnGetLocksResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnWhoNowResult_be_trigger = false;
        public UInt64 OnWhoNowResult_requestId = 0;
        public UserState[] OnWhoNowResult_userStateList = null;
        public UInt64 OnWhoNowResult_count = 0;
        public string OnWhoNowResult_nextPage = null;
        public RTM_ERROR_CODE OnWhoNowResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnWhoNowResult(UInt64 requestId, UserState[] userStateList, UInt64 count, string nextPage, RTM_ERROR_CODE errorCode)
        {
            OnWhoNowResult_be_trigger = true;
            OnWhoNowResult_requestId = requestId;
            OnWhoNowResult_userStateList = userStateList;
            OnWhoNowResult_count = count;
            OnWhoNowResult_nextPage = nextPage;
            OnWhoNowResult_errorCode = errorCode;
        }

        public bool OnWhoNowResultPassed(UInt64 requestId, UserState[] userStateList, UInt64 count, string nextPage, RTM_ERROR_CODE errorCode)
        {
            if (OnWhoNowResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnWhoNowResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<ulong>(OnWhoNowResult_count, count) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnWhoNowResult_nextPage, nextPage) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnWhoNowResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////
        public bool OnGetOnlineUsersResult_be_trigger = false;
        public UInt64 OnGetOnlineUsersResult_requestId = 0;
        public UserState[] OnGetOnlineUsersResult_userStateList = null;
        public UInt64 OnGetOnlineUsersResult_count = 0;
        public string OnGetOnlineUsersResult_nextPage = null;
        public RTM_ERROR_CODE OnGetOnlineUsersResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnGetOnlineUsersResult(UInt64 requestId, UserState[] userStateList, UInt64 count, string nextPage, RTM_ERROR_CODE errorCode)
        {
            OnGetOnlineUsersResult_be_trigger = true;
            OnGetOnlineUsersResult_requestId = requestId;
            OnGetOnlineUsersResult_userStateList = userStateList;
            OnGetOnlineUsersResult_count = count;
            OnGetOnlineUsersResult_nextPage = nextPage;
            OnGetOnlineUsersResult_errorCode = errorCode;
        }

        public bool OnGetOnlineUsersResultPassed(UInt64 requestId, UserState[] userStateList, UInt64 count, string nextPage, RTM_ERROR_CODE errorCode)
        {
            if (OnGetOnlineUsersResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnGetOnlineUsersResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<ulong>(OnGetOnlineUsersResult_count, count) == false)
            //    return false;
            //if (ParamsHelper.Compare<string>(OnGetOnlineUsersResult_nextPage, nextPage) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnGetOnlineUsersResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnWhereNowResult_be_trigger = false;
        public UInt64 OnWhereNowResult_requestId = 0;
        public ChannelInfo[] OnWhereNowResult_channels = null;
        public UInt64 OnWhereNowResult_count = 0;
        public RTM_ERROR_CODE OnWhereNowResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnWhereNowResult(UInt64 requestId, ChannelInfo[] channels, UInt64 count, RTM_ERROR_CODE errorCode)
        {
            OnWhereNowResult_be_trigger = true;
            OnWhereNowResult_requestId = requestId;
            OnWhereNowResult_channels = channels;
            OnWhereNowResult_count = count;
            OnWhereNowResult_errorCode = errorCode;
        }

        public bool OnWhereNowResultPassed(UInt64 requestId, ChannelInfo[] channels, UInt64 count, RTM_ERROR_CODE errorCode)
        {
            if (OnWhereNowResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnWhereNowResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<ChannelInfo[]>(OnWhereNowResult_channels, channels) == false)
            //    return false;
            //if (ParamsHelper.Compare<ulong>(OnWhereNowResult_count, count) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnWhereNowResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnGetUserChannelsResult_be_trigger = false;
        public UInt64 OnGetUserChannelsResult_requestId = 0;
        public ChannelInfo[] OnGetUserChannelsResult_channels = null;
        public UInt64 OnGetUserChannelsResult_count = 0;
        public RTM_ERROR_CODE OnGetUserChannelsResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnGetUserChannelsResult(UInt64 requestId, ChannelInfo[] channels, UInt64 count, RTM_ERROR_CODE errorCode)
        {
            OnGetUserChannelsResult_be_trigger = true;
            OnGetUserChannelsResult_requestId = requestId;
            OnGetUserChannelsResult_channels = channels;
            OnGetUserChannelsResult_count = count;
            OnGetUserChannelsResult_errorCode = errorCode;
        }

        public bool OnGetUserChannelsResultPassed(UInt64 requestId, ChannelInfo[] channels, UInt64 count, RTM_ERROR_CODE errorCode)
        {
            if (OnGetUserChannelsResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnGetUserChannelsResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<ChannelInfo[]>(OnGetUserChannelsResult_channels, channels) == false)
            //    return false;
            //if (ParamsHelper.Compare<ulong>(OnGetUserChannelsResult_count, count) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnGetUserChannelsResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////




        public bool OnPresenceSetStateResult_be_trigger = false;
        public UInt64 OnPresenceSetStateResult_requestId = 0;
        public RTM_ERROR_CODE OnPresenceSetStateResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnPresenceSetStateResult(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            OnPresenceSetStateResult_be_trigger = true;
            OnPresenceSetStateResult_requestId = requestId;
            OnPresenceSetStateResult_errorCode = errorCode;
        }

        public bool OnPresenceSetStateResultPassed(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            if (OnPresenceSetStateResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnPresenceSetStateResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnPresenceSetStateResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPresenceRemoveStateResult_be_trigger = false;
        public UInt64 OnPresenceRemoveStateResult_requestId = 0;
        public RTM_ERROR_CODE OnPresenceRemoveStateResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnPresenceRemoveStateResult(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            OnPresenceRemoveStateResult_be_trigger = true;
            OnPresenceRemoveStateResult_requestId = requestId;
            OnPresenceRemoveStateResult_errorCode = errorCode;
        }

        public bool OnPresenceRemoveStateResultPassed(UInt64 requestId, RTM_ERROR_CODE errorCode)
        {
            if (OnPresenceRemoveStateResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnPresenceRemoveStateResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnPresenceRemoveStateResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPresenceGetStateResult_be_trigger = false;
        public UInt64 OnPresenceGetStateResult_requestId = 0;
        public UserState OnPresenceGetStateResult_state = null;
        public RTM_ERROR_CODE OnPresenceGetStateResult_errorCode = RTM_ERROR_CODE.NOT_INITIALIZED;

        public override void OnPresenceGetStateResult(UInt64 requestId, UserState state, RTM_ERROR_CODE errorCode)
        {
            OnPresenceGetStateResult_be_trigger = true;
            OnPresenceGetStateResult_requestId = requestId;
            OnPresenceGetStateResult_state = state;
            OnPresenceGetStateResult_errorCode = errorCode;
        }

        public bool OnPresenceGetStateResultPassed(UInt64 requestId, UserState state, RTM_ERROR_CODE errorCode)
        {
            if (OnPresenceGetStateResult_be_trigger == false)
                return false;

            //if (ParamsHelper.Compare<ulong>(OnPresenceGetStateResult_requestId, requestId) == false)
            //    return false;
            //if (ParamsHelper.Compare<UserState>(OnPresenceGetStateResult_state, state) == false)
            //    return false;
            //if (ParamsHelper.Compare<RTM_ERROR_CODE>(OnPresenceGetStateResult_errorCode, errorCode) == false)
            //    return false;

            return true;
        }

        ///////////////////////////////////


    }
}