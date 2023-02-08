using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class StreamChannel : IStreamChannel
    {
        private Internal.IStreamChannel internalStreamChannel;
        private RtmEventHandler rtmEventHandler;

        internal StreamChannel(Internal.IStreamChannel streamChannel, RtmEventHandler rtmEventHandler)
        {
            this.internalStreamChannel = streamChannel;
            this.rtmEventHandler = rtmEventHandler;
        }

        public Task<RtmResult<JoinResult>> Join(JoinChannelOptions options)
        {
            TaskCompletionSource<RtmResult<JoinResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<JoinResult>>();
            UInt64 requestId = 0;
            int errorCode = internalStreamChannel.Join(options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<JoinResult> result = new RtmResult<JoinResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMJoinOperation);
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
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMLeaveOperation);
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
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMJoinTopicOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutJoinTopicResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public int PublishTopicMessage(string topic, byte[] message, int length, PublishOptions option)
        {
            return internalStreamChannel.PublishTopicMessage(topic, message, length, option);
        }

        public int PublishTopicMessage(string topic, string message, int length, PublishOptions option)
        {
            return internalStreamChannel.PublishTopicMessage(topic, message, length, option);
        }

        public Task<RtmResult<LeaveTopicResult>> LeaveTopic(string topic)
        {
            TaskCompletionSource<RtmResult<LeaveTopicResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<LeaveTopicResult>>();
            UInt64 requestId = 0;
            int errorCode = internalStreamChannel.LeaveTopic(topic, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<LeaveTopicResult> result = new RtmResult<LeaveTopicResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMLeaveTopicOperation);
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
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMSubscribeTopicOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSubscribeTopicResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public int UnsubscribeTopic(string topic, TopicOptions options)
        {
            return this.internalStreamChannel.UnsubscribeTopic(topic, options);
        }

        public int GetSubscribedUserList(string topic, ref UserList users)
        {
            return this.internalStreamChannel.GetSubscribedUserList(topic, ref users);
        }

        public int Dispose()
        {
            return this.internalStreamChannel.Dispose();
        }

    }
}
