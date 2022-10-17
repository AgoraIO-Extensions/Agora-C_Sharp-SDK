namespace Agora.Rtm
{
    public delegate void OnMessageEventHandler(MessageEvent @event);

    public delegate void OnPresenceEventHandler(PresenceEvent @event);

    public delegate void OnJoinResultHandler(string channelName, string userId, STREAM_CHANNEL_ERROR_CODE errorCode);

    public delegate void OnLeaveResultHandler(string channelName, string userId, STREAM_CHANNEL_ERROR_CODE errorCode);

    public delegate void OnJoinTopicResultHandler(string channelName, string userId, string topic, string meta, STREAM_CHANNEL_ERROR_CODE errorCode);

    public delegate void OnLeaveTopicResultHandler(string channelName, string userId, string topic, string meta, STREAM_CHANNEL_ERROR_CODE errorCode);

    public delegate void OnTopicSubscribedHandler(string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, STREAM_CHANNEL_ERROR_CODE errorCode);

    public delegate void OnTopicUnsubscribedHandler(string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, STREAM_CHANNEL_ERROR_CODE errorCode);

    public delegate void OnConnectionStateChangeHandler(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason);
    
    public class RtmEventHandler : IRtmEventHandler
    {
        public event OnMessageEventHandler EventOnMessageEvent;

        public event OnPresenceEventHandler EventOnPresenceEvent;

        public event OnJoinResultHandler EventOnJoinResult;

        public event OnLeaveResultHandler EventOnLeaveResult;

        public event OnJoinTopicResultHandler EventOnJoinTopicResult;

        public event OnLeaveTopicResultHandler EventOnLeaveTopicResult;

        public event OnTopicSubscribedHandler EventOnTopicSubscribed;

        public event OnTopicUnsubscribedHandler EventOnTopicUnsubscribed;

        public event OnConnectionStateChangeHandler EventOnConnectionStateChange;

        private static RtmEventHandler eventInstance = null;

        public static RtmEventHandler GetInstance()
        {
            return eventInstance ?? (eventInstance = new RtmEventHandler());
        }

        public override void OnMessageEvent(MessageEvent @event) 
        {
            if (EventOnMessageEvent == null) return;
            EventOnMessageEvent.Invoke(@event);
        }

        public override void OnPresenceEvent(PresenceEvent @event) 
        {
            if (EventOnPresenceEvent == null) return;
            EventOnPresenceEvent.Invoke(@event);
        }

        public override void OnJoinResult(string channelName, string userId, STREAM_CHANNEL_ERROR_CODE errorCode)
        {
            if (EventOnJoinResult == null) return;
            EventOnJoinResult.Invoke(channelName, userId, errorCode);
        }

        public override void OnLeaveResult(string channelName, string userId, STREAM_CHANNEL_ERROR_CODE errorCode) 
        {
            if (EventOnLeaveResult == null) return;
            EventOnLeaveResult.Invoke(channelName, userId, errorCode);
        }

        public override void OnTopicSubscribed(string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, STREAM_CHANNEL_ERROR_CODE errorCode) 
        {
            if (EventOnTopicSubscribed == null) return;
            EventOnTopicSubscribed.Invoke(channelName, userId, topic, succeedUsers, failedUsers, errorCode);
        }

        public override void OnTopicUnsubscribed(string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, STREAM_CHANNEL_ERROR_CODE errorCode) 
        {
            if (EventOnTopicUnsubscribed == null) return;
            EventOnTopicUnsubscribed.Invoke(channelName, userId, topic, succeedUsers, failedUsers, errorCode);
        }

        public override void OnConnectionStateChange(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason) 
        {
            if (EventOnConnectionStateChange == null) return;
            EventOnConnectionStateChange.Invoke(channelName, state, reason);
        }

        public override void OnJoinTopicResult(string channelName, string userId, string topic, string meta, STREAM_CHANNEL_ERROR_CODE errorCode)
        {
            if (EventOnJoinTopicResult == null) return;
            EventOnJoinTopicResult.Invoke(channelName, userId, topic, meta, errorCode);
        }

        public override void OnLeaveTopicResult(string channelName, string userId, string topic, string meta, STREAM_CHANNEL_ERROR_CODE errorCode)
        {
            if (EventOnLeaveTopicResult == null) return;
            EventOnLeaveTopicResult.Invoke(channelName, userId, topic, meta, errorCode);
        }
    }
}