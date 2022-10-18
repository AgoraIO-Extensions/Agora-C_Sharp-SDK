namespace Agora.Rtm
{
    public abstract class IStreamChannel
    {
        public abstract int Join(JoinChannelOptions options);

        public abstract int Leave();

        public abstract string GetChannelName();

        public abstract int JoinTopic(string topic, JoinTopicOptions options);

        public abstract int PublishTopicMessage(string topic, byte[] message);

        public abstract int PublishTopicMessage(string topic, string message);

        public abstract int LeaveTopic(string topic);

        public abstract int SubscribeTopic(string topic, TopicOptions options);

        public abstract int UnsubscribeTopic(string topic, TopicOptions options);

        public abstract int GetSubscribedUserList(string topic, ref UserList users);

        public abstract int Release();
    }
}