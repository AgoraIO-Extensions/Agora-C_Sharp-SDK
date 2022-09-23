using System;

namespace Agora.Rtm
{
    public sealed class StreamChannel : IStreamChannel
    {
        private IRtmClient _rtmClientInstance = null;
        private StreamChannelImpl _streamChannelImpl = null;
        private const int ErrorCode = -7;

        private string channelName = "";

        internal StreamChannel(IRtmClient rtmClient, StreamChannelImpl impl)
        {
            _rtmClientInstance = rtmClient;
            _streamChannelImpl = impl;

            channelName = _streamChannelImpl.CreateStreamChannel();
        }

        ~StreamChannel()
        {
            _streamChannelImpl = null;
            _rtmClientInstance = null;
        }

        public override void Dispose()
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return;
            }
            _streamChannelImpl.DestroyStreamChannel(channelName);
            channelName = "";
        }

        public override string ChannelName()
        {
            return channelName;
        }

        public override int Join(JoinChannelOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.Join(options);
        }

        public override int Leave()
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.Leave();
        }

        public override int CreateTopic(string topic, CreateTopicOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.CreateTopic(topic, options);
        }

        public override int PublishTopic(string topic, string message, uint length)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.PublishTopic(topic, message, length);
        }

        public override int DestroyTopic(string topic)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.DestroyTopic(topic);
        }

        public override int SubscribeTopic(string topic, TopicOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.SubscribeTopic(topic, options);
        }

        public override int UnsubscribeTopic(string topic, TopicOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.UnsubscribeTopic(topic, options);
        }

        public override int GetSubscribedUserList(string topic, ref UserList[] users)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.GetSubscribedUserList(topic, ref users);
        }
    }
}