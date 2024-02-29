using System;
namespace Agora.Rtm.Internal
{
    public abstract class IStreamChannel
    {
        public abstract int Join(JoinChannelOptions options, ref UInt64 requestId);

        public abstract int RenewToken(string token);

        public abstract int Leave(ref UInt64 requestId);

        public abstract string GetChannelName();

        public abstract int JoinTopic(string topic, JoinTopicOptions options, ref UInt64 requestId);

        public abstract int PublishTopicMessage(string topic, byte[] message, int length, TopicMessageOptions option);

        public abstract int PublishTopicMessage(string topic, string message, int length, TopicMessageOptions option);

        public abstract int LeaveTopic(string topic, ref UInt64 requestId);

        public abstract int SubscribeTopic(string topic, Internal.TopicOptions options, ref UInt64 requestId);

        public abstract int UnsubscribeTopic(string topic, Internal.TopicOptions options);

        public abstract int GetSubscribedUserList(string topic, ref UserList users);

        public abstract int Dispose();
    }
}