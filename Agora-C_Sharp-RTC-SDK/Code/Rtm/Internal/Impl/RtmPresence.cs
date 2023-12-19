using System;

namespace Agora.Rtm.Internal
{
    internal sealed class RtmPresence : IRtmPresence
    {
        private RtmPresenceImpl _rtmPresenceImpl = null;
        private const int ErrorCode = -7;

        internal RtmPresence(RtmPresenceImpl rtmPresenceImpl)
        {
            this._rtmPresenceImpl = rtmPresenceImpl;
        }

        private static RtmPresence instance = null;

        internal static RtmPresence GetInstance(RtmPresenceImpl impl)
        {
            return instance ?? (instance = new RtmPresence(impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override int WhoNow(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options, ref UInt64 requestId)
        {
            if (_rtmPresenceImpl == null)
            {
                return ErrorCode;
            }
            return _rtmPresenceImpl.WhoNow(channelName, channelType, options, ref requestId);
        }

        public override int WhereNow(string userId, ref UInt64 requestId)
        {
            if (_rtmPresenceImpl == null)
            {
                return ErrorCode;
            }
            return _rtmPresenceImpl.WhereNow(userId, ref requestId);
        }

        public override int SetState(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items, int count, ref UInt64 requestId)
        {
            if (_rtmPresenceImpl == null)
            {
                return ErrorCode;
            }
            return _rtmPresenceImpl.SetState(channelName, channelType, items, count, ref requestId);
        }

        public override int RemoveState(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys, int count, ref UInt64 requestId)
        {
            if (_rtmPresenceImpl == null)
            {
                return ErrorCode;
            }
            return _rtmPresenceImpl.RemoveState(channelName, channelType, keys, count, ref requestId);
        }

        public override int GetState(string channelName, RTM_CHANNEL_TYPE channelType, string userId, ref UInt64 requestId)
        {
            if (_rtmPresenceImpl == null)
            {
                return ErrorCode;
            }
            return _rtmPresenceImpl.GetState(channelName, channelType, userId, ref requestId);
        }

        public override int GetOnlineUsers(string channelName, RTM_CHANNEL_TYPE channelType, GetOnlineUsersOptions options, ref ulong requestId)
        {
            if (_rtmPresenceImpl == null)
            {
                return ErrorCode;
            }
            return _rtmPresenceImpl.GetOnlineUsers(channelName, channelType, options, ref requestId);
        }

        public override int GetUserChannels(string userId, ref ulong requestId)
        {
            if (_rtmPresenceImpl == null)
            {
                return ErrorCode;
            }
            return _rtmPresenceImpl.GetUserChannels(userId, ref requestId);
        }
    }
}
