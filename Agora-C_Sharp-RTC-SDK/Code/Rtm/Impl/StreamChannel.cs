using System;

namespace Agora.Rtm
{
    public sealed class StreamChannel : IStreamChannel
    {
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
            _streamChannelImpl = null;
            _rtmClientInstance = null;
            channelName = "";
        }

        public override string ChannelName()
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

        public override int CreateTopic(string topic, CreateTopicOptions options)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.CreateTopic(channelName, topic, options);
        }

        public override int PublishTopic(string topic, string message, uint length)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.PublishTopic(channelName, topic, message, length);
        }

        public override int DestroyTopic(string topic)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.DestroyTopic(channelName, topic);
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

        public override int GetSubscribedUserList(string topic, ref UserList[] users)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.GetSubscribedUserList(channelName, topic, ref users);
        }
    }
}