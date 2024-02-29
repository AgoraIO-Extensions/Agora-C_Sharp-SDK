using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class RtmPresence : IRtmPresence
    {
        private Internal.IRtmPresence internalRtmPresence;
        private RtmEventHandler rtmEventHandler;
        private Internal.IRtmClient internalRtmClient;

        internal RtmPresence(Internal.IRtmPresence rtmPresence, RtmEventHandler rtmEventHandler, Internal.IRtmClient rtmClient)
        {
            this.internalRtmPresence = rtmPresence;
            this.rtmEventHandler = rtmEventHandler;
            this.internalRtmClient = rtmClient;
        }

        public Task<RtmResult<GetStateResult>> GetStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, string userId)
        {
            TaskCompletionSource<RtmResult<GetStateResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetStateResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmPresence.GetState(channelName, channelType, userId, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetStateResult> result = new RtmResult<GetStateResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMGetStateOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutPresenceGetStateResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RemoveStateResult>> RemoveStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys)
        {
            TaskCompletionSource<RtmResult<RemoveStateResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RemoveStateResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmPresence.RemoveState(channelName, channelType, keys, keys.Length, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<RemoveStateResult> result = new RtmResult<RemoveStateResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMRemoveStateOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutPresenceRemoveStateResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<SetStateResult>> SetStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items)
        {
            TaskCompletionSource<RtmResult<SetStateResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SetStateResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmPresence.SetState(channelName, channelType, items, items.Length, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SetStateResult> result = new RtmResult<SetStateResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMSetStateOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutPresenceSetStateResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<WhereNowResult>> WhereNowAsync(string userId)
        {
            TaskCompletionSource<RtmResult<WhereNowResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<WhereNowResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmPresence.WhereNow(userId, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<WhereNowResult> result = new RtmResult<WhereNowResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMWhereNowOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutWhereNowResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<WhoNowResult>> WhoNowAsync(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options)
        {
            TaskCompletionSource<RtmResult<WhoNowResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<WhoNowResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmPresence.WhoNow(channelName, channelType, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<WhoNowResult> result = new RtmResult<WhoNowResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMWhoNowOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutWhoNowResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<GetUserChannelsResult>> GetUserChannelsAsync(string userId)
        {
            TaskCompletionSource<RtmResult<GetUserChannelsResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetUserChannelsResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmPresence.GetUserChannels(userId, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetUserChannelsResult> result = new RtmResult<GetUserChannelsResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMGetUserChannelsOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutGetUserChannelsResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<GetOnlineUsersResult>> GetOnlineUsersAsync(string channelName, RTM_CHANNEL_TYPE channelType, GetOnlineUsersOptions options)
        {
            TaskCompletionSource<RtmResult<GetOnlineUsersResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetOnlineUsersResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmPresence.GetOnlineUsers(channelName, channelType, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetOnlineUsersResult> result = new RtmResult<GetOnlineUsersResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMGetOnlineUsersOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutGetOnlineUsersTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }
    }
}
