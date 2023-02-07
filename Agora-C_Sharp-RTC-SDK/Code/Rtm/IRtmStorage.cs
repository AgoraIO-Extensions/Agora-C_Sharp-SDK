using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public interface IRtmStorage
    {
        Task<RtmResult<SetChannelMetadataResult>> SetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId);

        Task<RtmResult<UpdateChannelMetadataResult>> UpdateChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId);

        Task<RtmResult<RemoveChannelMetadataResult>> RemoveChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId);

        Task<RtmResult<GetChannelMetadataResult>> GetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, ref UInt64 requestId);

        Task<RtmResult<SetUserMetadataResult>> SetUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId);

        Task<RtmResult<UpdateUserMetadataResult>> UpdateUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId);

        Task<RtmResult<RemoveUserMetadataResult>> RemoveUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId);

        Task<RtmResult<GetUserMetadataResult>> GetUserMetadata(string userId, ref UInt64 requestId);

        Task<RtmResult<SubscribeUserMetadataResult>> SubscribeUserMetadata(string userId, ref UInt64 requestId);

        int UnsubscribeUserMetadata(string userId);
    }

}
