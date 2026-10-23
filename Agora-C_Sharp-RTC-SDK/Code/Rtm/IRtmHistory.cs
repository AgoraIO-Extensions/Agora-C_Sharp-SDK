using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    ///
    /// <summary>
    /// The IRtmHistory class.
    /// This class provides the rtm history methods that can be invoked by your app.
    /// </summary>
    ///
    public interface IRtmHistory
    {
        ///
        /// <summary>
        /// gets history messages in the channel.
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="options"> The query options.</param>
        ///
        /// <returns>
        /// 
        /// the result of GetMessages
        /// </returns>
        ///
        Task<RtmResult<GetHistoryMessagesResult>> GetMessages(string channelName, RTM_CHANNEL_TYPE channelType, GetHistoryMessagesOptions options);

    }
}
