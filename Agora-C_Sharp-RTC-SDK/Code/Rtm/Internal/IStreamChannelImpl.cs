using System;
namespace Agora.Rtm.Internal
{
    interface IStreamChannelImpl
    {
        int Join(string channelName, JoinChannelOptions options, ref UInt64 requestId);

        int RenewToken(string channelName, string token);

        int Leave(string channelName, ref UInt64 requestId);

        int JoinTopic(string channelName, string topic, JoinTopicOptions options, ref UInt64 requestId);

        int PublishTopicMessage(string channelName, string topic, byte[] message, int length, Internal.TopicMessageOptions option);

        int LeaveTopic(string channelName, string topic, ref UInt64 requestId);

        int SubscribeTopic(string channelName, string topic, TopicOptions options, ref UInt64 requestId);

        int UnsubscribeTopic(string channelName, string topic, TopicOptions options);

        int GetSubscribedUserList(string channelName, string topic, ref Internal.UserList users);

        int Release(string channelName);
    }
}
