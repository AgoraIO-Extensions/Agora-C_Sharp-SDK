namespace Agora.Rtm
{
    public abstract class IRtmEventHandler
    {
        public virtual void OnMessageEvent(MessageEvent @event) {}

        public virtual void OnPresenceEvent(PresenceEvent @event) {}

        public virtual void OnJoinResult(string channelName, string userId, STREAM_CHANNEL_ERROR_CODE errorCode) {}

        public virtual void OnLeaveResult(string channelName, string userId, STREAM_CHANNEL_ERROR_CODE errorCode) {}

        public virtual void OnTopicCreateResult(string channelName, string userId, string topic, string meta, STREAM_CHANNEL_ERROR_CODE errorCode) {}

        public virtual void OnTopicDestroyResult(string channelName, string userId, string topic, string meta, STREAM_CHANNEL_ERROR_CODE errorCode) {}

        public virtual void OnTopicSubscribed(string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, STREAM_CHANNEL_ERROR_CODE errorCode) {}

        public virtual void OnTopicUnsubscribed(string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, STREAM_CHANNEL_ERROR_CODE errorCode) {}

        public virtual void OnConnectionStateChange(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason) {}
    }
}