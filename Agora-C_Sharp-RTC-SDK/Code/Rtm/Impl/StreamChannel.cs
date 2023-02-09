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

        public Task<RtmResult<JoinResult>> Join(JoinChannelOptions options)
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

        public Task<RtmResult<LeaveResult>> Leave()
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

        public Task<RtmResult<JoinTopicResult>> JoinTopic(string topic, JoinTopicOptions options)
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

        public RtmStatus PublishTopicMessage(string topic, byte[] message, int length, PublishOptions option)
        {
            int errorCode = internalStreamChannel.PublishTopicMessage(topic, message, length, option);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMPublishTopicMessageOperation, this.internalRtmClient);
        }

        public RtmStatus PublishTopicMessage(string topic, string message, int length, PublishOptions option)
        {
            int errorCode = internalStreamChannel.PublishTopicMessage(topic, message, length, option);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMPublishTopicMessageOperation, this.internalRtmClient);
        }

        public Task<RtmResult<LeaveTopicResult>> LeaveTopic(string topic)
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

        public Task<RtmResult<SubscribeTopicResult>> SubscribeTopic(string topic, TopicOptions options)
        {
            TaskCompletionSource<RtmResult<SubscribeTopicResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SubscribeTopicResult>>();
            UInt64 requestId = 0;
            int errorCode = internalStreamChannel.SubscribeTopic(topic, options, ref requestId);
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

        public RtmStatus UnsubscribeTopic(string topic, TopicOptions options)
        {
            int errorCode = this.internalStreamChannel.UnsubscribeTopic(topic, options);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMUnsubscribeTopicOperation, this.internalRtmClient);
        }

        public RtmStatus GetSubscribedUserList(string topic, ref UserList users)
        {
            int errorCode = internalStreamChannel.GetSubscribedUserList(topic, ref users);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMGetSubscribedUserListOperation, this.internalRtmClient);
        }

        public RtmStatus Dispose()
        {
            int errorCode = this.internalStreamChannel.Dispose();
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMDisposeOperation, this.internalRtmClient);
        }

    }
}
