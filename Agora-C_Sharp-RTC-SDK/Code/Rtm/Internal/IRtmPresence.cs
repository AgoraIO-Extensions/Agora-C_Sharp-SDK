using System;
namespace Agora.Rtm.Internal
{
    public abstract class IRtmPresence
    {
        public abstract int WhoNow(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options, ref UInt64 requestId);

        public abstract int WhereNow(string userId, ref UInt64 requestId);

        public abstract int SetState(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items, int count, ref UInt64 requestId);

        public abstract int RemoveState(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys, int count, ref UInt64 requestId);

        public abstract int GetState(string channelName, RTM_CHANNEL_TYPE channelType, string userId, ref UInt64 requestId);

        public abstract int GetOnlineUsers(string channelName, RTM_CHANNEL_TYPE channelType, GetOnlineUsersOptions options, ref UInt64 requestId);

        public abstract int GetUserChannels(string userId, ref UInt64 requestId);
    }
}
