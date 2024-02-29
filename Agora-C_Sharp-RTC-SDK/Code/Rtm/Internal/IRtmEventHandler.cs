using System;

namespace Agora.Rtm.Internal
{
    public abstract class IRtmEventHandler
    {
        public virtual void OnMessageEvent(MessageEvent @event) { }

        public virtual void OnPresenceEvent(PresenceEvent @event) { }

        public virtual void OnTopicEvent(TopicEvent @event) { }

        public virtual void OnLockEvent(LockEvent @event) { }

        public virtual void OnStorageEvent(StorageEvent @event) { }

        public virtual void OnJoinResult(UInt64 requestId, string channelName, string userId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnLeaveResult(UInt64 requestId, string channelName, string userId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnJoinTopicResult(UInt64 requestId, string channelName, string userId, string topic, string meta, RTM_ERROR_CODE errorCode) { }

        public virtual void OnLeaveTopicResult(UInt64 requestId, string channelName, string userId, string topic, string meta, RTM_ERROR_CODE errorCode) { }

        public virtual void OnSubscribeTopicResult(UInt64 requestId, string channelName, string userId, string topic,
                                                   UserList succeedUsers, UserList failedUsers, RTM_ERROR_CODE errorCode)
        {
        }

        public virtual void OnConnectionStateChanged(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason) { }

        public virtual void OnTokenPrivilegeWillExpire(string channelName) { }

        public virtual void OnSubscribeResult(UInt64 requestId, string channelName, RTM_ERROR_CODE errorCode) { }

        public virtual void OnPublishResult(UInt64 requestId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnLoginResult(RTM_ERROR_CODE errorCode) { }

        public virtual void OnSetChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode) { }

        public virtual void OnUpdateChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode) { }

        public virtual void OnRemoveChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RTM_ERROR_CODE errorCode) { }

        public virtual void OnGetChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data,
                                                       RTM_ERROR_CODE errorCode)
        {
        }

        public virtual void OnSetUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnUpdateUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnRemoveUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnGetUserMetadataResult(UInt64 requestId, string userId, RtmMetadata data, RTM_ERROR_CODE errorCode) { }

        public virtual void OnSubscribeUserMetadataResult(UInt64 requestId, string userId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnSetLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType,
                                            string lockName, RTM_ERROR_CODE errorCode)
        {
        }

        public virtual void OnRemoveLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType,
                                               string lockName, RTM_ERROR_CODE errorCode)
        {
        }

        public virtual void OnReleaseLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType,
                                                string lockName, RTM_ERROR_CODE errorCode)
        {
        }

        public virtual void OnAcquireLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType,
                                                string lockName, RTM_ERROR_CODE errorCode, string errorDetails)
        {
        }

        public virtual void OnRevokeLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType,
                                               string lockName, RTM_ERROR_CODE errorCode)
        {
        }

        public virtual void OnGetLocksResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType,
                                             LockDetail[] lockDetailList, UInt64 count, RTM_ERROR_CODE errorCode)
        {
        }

        public virtual void OnWhoNowResult(UInt64 requestId, UserState[] userStateList, UInt64 count, string nextPage, RTM_ERROR_CODE errorCode) { }

        public virtual void OnWhereNowResult(UInt64 requestId, ChannelInfo[] channels, UInt64 count, RTM_ERROR_CODE errorCode) { }

        public virtual void OnGetOnlineUsersResult(UInt64 requestId, UserState[] userStateList, UInt64 count, string nextPage, RTM_ERROR_CODE errorCode) { }

        public virtual void OnGetUserChannelsResult(UInt64 requestId, ChannelInfo[] channels, UInt64 count, RTM_ERROR_CODE errorCode) { }

        public virtual void OnPresenceSetStateResult(UInt64 requestId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnPresenceRemoveStateResult(UInt64 requestId, RTM_ERROR_CODE errorCode) { }

        public virtual void OnPresenceGetStateResult(UInt64 requestId, UserState state, RTM_ERROR_CODE errorCode) { }
    }
}