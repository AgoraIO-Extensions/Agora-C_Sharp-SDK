using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{

    /**
     * The IRtmPresence class.
     *
     * This class provides the rtm presence methods that can be invoked by your app.
     */
    public interface IRtmPresence
    {

        /**
        * To query who joined this channel
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] options The query option.
        * 
        * @return The result of whoNow
        */
        Task<RtmResult<WhoNowResult>> WhoNowAsync(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options);

        /**
        * To query which channels the user joined
        *
        * @param [in] userId The id of the user.
        * 
        * @return The result of WhereNow
        * 
        */
        Task<RtmResult<WhereNowResult>> WhereNowAsync(string userId);


        /**
        * Set user state
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] items The states item of user.
        * 
        * @return The result of SetState
        * 
        */
        Task<RtmResult<SetStateResult>> SetStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items);

        /**
        * Delete user state
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] keys The keys of state item.
        * 
        * @return The result of SetState
        */
        Task<RtmResult<RemoveStateResult>> RemoveStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys);

        /**
        * Get user state
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] userId The id of the user.
        * 
        * @return The result of GetState
        */
        Task<RtmResult<GetStateResult>> GetStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, string userId);
    }
}
