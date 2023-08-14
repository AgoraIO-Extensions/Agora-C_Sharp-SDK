using System;

namespace Agora.Rtm.Internal
{
    internal sealed class RtmLock : IRtmLock
    {
        private RtmLockImpl _rtmLockImpl = null;
        private const int ErrorCode = -7;

        internal RtmLock(RtmLockImpl impl)
        {
            this._rtmLockImpl = impl;
        }

        private static RtmLock instance = null;

        internal static RtmLock GetInstance(RtmLockImpl impl)
        {
            return instance ?? (instance = new RtmLock(impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override int SetLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl, ref UInt64 requestId)
        {
            if (_rtmLockImpl == null)
            {
                return ErrorCode;
            }
            return _rtmLockImpl.SetLock(channelName, channelType, lockName, ttl, ref requestId);
        }

        public override int GetLocks(string channelName, RTM_CHANNEL_TYPE channelType, ref UInt64 requestId)
        {
            if (_rtmLockImpl == null)
            {
                return ErrorCode;
            }
            return _rtmLockImpl.GetLocks(channelName, channelType, ref requestId);
        }

        public override int RemoveLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, ref UInt64 requestId)
        {
            if (_rtmLockImpl == null)
            {
                return ErrorCode;
            }
            return _rtmLockImpl.RemoveLock(channelName, channelType, lockName, ref requestId);
        }

        public override int AcquireLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry, ref UInt64 requestId)
        {
            if (_rtmLockImpl == null)
            {
                return ErrorCode;
            }
            return _rtmLockImpl.AcquireLock(channelName, channelType, lockName, retry, ref requestId);
        }

        public override int ReleaseLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, ref UInt64 requestId)
        {
            if (_rtmLockImpl == null)
            {
                return ErrorCode;
            }
            return _rtmLockImpl.ReleaseLock(channelName, channelType, lockName, ref requestId);
        }

        public override int RevokeLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner, ref UInt64 requestId)
        {
            if (_rtmLockImpl == null)
            {
                return ErrorCode;
            }
            return _rtmLockImpl.RevokeLock(channelName, channelType, lockName, owner, ref requestId);
        }
    }
}
