using System.Threading.Tasks;
namespace Agora.Rtm
{

    public interface IRtmStorage
    {
        Task<RtmResult<SetChannelMetadataResult>> SetChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        Task<RtmResult<UpdateChannelMetadataResult>> UpdateChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        Task<RtmResult<RemoveChannelMetadataResult>> RemoveChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        Task<RtmResult<GetChannelMetadataResult>> GetChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType);

        Task<RtmResult<SetUserMetadataResult>> SetUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        Task<RtmResult<UpdateUserMetadataResult>> UpdateUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        Task<RtmResult<RemoveUserMetadataResult>> RemoveUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options);

        Task<RtmResult<GetUserMetadataResult>> GetUserMetadataAsync(string userId);

        Task<RtmResult<SubscribeUserMetadataResult>> SubscribeUserMetadataAsync(string userId);

        Task<RtmResult<UnsubscribeUserMetadataResult>> UnsubscribeUserMetadataAsync(string userId);
    }

}
