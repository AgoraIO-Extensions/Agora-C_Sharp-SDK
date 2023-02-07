using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public interface IRtmLock
    {
        Task<RtmResult<SetLockResult>> SetLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl);

        Task<RtmResult<GetLocksResult>> GetLocks(string channelName, RTM_CHANNEL_TYPE channelType);

        Task<RtmResult<RemoveLockResult>> RemoveLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName);

        Task<RtmResult<AcquireLockResult>> AcquireLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry);

        Task<RtmResult<ReleaseLockResult>> ReleaseLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName);

        Task<RtmResult<RevokeLockResult>> RevokeLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner);
    }
}
