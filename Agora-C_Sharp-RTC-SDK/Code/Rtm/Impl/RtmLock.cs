using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class RtmLock : IRtmLock
    {
        private Internal.IRtmLock internalRtmLock;
        private RtmEventHandler rtmEventHandler;
        private Internal.IRtmClient internalRtmClient;

        internal RtmLock(Internal.IRtmLock rtmLock, RtmEventHandler rtmEventHandler, Internal.IRtmClient rtmClient)
        {
            this.internalRtmLock = rtmLock;
            this.rtmEventHandler = rtmEventHandler;
            this.internalRtmClient = rtmClient;
        }

        public Task<RtmResult<AcquireLockResult>> AcquireLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry)
        {
            TaskCompletionSource<RtmResult<AcquireLockResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<AcquireLockResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmLock.AcquireLock(channelName, channelType, lockName, retry, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<AcquireLockResult> result = new RtmResult<AcquireLockResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMAcquireLockOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutAcquireLockResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<GetLocksResult>> GetLocksAsync(string channelName, RTM_CHANNEL_TYPE channelType)
        {
            TaskCompletionSource<RtmResult<GetLocksResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetLocksResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmLock.GetLocks(channelName, channelType, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetLocksResult> result = new RtmResult<GetLocksResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMGetLocksOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutGetLocksResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<ReleaseLockResult>> ReleaseLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName)
        {
            TaskCompletionSource<RtmResult<ReleaseLockResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<ReleaseLockResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmLock.ReleaseLock(channelName, channelType, lockName, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<ReleaseLockResult> result = new RtmResult<ReleaseLockResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMReleaseLockOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutReleaseLockResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RemoveLockResult>> RemoveLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName)
        {
            TaskCompletionSource<RtmResult<RemoveLockResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RemoveLockResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmLock.RemoveLock(channelName, channelType, lockName, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<RemoveLockResult> result = new RtmResult<RemoveLockResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMRemoveLockOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutRemoveLockResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RevokeLockResult>> RevokeLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner)
        {
            TaskCompletionSource<RtmResult<RevokeLockResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RevokeLockResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmLock.RevokeLock(channelName, channelType, lockName, owner, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<RevokeLockResult> result = new RtmResult<RevokeLockResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMRevokeLockOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutRevokeLockResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<SetLockResult>> SetLockAsync(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl)
        {
            TaskCompletionSource<RtmResult<SetLockResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SetLockResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmLock.SetLock(channelName, channelType, lockName, ttl, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SetLockResult> result = new RtmResult<SetLockResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMSetLockOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSetLockResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }
    }
}
