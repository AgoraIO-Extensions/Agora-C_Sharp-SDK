using System;
using StreamChannelType = System.String;
namespace Agora.Rtm
{

    public sealed class StreamChannel : IStreamChannel
    {
        private bool _disposed = false;
        private IStreamChannelCreator _selfCreator = null;
        private StreamChannelImpl _streamChannelImpl = null;
        private const int ErrorCode = -7;

        private string channelName = "";
        private StreamChannelType type = "";

        internal StreamChannel(IStreamChannelCreator selfCreator, StreamChannelImpl impl, string channelName, StreamChannelType type)
        {
            _selfCreator = selfCreator;
            _streamChannelImpl = impl;

            this.channelName = channelName;
            this.type = type;
        }

        ~StreamChannel()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
            }

            this._selfCreator.RemoveStreamChannelIfExist(this.channelName);

            _streamChannelImpl = null;
            _selfCreator = null;
            channelName = "";
            _disposed = true;
        }

        public override int Dispose()
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            int ret = _streamChannelImpl.Release(channelName, type);
            Dispose(true);
            GC.SuppressFinalize(this);
            return ret;
        }

        public override string GetChannelName()
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return "";
            }
            return channelName;
        }

        public override int Join(JoinChannelOptions options, ref UInt64 requestId)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.Join(channelName, type, options, ref requestId);
        }

        public override int Leave(ref UInt64 requestId)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.Leave(channelName, type, ref requestId);
        }

        public override int JoinTopic(string topic, JoinTopicOptions options, ref UInt64 requestId)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.JoinTopic(channelName, type, topic, options, ref requestId);
        }

        public override int PublishTopicMessage(string topic, byte[] message, int length, PublishOptions option)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.PublishTopicMessage(channelName, type, topic, message, message.Length, option);
        }

        public override int PublishTopicMessage(string topic, string message, int length, PublishOptions option)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            byte[] bytes = System.Text.Encoding.Default.GetBytes(message);
            return _streamChannelImpl.PublishTopicMessage(channelName, type, topic, bytes, bytes.Length, option);
        }

        public override int LeaveTopic(string topic, ref UInt64 requestId)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.LeaveTopic(channelName, type, topic, ref requestId);
        }

        public override int SubscribeTopic(string topic, TopicOptions options, ref UInt64 requestId)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.SubscribeTopic(channelName, type, topic, options, ref requestId);
        }

        public override int UnsubscribeTopic(string topic, TopicOptions options)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.UnsubscribeTopic(channelName, type, topic, options);
        }

        public override int GetSubscribedUserList(string topic, ref UserList users)
        {
            if (_selfCreator == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.GetSubscribedUserList(channelName, type, topic, ref users);
        }
    }
}