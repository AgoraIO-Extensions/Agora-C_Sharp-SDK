using System;

namespace Agora.Rtm.Internal
{
    internal sealed class RtmHistory : IRtmHistory
    {
        private RtmHistoryImpl _rtmHistoryImpl = null;
        private const int ErrorCode = (int)RTM_ERROR_CODE.NOT_INITIALIZED;

        internal RtmHistory(RtmHistoryImpl impl)
        {
            this._rtmHistoryImpl = impl;
        }

        private static RtmHistory instance = null;

        internal static RtmHistory GetInstance(RtmHistoryImpl impl)
        {
            return instance ?? (instance = new RtmHistory(impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override int GetMessages(string channelName, RTM_CHANNEL_TYPE channelType,
          GetHistoryMessagesOptions options, ref UInt64 requestId)
        {
            if (_rtmHistoryImpl == null)
            {
                return ErrorCode;
            }
            return _rtmHistoryImpl.GetMessages(channelName, channelType, options, ref requestId);
        }
    }
}
