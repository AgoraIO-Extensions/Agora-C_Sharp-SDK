
using System.Threading.Tasks;
namespace Agora.Rtm
{
    /**
    * The IStreamChannel class.
    *
    * This class provides the stream channel methods that can be invoked by your app.
    */
    public interface IStreamChannel
    {
        /**
        * Join the channel.
        *
        * @param [in] options join channel options.
        * 
        * @return The result of Join
        */
        Task<RtmResult<JoinResult>> JoinAsync(JoinChannelOptions options);

        /**
        * Renews the token. Once a token is enabled and used, it expires after a certain period of time.
        * You should generate a new token on your server, call this method to renew it.
        *
        * @param [in] token Token used renew.
        * 
        * @return The result of RenewToken
        */
        Task<RtmResult<RenewTokenResult>> RenewTokenAsync(string token);

        /**
        * Leave the channel.
        * 
        * @return The result of Leave
        */
        Task<RtmResult<LeaveResult>> LeaveAsync();

        /**
        * Return the channel name of this stream channel.
        * 
        * @return The name of channel
        */
        string GetChannelName();

        /**
        * Join a topic.
        *
        * @param [in] topic The name of the topic.
        * @param [in] options The options of the topic.
        * 
        * @return The name of JoinTopic
        */
        Task<RtmResult<JoinTopicResult>> JoinTopicAsync(string topic, JoinTopicOptions options);

        /**
        * Publish a message in the topic.
        *
        * @param [in] topic The name of the topic.
        * @param [in] message The content of the message.
        * @param [in] length The length of the message.
        * 
        * @return The name of PublishTopicMessage
        */
        Task<RtmResult<PublishTopicMessageResult>> PublishTopicMessageAsync(string topic, byte[] message, PublishOptions option);

        /**
        * Publish a message in the topic.
        *
        * @param [in] topic The name of the topic.
        * @param [in] message The content of the message.
        * @param [in] length The length of the message.
        * 
        * @return The name of PublishTopicMessage
        */
        Task<RtmResult<PublishTopicMessageResult>> PublishTopicMessageAsync(string topic, string message, PublishOptions option);

        /**
        * Leave the topic.
        *
        * @param [in] topic The name of the topic.
        * 
        * @return The name of LeaveTopic
        */
        Task<RtmResult<LeaveTopicResult>> LeaveTopicAsync(string topic);

        /**
        * Subscribe a topic.
        *
        * @param [in] topic The name of the topic.
        * @param [in] options The options of subscribe the topic.
        * 
        * @return The name of SubscribeTopic
        */
        Task<RtmResult<SubscribeTopicResult>> SubscribeTopicAsync(string topic, TopicOptions options);

        /**
        * Unsubscribe a topic.
        *
        * @param [in] topic The name of the topic.
        * 
        * @return The name of UnsubscribeTopic
        */
        Task<RtmResult<UnsubscribeTopicResult>> UnsubscribeTopicAsync(string topic, TopicOptions options);

        /**
        * Get subscribed user list
        *
        * @param [in] topic The name of the topic.
        * 
        * @return The name of GetSubscribedUserList
        */
        Task<RtmResult<GetSubscribedUserListResult>> GetSubscribedUserListAsync(string topic);

        /**
        * Release the stream channel instance.
        * 
        * @return The name of Dispose
        */
        RtmStatus Dispose();
    }
}