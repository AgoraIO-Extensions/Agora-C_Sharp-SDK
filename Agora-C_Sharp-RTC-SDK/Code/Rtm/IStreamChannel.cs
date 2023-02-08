using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public interface IStreamChannel
    {
        Task<RtmResult<JoinResult>> Join(JoinChannelOptions options);

        Task<RtmResult<LeaveResult>> Leave();

        string GetChannelName();

        Task<RtmResult<JoinTopicResult>> JoinTopic(string topic, JoinTopicOptions options);

        int PublishTopicMessage(string topic, byte[] message, int length, PublishOptions option);

        int PublishTopicMessage(string topic, string message, int length, PublishOptions option);

        Task<RtmResult<LeaveTopicResult>> LeaveTopic(string topic);

        Task<RtmResult<SubscribeTopicResult>> SubscribeTopic(string topic, TopicOptions options);

        int UnsubscribeTopic(string topic, TopicOptions options);

        int GetSubscribedUserList(string topic, ref UserList users);

        int Dispose();
    }
}