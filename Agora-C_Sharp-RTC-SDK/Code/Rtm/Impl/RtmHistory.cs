using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class RtmHistory : IRtmHistory
    {
        private Internal.IRtmHistory internalRtmHistory;
        private RtmEventHandler rtmEventHandler;
        private Internal.IRtmClient internalRtmClient;

        internal RtmHistory(Internal.IRtmHistory rtmHistory, RtmEventHandler rtmEventHandler, Internal.IRtmClient rtmClient)
        {
            this.internalRtmHistory = rtmHistory;
            this.rtmEventHandler = rtmEventHandler;
            this.internalRtmClient = rtmClient;
        }

        public Task<RtmResult<GetHistoryMessagesResult>> GetMessages(string channelName, RTM_CHANNEL_TYPE channelType, GetHistoryMessagesOptions options)
        {
            TaskCompletionSource<RtmResult<GetHistoryMessagesResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<GetHistoryMessagesResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmHistory.GetMessages(channelName, channelType, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<GetHistoryMessagesResult> result = new RtmResult<GetHistoryMessagesResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMHistoryGetMessagesOperation, internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutHistroyGetMessagesResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }
    }
}
