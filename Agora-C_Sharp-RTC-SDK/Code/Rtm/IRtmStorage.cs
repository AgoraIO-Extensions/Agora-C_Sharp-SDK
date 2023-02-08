using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{

    public interface IRtmStorage
    {
        Task<RtmResult<SetChannelMetadataResult>> SetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        Task<RtmResult<UpdateChannelMetadataResult>> UpdateChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        Task<RtmResult<RemoveChannelMetadataResult>> RemoveChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName);

        Task<RtmResult<GetChannelMetadataResult>> GetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType);

        Task<RtmResult<SetUserMetadataResult>> SetUserMetadata(string userId, RtmMetadata data, MetadataOptions options);

        Task<RtmResult<UpdateUserMetadataResult>> UpdateUserMetadata(string userId, RtmMetadata data, MetadataOptions options);

        Task<RtmResult<RemoveUserMetadataResult>> RemoveUserMetadata(string userId, RtmMetadata data, MetadataOptions options);

        Task<RtmResult<GetUserMetadataResult>> GetUserMetadata(string userId);

        Task<RtmResult<SubscribeUserMetadataResult>> SubscribeUserMetadata(string userId);

        int UnsubscribeUserMetadata(string userId);
    }

}
