using System;
namespace Agora.Rtm.Internal
{
    public abstract class IRtmLock
    {
        public abstract int SetLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl, ref UInt64 requestId);

        public abstract int GetLocks(string channelName, RTM_CHANNEL_TYPE channelType, ref UInt64 requestId);

        public abstract int RemoveLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, ref UInt64 requestId);

        public abstract int AcquireLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry, ref UInt64 requestId);

        public abstract int ReleaseLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, ref UInt64 requestId);

        public abstract int RevokeLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner, ref UInt64 requestId);
    }
}
