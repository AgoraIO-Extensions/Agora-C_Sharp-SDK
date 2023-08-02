using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    /**
    * The IRtmLock class.
    *
    * This class provides the rtm lock methods that can be invoked by your app.
    */
    public interface IRtmLock
    {
        /**
        * sets a lock
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] lockName The name of the lock.
        * @param [in] ttl The lock ttl.
        * 
        * @return The result of SetLock
        */
        Task<RtmResult<SetLockResult>> SetLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl);

        /**
        * gets locks in the channel
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * 
        * @return The result of GetLocks
        */
        Task<RtmResult<GetLocksResult>> GetLocksAsync(string channelName, RTM_CHANNEL_TYPE channelType);

        /**
        * removes a lock
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] lockName The name of the lock.
        * 
        * @return The result of RemoveLock
        */
        Task<RtmResult<RemoveLockResult>> RemoveLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName);

        /**
        * acquires a lock
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] lockName The name of the lock.
        * @param [in] retry Whether to automatically retry when acquires lock failed.
        * 
        * @return The result of AcquireLock
        */
        Task<RtmResult<AcquireLockResult>> AcquireLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry);


        /**
        * releases a lock
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] lockName The name of the lock.
        * 
        * @return The result of ReleaseLock
        */
        Task<RtmResult<ReleaseLockResult>> ReleaseLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName);

        /**
        * disables a lock
        *
        * @param [in] channelName The name of the channel.
        * @param [in] channelType The type of the channel.
        * @param [in] lockName The name of the lock.
        * @param [in] owner The lock owner.
        * 
        * @return The result of RevokeLock
        */
        Task<RtmResult<RevokeLockResult>> RevokeLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner);
    }
}
