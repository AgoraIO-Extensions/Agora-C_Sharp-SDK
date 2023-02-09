using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public interface IRtmLock
    {
        Task<RtmResult<SetLockResult>> SetLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl);

        Task<RtmResult<GetLocksResult>> GetLocksAsync(string channelName, RTM_CHANNEL_TYPE channelType);

        Task<RtmResult<RemoveLockResult>> RemoveLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName);

        Task<RtmResult<AcquireLockResult>> AcquireLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry);

        Task<RtmResult<ReleaseLockResult>> ReleaseLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName);

        Task<RtmResult<RevokeLockResult>> RevokeLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner);
    }
}
