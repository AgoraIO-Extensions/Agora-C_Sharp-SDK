using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class RtmStorage : IRtmStorage
    {
        private Internal.IRtmStorage internalRtmStorage;
        private RtmEventHandler rtmEventHandler;

        internal RtmStorage(Internal.IRtmStorage rtmStorage, RtmEventHandler rtmEventHandler)
        {
            this.internalRtmStorage = rtmStorage;
            this.rtmEventHandler = rtmEventHandler;
        }

        public Task<RtmResult<SetChannelMetadataResult>> SetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName)
        {
            TaskCompletionSource<RtmResult<SetChannelMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SetChannelMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.SetChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SetChannelMetadataResult> result = new RtmResult<SetChannelMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMSetChannelMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSetChannelMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<UpdateChannelMetadataResult>> UpdateChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName)
        {
            TaskCompletionSource<RtmResult<UpdateChannelMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<UpdateChannelMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.UpdateChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<UpdateChannelMetadataResult> result = new RtmResult<UpdateChannelMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMUpdateChannelMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutUpdateChannelMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RemoveChannelMetadataResult>> RemoveChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName)
        {
            TaskCompletionSource<RtmResult<RemoveChannelMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RemoveChannelMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.RemoveChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<RemoveChannelMetadataResult> result = new RtmResult<RemoveChannelMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMRemoveChannelMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutRemoveChannelMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<GetChannelMetadataResult>> GetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType)
        {
            TaskCompletionSource<RtmResult<GetChannelMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetChannelMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.GetChannelMetadata(channelName, channelType, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetChannelMetadataResult> result = new RtmResult<GetChannelMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMGetChannelMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutGetChannelMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<SetUserMetadataResult>> SetUserMetadata(string userId, RtmMetadata data, MetadataOptions options)
        {
            TaskCompletionSource<RtmResult<SetUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SetUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.SetUserMetadata(userId, data, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SetUserMetadataResult> result = new RtmResult<SetUserMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMSetUserMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSetUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<UpdateUserMetadataResult>> UpdateUserMetadata(string userId, RtmMetadata data, MetadataOptions options)
        {
            TaskCompletionSource<RtmResult<UpdateUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<UpdateUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.UpdateUserMetadata(userId, data, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<UpdateUserMetadataResult> result = new RtmResult<UpdateUserMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMUpdateUserMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutUpdateUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RemoveUserMetadataResult>> RemoveUserMetadata(string userId, RtmMetadata data, MetadataOptions options)
        {
            TaskCompletionSource<RtmResult<RemoveUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RemoveUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.RemoveUserMetadata(userId, data, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<RemoveUserMetadataResult> result = new RtmResult<RemoveUserMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMRemoveUserMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutRemoveUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<GetUserMetadataResult>> GetUserMetadata(string userId)
        {
            TaskCompletionSource<RtmResult<GetUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.GetUserMetadata(userId, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetUserMetadataResult> result = new RtmResult<GetUserMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMGetUserMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutGetUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<SubscribeUserMetadataResult>> SubscribeUserMetadata(string userId)
        {
            TaskCompletionSource<RtmResult<SubscribeUserMetadataResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SubscribeUserMetadataResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmStorage.SubscribeUserMetadata(userId, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SubscribeUserMetadataResult> result = new RtmResult<SubscribeUserMetadataResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMSubscribeUserMetadataOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSubscribeUserMetadataResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public int UnsubscribeUserMetadata(string userId)
        {
            return this.internalRtmStorage.UnsubscribeUserMetadata(userId);
        }

    }
}
