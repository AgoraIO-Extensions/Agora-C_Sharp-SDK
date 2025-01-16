using System;
namespace Agora.Rtm.Internal
{
    public abstract class IRtmHistory
    {
        public abstract int GetMessages(string channelName, RTM_CHANNEL_TYPE channelType,
            GetHistoryMessagesOptions options, ref UInt64 requestId);
    }
}

