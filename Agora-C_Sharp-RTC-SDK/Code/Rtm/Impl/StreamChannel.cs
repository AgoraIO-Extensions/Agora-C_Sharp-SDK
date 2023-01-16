using System;

namespace Agora.Rtm
{
    public sealed class StreamChannel : IStreamChannel
    {
        private bool _disposed = false;
        private RtmClient _rtmClientInstance = null;
        private StreamChannelImpl _streamChannelImpl = null;
        private const int ErrorCode = -7;

        private string channelName = "";

        internal StreamChannel(RtmClient rtmClient, StreamChannelImpl impl, string channelName)
        {
            _rtmClientInstance = rtmClient;
            _streamChannelImpl = impl;

            this.channelName = channelName;
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

            if (_rtmClientInstance._streamChannelDic.ContainsKey(channelName))
            {
                _rtmClientInstance._streamChannelDic.Remove(channelName);
            }

            _streamChannelImpl = null;
            _rtmClientInstance = null;
            channelName = "";
            _disposed = true;
        }

        public override int Dispose()
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            int ret = _streamChannelImpl.Release(channelName);
            Dispose(true);
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

        public override int Join(JoinChannelOptions options, ref UInt64 requestId)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.Join(channelName, options, ref requestId);
        }

        public override int Leave(ref UInt64 requestId)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.Leave(channelName, ref requestId);
        }

        public override int JoinTopic(string topic, JoinTopicOptions options, ref UInt64 requestId)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.JoinTopic(channelName, topic, options, ref requestId);
        }

        public override int PublishTopicMessage(string topic, byte[] message, int length, PublishOptions option)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.PublishTopicMessage(channelName, topic, message, message.Length, option);
        }

        public override int PublishTopicMessage(string topic, string message, int length, PublishOptions option)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            byte[] bytes = System.Text.Encoding.Default.GetBytes(message);
            return _streamChannelImpl.PublishTopicMessage(channelName, topic, bytes, bytes.Length, option);
        }

        public override int LeaveTopic(string topic, ref UInt64 requestId)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.LeaveTopic(channelName, topic, ref requestId);
        }

        public override int SubscribeTopic(string topic, TopicOptions options, ref UInt64 requestId)
        {
            if (_rtmClientInstance == null || _streamChannelImpl == null)
            {
                return ErrorCode;
            }
            return _streamChannelImpl.SubscribeTopic(channelName, topic, options, ref requestId);
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