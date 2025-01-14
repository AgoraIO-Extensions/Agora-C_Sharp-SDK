using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    /**
     * The IRtmHistory class.
     *
     * This class provides the rtm history methods that can be invoked by your app.
     */
    public interface IRtmHistory
    {
        /**
    * gets history messages in the channel.
    *
    * @param [in] channelName The name of the channel.
    * @param [in] channelType The type of the channel.
    * @param [in] options The query options.
    * @return
    * the result of GetMessages
    */
        Task<RtmResult<GetHistoryMessagesResult>> GetMessages(string channelName, RTM_CHANNEL_TYPE channelType, GetHistoryMessagesOptions options);

    }
}
