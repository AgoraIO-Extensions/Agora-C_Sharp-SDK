using System;

namespace Agora.Rtm
{
    public sealed class StreamChannel : IStreamChannel
    {
        private bool _disposed = false;
        private IRtmClient _rtmClientInstance = null;
        private StreamChannelImpl _streamChannelImpl = null;
        private const int ErrorCode = -7;

        private string channelName = "";

        internal StreamChannel(IRtmClient rtmClient, StreamChannelImpl impl, string channelName)
        {
            _rtmClientInstance = rtmClient;
            _streamChannelImpl = impl;

            this.channelName = channelName;
        }

        ~StreamChannel()
        {
            Dispose(false);
        }

        private int Dispose(bool disposing)
        {
            if (_disposed) return 0;

            if (disposing)
            {
            }

            int ret = _streamChannelImpl.Release(channelName);

            _streamChannelImpl = null;
            _rtmClientInstance = null;
            channelName = "";
            _disposed = true;

            return ret;
        }

        public override int Release()
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            int ret = Dispose(true);
            GC.SuppressFinalize(this);
            return ret;
        }

        public override string GetChannelName()
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return "";
            }
            return channelName;
        }

        public override int Join(JoinChannelOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.Join(channelName, options);
        }

        public override int Leave()
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.Leave(channelName);
        }

        public override int JoinTopic(string topic, JoinTopicOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.JoinTopic(channelName, topic, options);
        }

        public override int PublishTopicMessage(string topic, byte[] message)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.PublishTopicMessage(channelName, topic, message, (uint)message.Length);
        }

        public override int PublishTopicMessage(string topic, string message)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            byte[] messageByte = System.Text.Encoding.Default.GetBytes(message);
            return _streamChannelImpl.PublishTopicMessage(channelName, topic, messageByte, (uint)messageByte.Length);
        }

        public override int LeaveTopic(string topic)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.LeaveTopic(channelName, topic);
        }

        public override int SubscribeTopic(string topic, TopicOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.SubscribeTopic(channelName, topic, options);
        }

        public override int UnsubscribeTopic(string topic, TopicOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.UnsubscribeTopic(channelName, topic, options);
        }

        public override int GetSubscribedUserList(string topic, ref UserList users)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.GetSubscribedUserList(channelName, topic, ref users);
        }
    }
}