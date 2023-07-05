using System;
namespace Agora.Rtm.Internal
{
    public abstract class IRtmStorage
    {
        public abstract int SetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId);

        public abstract int UpdateChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId);

        public abstract int RemoveChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId);

        public abstract int GetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, ref UInt64 requestId);

        public abstract int SetUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId);

        public abstract int UpdateUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId);

        public abstract int RemoveUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId);

        public abstract int GetUserMetadata(string userId, ref UInt64 requestId);

        public abstract int SubscribeUserMetadata(string userId, ref UInt64 requestId);

        public abstract int UnsubscribeUserMetadata(string userId);
    }

}
