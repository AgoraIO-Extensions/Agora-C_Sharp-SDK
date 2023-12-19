using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class StreamChannel : IStreamChannel
    {
        private Internal.IStreamChannel internalStreamChannel;
        private RtmEventHandler rtmEventHandler;
        private Internal.IRtmClient internalRtmClient;

        internal StreamChannel(Internal.IStreamChannel streamChannel, RtmEventHandler rtmEventHandler, Internal.IRtmClient rtmClient)
        {
            this.internalStreamChannel = streamChannel;
            this.rtmEventHandler = rtmEventHandler;
            this.internalRtmClient = rtmClient;
        }

        public Task<RtmResult<JoinResult>> JoinAsync(JoinChannelOptions options)
        {
            TaskCompletionSource<RtmResult<JoinResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<JoinResult>>();
            UInt64 requestId = 0;
            int errorCode = internalStreamChannel.Join(options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<JoinResult> result = new RtmResult<JoinResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMJoinOperation, this.internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutJoinResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RenewTokenResult>> RenewTokenAsync(string token)
        {
            // fake async
            int errorCode = this.internalStreamChannel.RenewToken(token);
            RtmResult<RenewTokenResult> rtmResult = new RtmResult<RenewTokenResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMRenewTokenOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new RenewTokenResult();
            }

            TaskCompletionSource<RtmResult<RenewTokenResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RenewTokenResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<LeaveResult>> LeaveAsync()
        {
            TaskCompletionSource<RtmResult<LeaveResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<LeaveResult>>();
            UInt64 requestId = 0;
            int errorCode = internalStreamChannel.Leave(ref requestId);
            if (errorCode != 0)
            {
                RtmResult<LeaveResult> result = new RtmResult<LeaveResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMLeaveOperation, this.internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutLeaveResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public string GetChannelName()
        {
            return internalStreamChannel.GetChannelName();
        }

        public Task<RtmResult<JoinTopicResult>> JoinTopicAsync(string topic, JoinTopicOptions options)
        {
            TaskCompletionSource<RtmResult<JoinTopicResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<JoinTopicResult>>();
            UInt64 requestId = 0;
            int errorCode = internalStreamChannel.JoinTopic(topic, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<JoinTopicResult> result = new RtmResult<JoinTopicResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMJoinTopicOperation, this.internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutJoinTopicResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<PublishTopicMessageResult>> PublishTopicMessageAsync(string topic, byte[] message, TopicMessageOptions option)
        {
            Internal.TopicMessageOptions internalOptions = new Internal.TopicMessageOptions(option, RTM_MESSAGE_TYPE.BINARY);
            // fake async
            int errorCode = internalStreamChannel.PublishTopicMessage(topic, message, message.Length, internalOptions);

            RtmResult<PublishTopicMessageResult> rtmResult = new RtmResult<PublishTopicMessageResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMPublishTopicMessageOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new PublishTopicMessageResult();
            }

            TaskCompletionSource<RtmResult<PublishTopicMessageResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<PublishTopicMessageResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<PublishTopicMessageResult>> PublishTopicMessageAsync(string topic, string message, TopicMessageOptions option)
        {
            Internal.TopicMessageOptions internalOptions = new Internal.TopicMessageOptions(option, RTM_MESSAGE_TYPE.STRING);
            // fake async
            int errorCode = internalStreamChannel.PublishTopicMessage(topic, message, message.Length, internalOptions);

            RtmResult<PublishTopicMessageResult> rtmResult = new RtmResult<PublishTopicMessageResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMPublishTopicMessageOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new PublishTopicMessageResult();
            }

            TaskCompletionSource<RtmResult<PublishTopicMessageResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<PublishTopicMessageResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<LeaveTopicResult>> LeaveTopicAsync(string topic)
        {
            TaskCompletionSource<RtmResult<LeaveTopicResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<LeaveTopicResult>>();
            UInt64 requestId = 0;
            int errorCode = internalStreamChannel.LeaveTopic(topic, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<LeaveTopicResult> result = new RtmResult<LeaveTopicResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMLeaveTopicOperation, this.internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutLeaveTopicResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<SubscribeTopicResult>> SubscribeTopicAsync(string topic, TopicOptions options)
        {
            TaskCompletionSource<RtmResult<SubscribeTopicResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SubscribeTopicResult>>();
            UInt64 requestId = 0;
            int errorCode = internalStreamChannel.SubscribeTopic(topic, new Internal.TopicOptions(options), ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SubscribeTopicResult> result = new RtmResult<SubscribeTopicResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMSubscribeTopicOperation, this.internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSubscribeTopicResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<UnsubscribeTopicResult>> UnsubscribeTopicAsync(string topic, TopicOptions options)
        {
            // fake async
            int errorCode = this.internalStreamChannel.UnsubscribeTopic(topic, new Internal.TopicOptions(options));

            RtmResult<UnsubscribeTopicResult> rtmResult = new RtmResult<UnsubscribeTopicResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMUnsubscribeTopicOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new UnsubscribeTopicResult();
            }

            TaskCompletionSource<RtmResult<UnsubscribeTopicResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<UnsubscribeTopicResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<GetSubscribedUserListResult>> GetSubscribedUserListAsync(string topic)
        {
            Internal.UserList users = null;
            int errorCode = internalStreamChannel.GetSubscribedUserList(topic, ref users);

            RtmResult<GetSubscribedUserListResult> rtmResult = new RtmResult<GetSubscribedUserListResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMGetSubscribedUserListOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new GetSubscribedUserListResult();
                rtmResult.Response.Users = users.users;
            }

            TaskCompletionSource<RtmResult<GetSubscribedUserListResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetSubscribedUserListResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
        }

        public RtmStatus Dispose()
        {
            int errorCode = this.internalStreamChannel.Dispose();
            if (errorCode == 0)
            {
                this.internalStreamChannel = null;
            }
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMDisposeOperation, this.internalRtmClient);
        }
    }
}
