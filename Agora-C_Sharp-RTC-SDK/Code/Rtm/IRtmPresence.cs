using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{

    ///
    /// <summary>
    /// The IRtmPresence class.
    /// This class provides the rtm presence methods that can be invoked by your app.
    /// </summary>
    ///
    public interface IRtmPresence
    {

        ///
        /// <summary>
        /// To query who joined this channel
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="options"> The query option.</param>
        ///
        /// <returns>
        /// The result of whoNow
        /// </returns>
        ///
        Task<RtmResult<WhoNowResult>> WhoNowAsync(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options);

        ///
        /// <summary>
        /// To query which channels the user joined
        /// </summary>
        ///
        /// <param name="userId"> The id of the user.</param>
        ///
        /// <returns>
        /// The result of WhereNow
        /// </returns>
        ///
        Task<RtmResult<WhereNowResult>> WhereNowAsync(string userId);

        ///
        /// <summary>
        /// To query who joined this channel
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="options"> The query option.</param>
        ///
        /// <returns>
        ///
        /// - 0: Success.
        /// - < 0: Failure.
        /// </returns>
        ///
        Task<RtmResult<GetOnlineUsersResult>> GetOnlineUsersAsync(string channelName, RTM_CHANNEL_TYPE channelType, GetOnlineUsersOptions options);

        ///
        /// <summary>
        /// To query which channels the user joined
        /// </summary>
        ///
        /// <param name="userId"> The id of the user.</param>
        ///
        /// <returns>
        ///
        /// - 0: Success.
        /// - < 0: Failure.
        /// </returns>
        ///
        Task<RtmResult<GetUserChannelsResult>> GetUserChannelsAsync(string userId);

        ///
        /// <summary>
        /// Set user state
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="items"> The states item of user.</param>
        ///
        /// <returns>
        /// The result of SetState
        /// </returns>
        ///
        Task<RtmResult<SetStateResult>> SetStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items);

        ///
        /// <summary>
        /// Delete user state
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="keys"> The keys of state item.</param>
        ///
        /// <returns>
        /// The result of SetState
        /// </returns>
        ///
        Task<RtmResult<RemoveStateResult>> RemoveStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys);

        ///
        /// <summary>
        /// Get user state
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="userId"> The id of the user.</param>
        ///
        /// <returns>
        /// The result of GetState
        /// </returns>
        ///
        Task<RtmResult<GetStateResult>> GetStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, string userId);
    }
}
