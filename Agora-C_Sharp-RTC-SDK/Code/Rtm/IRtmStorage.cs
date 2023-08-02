using System.Threading.Tasks;
namespace Agora.Rtm
{

    public interface IRtmStorage
    {
        /**
        * Set the metadata of a specified channel.
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE.
        * @param [in] data Metadata data.
        * @param [in] options The options of operate metadata.
        * @param [in] lock lock for operate channel metadata.
        * 
        * @return The result of SetChannelMetadata
        */
        Task<RtmResult<SetChannelMetadataResult>> SetChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        /**
        * Update the metadata of a specified channel.
        *
        * @param [in] channelName The channel Name of the specified channel.
        * @param [in] channelType Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE.
        * @param [in] data Metadata data.
        * @param [in] options The options of operate metadata.
        * @param [in] lock lock for operate channel metadata.
        * 
        * @return The result of UpdateChannelMetadata
        */
        Task<RtmResult<UpdateChannelMetadataResult>> UpdateChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        /**
        * Remove the metadata of a specified channel.
        *
        * @param [in] channelName The channel Name of the specified channel.
        * @param [in] channelType Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE.
        * @param [in] data Metadata data.
        * @param [in] options The options of operate metadata.
        * @param [in] lock lock for operate channel metadata.
        * 
        * @return The result of RemoveChannelMetadata
        */
        Task<RtmResult<RemoveChannelMetadataResult>> RemoveChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        /**
        * Get the metadata of a specified channel.
        *
        * @param [in] channelName The channel Name of the specified channel.
        * @param [in] channelType Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE.
        * 
        * @return The result of GetChannelMetadata
        */
        Task<RtmResult<GetChannelMetadataResult>> GetChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType);

        /**
        * Set the metadata of a specified user.
        *
        * @param [in] userId The user ID of the specified user.
        * @param [in] data Metadata data.
        * @param [in] options The options of operate metadata.
        * 
        * @return The result of SetUserMetadata
        */
        Task<RtmResult<SetUserMetadataResult>> SetUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        /**
        * Update the metadata of a specified user.
        *
        * @param [in] userId The user ID of the specified user.
        * @param [in] data Metadata data.
        * @param [in] options The options of operate metadata.
        * 
        * @return The result of UpdateUserMetadata
        */
        Task<RtmResult<UpdateUserMetadataResult>> UpdateUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        /**
        * Remove the metadata of a specified user.
        *
        * @param [in] userId The user ID of the specified user.
        * @param [in] data Metadata data.
        * @param [in] options The options of operate metadata.
        * 
        * @return The result of RemoveUserMetadata
        */
        Task<RtmResult<RemoveUserMetadataResult>> RemoveUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        /**
        * Get the metadata of a specified user.
        *
        * @param [in] userId The user ID of the specified user.
        * @param [out] requestId The unique ID of this request.
        * 
        * @return The result of GetUserMetadata
        */
        Task<RtmResult<GetUserMetadataResult>> GetUserMetadataAsync(string userId);

        /**
        * Subscribe the metadata update event of a specified user.
        *
        * @param [in] userId The user ID of the specified user.
        * 
        * @return The result of SubscribeUserMetadata
        */
        Task<RtmResult<SubscribeUserMetadataResult>> SubscribeUserMetadataAsync(string userId);

        /**
        * unsubscribe the metadata update event of a specified user.
        *
        * @param [in] userId The user ID of the specified user.
        * 
        * @return The result of UnsubscribeUserMetadata
        */
        Task<RtmResult<UnsubscribeUserMetadataResult>> UnsubscribeUserMetadataAsync(string userId);
    }

}
