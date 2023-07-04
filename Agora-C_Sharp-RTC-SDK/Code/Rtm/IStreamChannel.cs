using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public interface IStreamChannel
    {
        Task<RtmResult<JoinResult>> JoinAsync(JoinChannelOptions options);

        RtmStatus RenewToken(string token);

        Task<RtmResult<LeaveResult>> LeaveAsync();

        string GetChannelName();

        Task<RtmResult<JoinTopicResult>> JoinTopicAsync(string topic, JoinTopicOptions options);

        Task<RtmResult<PublishTopicMessageResult>> PublishTopicMessageAsync(string topic, byte[] message, PublishOptions option);

        Task<RtmResult<PublishTopicMessageResult>> PublishTopicMessageAsync(string topic, string message, PublishOptions option);

        Task<RtmResult<LeaveTopicResult>> LeaveTopicAsync(string topic);

        Task<RtmResult<SubscribeTopicResult>> SubscribeTopicAsync(string topic, TopicOptions options);

        Task<RtmResult<UnsubscribeTopicResult>> UnsubscribeTopicAsync(string topic, TopicOptions options);

        Task<RtmResult<GetSubscribedUserListResult>> GetSubscribedUserListAsync(string topic);

        RtmStatus Dispose();
    }
}