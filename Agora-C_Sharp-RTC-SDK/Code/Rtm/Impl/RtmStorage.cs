using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class RtmStorage : IRtmStorage
    {
        private Internal.IRtmStorage internalRtmStorage;
        private RtmEventHandler rtmEventHandler;
        private Internal.IRtmClient internalRtmClient;

        internal RtmStorage(Internal.IRtmStorage rtmStorage, RtmEventHandler rtmEventHandler, Internal.IRtmClient rtmClient)
        {
            this.internalRtmStorage = rtmStorage;
            this.rtmEventHandler = rtmEventHandler;
            this.internalRtmClient = rtmClient;
        }

        public Task<RtmResult<SetChannelMetadataResult>> SetChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName)
        {
            TaskCompletionSource<RtmResult<SetChannelMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SetChannelMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.SetChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SetChannelMetadataResult> result = new RtmResult<SetChannelMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMSetChannelMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSetChannelMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<UpdateChannelMetadataResult>> UpdateChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName)
        {
            TaskCompletionSource<RtmResult<UpdateChannelMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<UpdateChannelMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.UpdateChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<UpdateChannelMetadataResult> result = new RtmResult<UpdateChannelMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMUpdateChannelMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutUpdateChannelMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RemoveChannelMetadataResult>> RemoveChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName)
        {
            TaskCompletionSource<RtmResult<RemoveChannelMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RemoveChannelMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.RemoveChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<RemoveChannelMetadataResult> result = new RtmResult<RemoveChannelMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMRemoveChannelMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutRemoveChannelMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<GetChannelMetadataResult>> GetChannelMetadataAsync(string channelName, RTM_CHANNEL_TYPE channelType)
        {
            TaskCompletionSource<RtmResult<GetChannelMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetChannelMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.GetChannelMetadata(channelName, channelType, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetChannelMetadataResult> result = new RtmResult<GetChannelMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMGetChannelMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutGetChannelMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<SetUserMetadataResult>> SetUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options)
        {
            TaskCompletionSource<RtmResult<SetUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SetUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.SetUserMetadata(userId, data, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SetUserMetadataResult> result = new RtmResult<SetUserMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMSetUserMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSetUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<UpdateUserMetadataResult>> UpdateUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options)
        {
            TaskCompletionSource<RtmResult<UpdateUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<UpdateUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.UpdateUserMetadata(userId, data, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<UpdateUserMetadataResult> result = new RtmResult<UpdateUserMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMUpdateUserMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutUpdateUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RemoveUserMetadataResult>> RemoveUserMetadataAsync(string userId, RtmMetadata data, MetadataOptions options)
        {
            TaskCompletionSource<RtmResult<RemoveUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RemoveUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.RemoveUserMetadata(userId, data, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<RemoveUserMetadataResult> result = new RtmResult<RemoveUserMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMRemoveUserMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutRemoveUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<GetUserMetadataResult>> GetUserMetadataAsync(string userId)
        {
            TaskCompletionSource<RtmResult<GetUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.GetUserMetadata(userId, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetUserMetadataResult> result = new RtmResult<GetUserMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMGetUserMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutGetUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<SubscribeUserMetadataResult>> SubscribeUserMetadataAsync(string userId)
        {
            TaskCompletionSource<RtmResult<SubscribeUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SubscribeUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.SubscribeUserMetadata(userId, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SubscribeUserMetadataResult> result = new RtmResult<SubscribeUserMetadataResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMSubscribeUserMetadataOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSubscribeUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<UnsubscribeUserMetadataResult>> UnsubscribeUserMetadataAsync(string userId)
        {
            // fake async
            int errorCode = this.internalRtmStorage.UnsubscribeUserMetadata(userId);

            RtmResult<UnsubscribeUserMetadataResult> rtmResult = new RtmResult<UnsubscribeUserMetadataResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMUnsubscribeUserMetadataOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new UnsubscribeUserMetadataResult();
            }

            TaskCompletionSource<RtmResult<UnsubscribeUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<UnsubscribeUserMetadataResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
        }
    }
}
