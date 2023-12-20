
using System.Threading.Tasks;
namespace Agora.Rtm
{
    ///
    /// <summary>
    /// The IStreamChannel class.
    /// This class provides the stream channel methods that can be invoked by your app.
    /// </summary>
    ///
    public interface IStreamChannel
    {
        ///
        /// <summary>
        /// Join the channel.
        /// </summary>
        ///
        /// <param name="options"> join channel options.</param>
        ///
        /// <returns>
        /// The result of Join
        /// </returns>
        ///
        Task<RtmResult<JoinResult>> JoinAsync(JoinChannelOptions options);

        ///
        /// <summary>
        /// Renews the token. Once a token is enabled and used, it expires after a certain period of time.
        /// You should generate a new token on your server, call this method to renew it.
        /// </summary>
        ///
        /// <param name="token"> New token.</param>
        ///
        /// <returns>
        /// The result of RenewToken
        /// </returns>
        ///
        Task<RtmResult<RenewTokenResult>> RenewTokenAsync(string token);

        ///
        /// <summary>
        /// Leave the channel.
        /// </summary>
        ///
        /// <returns>
        /// The result of Leave
        /// </returns>
        ///
        Task<RtmResult<LeaveResult>> LeaveAsync();

        ///
        /// <summary>
        /// Return the channel name of this stream channel.
        /// </summary>
        ///
        /// <returns>
        /// The name of channel
        /// </returns>
        ///
        string GetChannelName();

        ///
        /// <summary>
        /// Join a topic.
        /// </summary>
        ///
        /// <param name="topic"> The name of the topic.</param>
        /// <param name="options"> The options of the topic.</param>
        ///
        /// <returns>
        /// The name of JoinTopic
        /// </returns>
        ///
        Task<RtmResult<JoinTopicResult>> JoinTopicAsync(string topic, JoinTopicOptions options);

        ///
        /// <summary>
        /// Publish a message in the topic.
        /// </summary>
        ///
        /// <param name="topic"> The name of the topic.</param>
        /// <param name="message"> The content of the message.</param>
        /// <param name="option"> The option of the message.</param>
        ///
        /// <returns>
        /// The name of PublishTopicMessage
        /// </returns>
        ///
        Task<RtmResult<PublishTopicMessageResult>> PublishTopicMessageAsync(string topic, byte[] message, TopicMessageOptions option);

        ///
        /// <summary>
        /// Publish a message in the topic.
        /// </summary>
        ///
        /// <param name="topic"> The name of the topic.</param>
        /// <param name="message"> The content of the message.</param>
        /// <param name="option"> The option of the message.</param>
        ///
        /// <returns>
        /// The name of PublishTopicMessage
        /// </returns>
        ///
        Task<RtmResult<PublishTopicMessageResult>> PublishTopicMessageAsync(string topic, string message, TopicMessageOptions option);

        ///
        /// <summary>
        /// Leave the topic.
        /// </summary>
        ///
        /// <param name="topic"> The name of the topic.</param>
        ///
        /// <returns>
        /// The name of LeaveTopic
        /// </returns>
        ///
        Task<RtmResult<LeaveTopicResult>> LeaveTopicAsync(string topic);

        ///
        /// <summary>
        /// Subscribe a topic.
        /// </summary>
        ///
        /// <param name="topic"> The name of the topic.</param>
        /// <param name="options"> The options of subscribe the topic.</param>
        ///
        /// <returns>
        /// The name of SubscribeTopic
        /// </returns>
        ///
        Task<RtmResult<SubscribeTopicResult>> SubscribeTopicAsync(string topic, TopicOptions options);

        ///
        /// <summary>
        /// Unsubscribe a topic.
        /// </summary>
        ///
        /// <param name="topic"> The name of the topic.</param>
        ///
        /// <returns>
        /// The name of UnsubscribeTopic
        /// </returns>
        ///
        Task<RtmResult<UnsubscribeTopicResult>> UnsubscribeTopicAsync(string topic, TopicOptions options);

        ///
        /// <summary>
        /// Get subscribed user list
        /// </summary>
        ///
        /// <param name="topic"> The name of the topic.</param>
        ///
        /// <returns>
        /// The name of GetSubscribedUserList
        /// </returns>
        ///
        Task<RtmResult<GetSubscribedUserListResult>> GetSubscribedUserListAsync(string topic);

        ///
        /// <summary>
        /// Release the stream channel instance.
        /// </summary>
        ///
        /// <returns>
        /// The name of Dispose
        /// </returns>
        ///
        RtmStatus Dispose();
    }
}