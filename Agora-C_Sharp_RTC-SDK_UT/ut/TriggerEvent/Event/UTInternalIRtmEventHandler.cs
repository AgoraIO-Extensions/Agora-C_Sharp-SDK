
using System;
using Agora.Rtc;
namespace Agora.Rtm
{
    public class UTInternalRtmEventHandler : Internal.IRtmEventHandler
    {

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

            if (ParamsHelper.compareMessageEvent(OnMessageEvent_event, @event) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPresenceEvent_be_trigger = false;
        public PresenceEvent OnPresenceEvent_event = null;

        public override void OnPresenceEvent(PresenceEvent @event)
        {
            OnPresenceEvent_be_trigger = true;
            OnPresenceEvent_event = @event;
        }

        public bool OnPresenceEventPassed(PresenceEvent @event)
        {
            if (OnPresenceEvent_be_trigger == false)
                return false;

            if (ParamsHelper.comparePresenceEvent(OnPresenceEvent_event, @event) == false)
                return false;

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

            if (ParamsHelper.compareTopicEvent(OnTopicEvent_event, @event) == false)
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

            if (ParamsHelper.compareLockEvent(OnLockEvent_event, @event) == false)
                return false;

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

            if (ParamsHelper.compareStorageEvent(OnStorageEvent_event, @event) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnJoinResult_be_trigger = false;
        public UInt64 OnJoinResult_requestId = 0;
        public string OnJoinResult_channelName = null;
        public string OnJoinResult_userId = null;
        public RTM_ERROR_CODE OnJoinResult_errorCode = Rtm.RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnJoinResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnJoinResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareString(OnJoinResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnJoinResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLeaveResult_be_trigger = false;
        public UInt64 OnLeaveResult_requestId = 0;
        public string OnLeaveResult_channelName = null;
        public string OnLeaveResult_userId = null;
        public RTM_ERROR_CODE OnLeaveResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnLeaveResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnLeaveResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareString(OnLeaveResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnLeaveResult_errorCode, errorCode) == false)
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
        public RTM_ERROR_CODE OnJoinTopicResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnJoinTopicResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnJoinTopicResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareString(OnJoinTopicResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareString(OnJoinTopicResult_topic, topic) == false)
                return false;
            if (ParamsHelper.compareString(OnJoinTopicResult_meta, meta) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnJoinTopicResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLeaveTopicResult_be_trigger = false;
        public UInt64 OnLeaveTopicResult_requestId = 0;
        public string OnLeaveTopicResult_channelName = null;
        public string OnLeaveTopicResult_userId = null;
        public string OnLeaveTopicResult_topic = null;
        public string OnLeaveTopicResult_meta = null;
        public RTM_ERROR_CODE OnLeaveTopicResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnLeaveTopicResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnLeaveTopicResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareString(OnLeaveTopicResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareString(OnLeaveTopicResult_topic, topic) == false)
                return false;
            if (ParamsHelper.compareString(OnLeaveTopicResult_meta, meta) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnLeaveTopicResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSubscribeTopicResult_be_trigger = false;
        public UInt64 OnSubscribeTopicResult_requestId = 0;
        public string OnSubscribeTopicResult_channelName = null;
        public string OnSubscribeTopicResult_userId = null;
        public string OnSubscribeTopicResult_topic = null;
        public UserList OnSubscribeTopicResult_succeedUsers = null;
        public UserList OnSubscribeTopicResult_failedUsers = null;
        public RTM_ERROR_CODE OnSubscribeTopicResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

        public override void OnSubscribeTopicResult(UInt64 requestId, string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, RTM_ERROR_CODE errorCode)
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

        public bool OnSubscribeTopicResultPassed(UInt64 requestId, string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, RTM_ERROR_CODE errorCode)
        {
            if (OnSubscribeTopicResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareUlong(OnSubscribeTopicResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnSubscribeTopicResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareString(OnSubscribeTopicResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareString(OnSubscribeTopicResult_topic, topic) == false)
                return false;
            if (ParamsHelper.compareUserList(OnSubscribeTopicResult_succeedUsers, succeedUsers) == false)
                return false;
            if (ParamsHelper.compareUserList(OnSubscribeTopicResult_failedUsers, failedUsers) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnSubscribeTopicResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnConnectionStateChange_be_trigger = false;
        public string OnConnectionStateChange_channelName = null;
        public RTM_CONNECTION_STATE OnConnectionStateChange_state = RTM_CONNECTION_STATE.RTM_CONNECTION_STATE_CONNECTING;
        public RTM_CONNECTION_CHANGE_REASON OnConnectionStateChange_reason = RTM_CONNECTION_CHANGE_REASON.RTM_CONNECTION_CHANGED_BANNED_BY_SERVER;

        public override void OnConnectionStateChange(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason)
        {
            OnConnectionStateChange_be_trigger = true;
            OnConnectionStateChange_channelName = channelName;
            OnConnectionStateChange_state = state;
            OnConnectionStateChange_reason = reason;
        }

        public bool OnConnectionStateChangePassed(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason)
        {
            if (OnConnectionStateChange_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnConnectionStateChange_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CONNECTION_STATE(OnConnectionStateChange_state, state) == false)
                return false;
            if (ParamsHelper.compareRTM_CONNECTION_CHANGE_REASON(OnConnectionStateChange_reason, reason) == false)
                return false;

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

            if (ParamsHelper.compareString(OnTokenPrivilegeWillExpire_channelName, channelName) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSubscribeResult_be_trigger = false;
        public UInt64 OnSubscribeResult_requestId = 0;
        public string OnSubscribeResult_channelName = null;
        public RTM_ERROR_CODE OnSubscribeResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnSubscribeResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnSubscribeResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnSubscribeResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPublishResult_be_trigger = false;
        public UInt64 OnPublishResult_requestId = 0;
        public RTM_ERROR_CODE OnPublishResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnPublishResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnPublishResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLoginResult_be_trigger = false;
        public RTM_ERROR_CODE OnLoginResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

        public override void OnLoginResult(RTM_ERROR_CODE errorCode)
        {
            OnLoginResult_be_trigger = true;
            OnLoginResult_errorCode = errorCode;
        }

        public bool OnLoginResultPassed(RTM_ERROR_CODE errorCode)
        {
            if (OnLoginResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareRTM_ERROR_CODE(OnLoginResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSetChannelMetadataResult_be_trigger = false;
        public UInt64 OnSetChannelMetadataResult_requestId = 0;
        public string OnSetChannelMetadataResult_channelName = null;
        public RTM_CHANNEL_TYPE OnSetChannelMetadataResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public RTM_ERROR_CODE OnSetChannelMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnSetChannelMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnSetChannelMetadataResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnSetChannelMetadataResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnSetChannelMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnUpdateChannelMetadataResult_be_trigger = false;
        public UInt64 OnUpdateChannelMetadataResult_requestId = 0;
        public string OnUpdateChannelMetadataResult_channelName = null;
        public RTM_CHANNEL_TYPE OnUpdateChannelMetadataResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public RTM_ERROR_CODE OnUpdateChannelMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnUpdateChannelMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnUpdateChannelMetadataResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnUpdateChannelMetadataResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnUpdateChannelMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRemoveChannelMetadataResult_be_trigger = false;
        public UInt64 OnRemoveChannelMetadataResult_requestId = 0;
        public string OnRemoveChannelMetadataResult_channelName = null;
        public RTM_CHANNEL_TYPE OnRemoveChannelMetadataResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public RTM_ERROR_CODE OnRemoveChannelMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnRemoveChannelMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnRemoveChannelMetadataResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnRemoveChannelMetadataResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnRemoveChannelMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnGetChannelMetadataResult_be_trigger = false;
        public UInt64 OnGetChannelMetadataResult_requestId = 0;
        public string OnGetChannelMetadataResult_channelName = null;
        public RTM_CHANNEL_TYPE OnGetChannelMetadataResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public RtmMetadata OnGetChannelMetadataResult_data = null;
        public RTM_ERROR_CODE OnGetChannelMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

        public override void OnGetChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, RTM_ERROR_CODE errorCode)
        {
            OnGetChannelMetadataResult_be_trigger = true;
            OnGetChannelMetadataResult_requestId = requestId;
            OnGetChannelMetadataResult_channelName = channelName;
            OnGetChannelMetadataResult_channelType = channelType;
            OnGetChannelMetadataResult_data = data;
            OnGetChannelMetadataResult_errorCode = errorCode;
        }

        public bool OnGetChannelMetadataResultPassed(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, RTM_ERROR_CODE errorCode)
        {
            if (OnGetChannelMetadataResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareUlong(OnGetChannelMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnGetChannelMetadataResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnGetChannelMetadataResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareRtmMetadata(OnGetChannelMetadataResult_data, data) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnGetChannelMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSetUserMetadataResult_be_trigger = false;
        public UInt64 OnSetUserMetadataResult_requestId = 0;
        public string OnSetUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnSetUserMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnSetUserMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnSetUserMetadataResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnSetUserMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnUpdateUserMetadataResult_be_trigger = false;
        public UInt64 OnUpdateUserMetadataResult_requestId = 0;
        public string OnUpdateUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnUpdateUserMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnUpdateUserMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnUpdateUserMetadataResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnUpdateUserMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRemoveUserMetadataResult_be_trigger = false;
        public UInt64 OnRemoveUserMetadataResult_requestId = 0;
        public string OnRemoveUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnRemoveUserMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnRemoveUserMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnRemoveUserMetadataResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnRemoveUserMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnGetUserMetadataResult_be_trigger = false;
        public UInt64 OnGetUserMetadataResult_requestId = 0;
        public string OnGetUserMetadataResult_userId = null;
        public RtmMetadata OnGetUserMetadataResult_data = null;
        public RTM_ERROR_CODE OnGetUserMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

        public override void OnGetUserMetadataResult(UInt64 requestId, string userId, RtmMetadata data, RTM_ERROR_CODE errorCode)
        {
            OnGetUserMetadataResult_be_trigger = true;
            OnGetUserMetadataResult_requestId = requestId;
            OnGetUserMetadataResult_userId = userId;
            OnGetUserMetadataResult_data = data;
            OnGetUserMetadataResult_errorCode = errorCode;
        }

        public bool OnGetUserMetadataResultPassed(UInt64 requestId, string userId, RtmMetadata data, RTM_ERROR_CODE errorCode)
        {
            if (OnGetUserMetadataResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareUlong(OnGetUserMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnGetUserMetadataResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareRtmMetadata(OnGetUserMetadataResult_data, data) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnGetUserMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSubscribeUserMetadataResult_be_trigger = false;
        public UInt64 OnSubscribeUserMetadataResult_requestId = 0;
        public string OnSubscribeUserMetadataResult_userId = null;
        public RTM_ERROR_CODE OnSubscribeUserMetadataResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnSubscribeUserMetadataResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnSubscribeUserMetadataResult_userId, userId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnSubscribeUserMetadataResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSetLockResult_be_trigger = false;
        public UInt64 OnSetLockResult_requestId = 0;
        public string OnSetLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnSetLockResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public string OnSetLockResult_lockName = null;
        public RTM_ERROR_CODE OnSetLockResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnSetLockResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnSetLockResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnSetLockResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareString(OnSetLockResult_lockName, lockName) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnSetLockResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRemoveLockResult_be_trigger = false;
        public UInt64 OnRemoveLockResult_requestId = 0;
        public string OnRemoveLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnRemoveLockResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public string OnRemoveLockResult_lockName = null;
        public RTM_ERROR_CODE OnRemoveLockResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnRemoveLockResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnRemoveLockResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnRemoveLockResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareString(OnRemoveLockResult_lockName, lockName) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnRemoveLockResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnReleaseLockResult_be_trigger = false;
        public UInt64 OnReleaseLockResult_requestId = 0;
        public string OnReleaseLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnReleaseLockResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public string OnReleaseLockResult_lockName = null;
        public RTM_ERROR_CODE OnReleaseLockResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnReleaseLockResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnReleaseLockResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnReleaseLockResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareString(OnReleaseLockResult_lockName, lockName) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnReleaseLockResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnAcquireLockResult_be_trigger = false;
        public UInt64 OnAcquireLockResult_requestId = 0;
        public string OnAcquireLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnAcquireLockResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public string OnAcquireLockResult_lockName = null;
        public RTM_ERROR_CODE OnAcquireLockResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;
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

            if (ParamsHelper.compareUlong(OnAcquireLockResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnAcquireLockResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnAcquireLockResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareString(OnAcquireLockResult_lockName, lockName) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnAcquireLockResult_errorCode, errorCode) == false)
                return false;
            if (ParamsHelper.compareString(OnAcquireLockResult_errorDetails, errorDetails) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRevokeLockResult_be_trigger = false;
        public UInt64 OnRevokeLockResult_requestId = 0;
        public string OnRevokeLockResult_channelName = null;
        public RTM_CHANNEL_TYPE OnRevokeLockResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public string OnRevokeLockResult_lockName = null;
        public RTM_ERROR_CODE OnRevokeLockResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnRevokeLockResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnRevokeLockResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnRevokeLockResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareString(OnRevokeLockResult_lockName, lockName) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnRevokeLockResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnGetLocksResult_be_trigger = false;
        public UInt64 OnGetLocksResult_requestId = 0;
        public string OnGetLocksResult_channelName = null;
        public RTM_CHANNEL_TYPE OnGetLocksResult_channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
        public LockDetail[] OnGetLocksResult_lockDetailList = null;
        public UInt64 OnGetLocksResult_count = 0;
        public RTM_ERROR_CODE OnGetLocksResult_errorCode = Rtm.RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnGetLocksResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnGetLocksResult_channelName, channelName) == false)
                return false;
            if (ParamsHelper.compareRTM_CHANNEL_TYPE(OnGetLocksResult_channelType, channelType) == false)
                return false;
            if (ParamsHelper.compareLockDetailArray (OnGetLocksResult_lockDetailList, lockDetailList) == false)
                return false;
            if (ParamsHelper.compareUlong(OnGetLocksResult_count, count) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnGetLocksResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnWhoNowResult_be_trigger = false;
        public UInt64 OnWhoNowResult_requestId = 0;
        public UserState[] OnWhoNowResult_userStateList = null;
        public UInt64 OnWhoNowResult_count = 0;
        public string OnWhoNowResult_nextPage = null;
        public RTM_ERROR_CODE OnWhoNowResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnWhoNowResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareUserStateArray(OnWhoNowResult_userStateList, userStateList) == false)
                return false;
            if (ParamsHelper.compareUlong(OnWhoNowResult_count, count) == false)
                return false;
            if (ParamsHelper.compareString(OnWhoNowResult_nextPage, nextPage) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnWhoNowResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnWhereNowResult_be_trigger = false;
        public UInt64 OnWhereNowResult_requestId = 0;
        public ChannelInfo[] OnWhereNowResult_channels = null;
        public UInt64 OnWhereNowResult_count = 0;
        public RTM_ERROR_CODE OnWhereNowResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnWhereNowResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareChannelInfoArray(OnWhereNowResult_channels, channels) == false)
                return false;
            if (ParamsHelper.compareUlong(OnWhereNowResult_count, count) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnWhereNowResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPresenceSetStateResult_be_trigger = false;
        public UInt64 OnPresenceSetStateResult_requestId = 0;
        public RTM_ERROR_CODE OnPresenceSetStateResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnPresenceSetStateResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnPresenceSetStateResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPresenceRemoveStateResult_be_trigger = false;
        public UInt64 OnPresenceRemoveStateResult_requestId = 0;
        public RTM_ERROR_CODE OnPresenceRemoveStateResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnPresenceRemoveStateResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnPresenceRemoveStateResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPresenceGetStateResult_be_trigger = false;
        public UInt64 OnPresenceGetStateResult_requestId = 0;
        public UserState OnPresenceGetStateResult_state = null;
        public RTM_ERROR_CODE OnPresenceGetStateResult_errorCode = RTM_ERROR_CODE.RTM_ERROR_NOT_INITIALIZED;

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

            if (ParamsHelper.compareUlong(OnPresenceGetStateResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareUserState(OnPresenceGetStateResult_state, state) == false)
                return false;
            if (ParamsHelper.compareRTM_ERROR_CODE(OnPresenceGetStateResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


    }
}