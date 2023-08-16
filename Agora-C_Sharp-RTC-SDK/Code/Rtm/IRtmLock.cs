using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    ///
    /// <summary>
    /// The IRtmLock class.
    /// This class provides the rtm lock methods that can be invoked by your app.
    /// </summary>
    ///
    public interface IRtmLock
    {
        ///
        /// <summary>
        /// sets a lock
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="lockName"> The name of the lock.</param>
        /// <param name="ttl"> The lock ttl.</param>
        ///
        /// <returns>
        /// The result of SetLock
        /// </returns>
        ///
        Task<RtmResult<SetLockResult>> SetLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl);

        ///
        /// <summary>
        /// gets locks in the channel
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        ///
        /// <returns>
        /// The result of GetLocks
        /// </returns>
        ///
        Task<RtmResult<GetLocksResult>> GetLocksAsync(string channelName, RTM_CHANNEL_TYPE channelType);

        ///
        /// <summary>
        /// removes a lock
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="lockName"> The name of the lock.</param>
        ///
        /// <returns>
        /// The result of RemoveLock
        /// </returns>
        ///
        Task<RtmResult<RemoveLockResult>> RemoveLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName);

        ///
        /// <summary>
        /// acquires a lock
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="lockName"> The name of the lock.</param>
        /// <param name="retry"> Whether to automatically retry when acquires lock failed.</param>
        ///
        /// <returns>
        /// The result of AcquireLock
        /// </returns>
        ///
        Task<RtmResult<AcquireLockResult>> AcquireLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry);

        ///
        /// <summary>
        /// releases a lock
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="lockName"> The name of the lock.</param>
        ///
        /// <returns>
        /// The result of ReleaseLock
        /// </returns>
        ///
        Task<RtmResult<ReleaseLockResult>> ReleaseLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName);

        ///
        /// <summary>
        /// disables a lock
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="channelType"> The type of the channel.</param>
        /// <param name="lockName"> The name of the lock.</param>
        /// <param name="owner"> The lock owner.</param>
        ///
        /// <returns>
        /// The result of RevokeLock
        /// </returns>
        ///
        Task<RtmResult<RevokeLockResult>> RevokeLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner);
    }
}
