using System.Threading.Tasks;
namespace Agora.Rtm
{

    public interface IRtmStorage
    {
        ///
        /// <summary>
        /// Set the metadata of a specified channel.
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE.</param>
        /// <param name="data"> Metadata data.</param>
        /// <param name="options"> The options of operate metadata.</param>
        /// <param name="lock"> lock for operate channel metadata.</param>
        ///
        /// <returns>
        /// The result of SetChannelMetadata
        /// </returns>
        ///
        Task<RtmResult<SetChannelMetadataResult>> SetChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        ///
        /// <summary>
        /// Update the metadata of a specified channel.
        /// </summary>
        ///
        /// <param name="channelName"> The channel Name of the specified channel.</param>
        /// <param name="channelType"> Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE.</param>
        /// <param name="data"> Metadata data.</param>
        /// <param name="options"> The options of operate metadata.</param>
        /// <param name="lock"> lock for operate channel metadata.</param>
        ///
        /// <returns>
        /// The result of UpdateChannelMetadata
        /// </returns>
        ///
        Task<RtmResult<UpdateChannelMetadataResult>> UpdateChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        ///
        /// <summary>
        /// Remove the metadata of a specified channel.
        /// </summary>
        ///
        /// <param name="channelName"> The channel Name of the specified channel.</param>
        /// <param name="channelType"> Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE.</param>
        /// <param name="data"> Metadata data.</param>
        /// <param name="options"> The options of operate metadata.</param>
        /// <param name="lock"> lock for operate channel metadata.</param>
        ///
        /// <returns>
        /// The result of RemoveChannelMetadata
        /// </returns>
        ///
        Task<RtmResult<RemoveChannelMetadataResult>> RemoveChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        ///
        /// <summary>
        /// Get the metadata of a specified channel.
        /// </summary>
        ///
        /// <param name="channelName"> The channel Name of the specified channel.</param>
        /// <param name="channelType"> Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE.</param>
        ///
        /// <returns>
        /// The result of GetChannelMetadata
        /// </returns>
        ///
        Task<RtmResult<GetChannelMetadataResult>> GetChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType);

        ///
        /// <summary>
        /// Set the metadata of a specified user.
        /// </summary>
        ///
        /// <param name="userId"> The user ID of the specified user.</param>
        /// <param name="data"> Metadata data.</param>
        /// <param name="options"> The options of operate metadata.</param>
        ///
        /// <returns>
        /// The result of SetUserMetadata
        /// </returns>
        ///
        Task<RtmResult<SetUserMetadataResult>> SetUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        ///
        /// <summary>
        /// Update the metadata of a specified user.
        /// </summary>
        ///
        /// <param name="userId"> The user ID of the specified user.</param>
        /// <param name="data"> Metadata data.</param>
        /// <param name="options"> The options of operate metadata.</param>
        ///
        /// <returns>
        /// The result of UpdateUserMetadata
        /// </returns>
        ///
        Task<RtmResult<UpdateUserMetadataResult>> UpdateUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        ///
        /// <summary>
        /// Remove the metadata of a specified user.
        /// </summary>
        ///
        /// <param name="userId"> The user ID of the specified user.</param>
        /// <param name="data"> Metadata data.</param>
        /// <param name="options"> The options of operate metadata.</param>
        ///
        /// <returns>
        /// The result of RemoveUserMetadata
        /// </returns>
        ///
        Task<RtmResult<RemoveUserMetadataResult>> RemoveUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        ///
        /// <summary>
        /// Get the metadata of a specified user.
        /// </summary>
        ///
        /// <param name="userId"> The user ID of the specified user.</param>
        ///
        /// <returns>
        /// The result of GetUserMetadata
        /// </returns>
        ///
        Task<RtmResult<GetUserMetadataResult>> GetUserMetadataAsync(string userId);

        ///
        /// <summary>
        /// Subscribe the metadata update event of a specified user.
        /// </summary>
        ///
        /// <param name="userId"> The user ID of the specified user.</param>
        ///
        /// <returns>
        /// The result of SubscribeUserMetadata
        /// </returns>
        ///
        Task<RtmResult<SubscribeUserMetadataResult>> SubscribeUserMetadataAsync(string userId);

        ///
        /// <summary>
        /// unsubscribe the metadata update event of a specified user.
        /// </summary>
        ///
        /// <param name="userId"> The user ID of the specified user.</param>
        ///
        /// <returns>
        /// The result of UnsubscribeUserMetadata
        /// </returns>
        ///
        Task<RtmResult<UnsubscribeUserMetadataResult>> UnsubscribeUserMetadataAsync(string userId);
    }

}
