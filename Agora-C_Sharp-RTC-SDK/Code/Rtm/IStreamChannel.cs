namespace Agora.Rtm
{
    public abstract class IStreamChannel
    {
        public abstract int Join(JoinChannelOptions options);

        public abstract int Leave();

        public abstract string GetChannelName();

        public abstract int CreateTopic(string topic, CreateTopicOptions options);

        public abstract int PublishTopic(string topic, string message, uint length);

        public abstract int DestroyTopic(string topic);

        public abstract int SubscribeTopic(string topic, TopicOptions options);

        public abstract int UnsubscribeTopic(string topic, TopicOptions options);

        public abstract int GetSubscribedUserList(string topic, ref UserList[] users);
    }
}