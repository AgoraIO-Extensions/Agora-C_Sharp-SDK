using System;

namespace Agora.Rtm.Internal
{
    internal sealed class RtmStorage : IRtmStorage
    {
        private RtmStorageImpl _rtmStorageImpl = null;
        private const int ErrorCode = -7;

        internal RtmStorage(RtmStorageImpl impl)
        {
            this._rtmStorageImpl = impl;
        }

        private static RtmStorage instance = null;

        internal static RtmStorage GetInstance(RtmStorageImpl impl)
        {
            return instance ?? (instance = new RtmStorage(impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        // public override RtmMetadata CreateMetadata()
        //{
        //     if (_rtmStorageImpl == null)
        //     {
        //         return null;
        //     }
        //     return _rtmStorageImpl.CreateMetadata();
        // }

        public override int SetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.SetChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
        }

        public override int UpdateChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.UpdateChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
        }

        public override int RemoveChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, MetadataOptions options, string lockName, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.RemoveChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);
        }

        public override int GetChannelMetadata(string channelName, RTM_CHANNEL_TYPE channelType, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.GetChannelMetadata(channelName, channelType, ref requestId);
        }

        public override int SetUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.SetUserMetadata(userId, data, options, ref requestId);
        }

        public override int UpdateUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.UpdateUserMetadata(userId, data, options, ref requestId);
        }

        public override int RemoveUserMetadata(string userId, RtmMetadata data, MetadataOptions options, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.RemoveUserMetadata(userId, data, options, ref requestId);
        }

        public override int GetUserMetadata(string userId, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.GetUserMetadata(userId, ref requestId);
        }

        public override int SubscribeUserMetadata(string userId, ref UInt64 requestId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.SubscribeUserMetadata(userId, ref requestId);
        }

        public override int UnsubscribeUserMetadata(string userId)
        {
            if (_rtmStorageImpl == null)
            {
                return ErrorCode;
            }
            return _rtmStorageImpl.UnsubscribeUserMetadata(userId);
        }
    }
}
