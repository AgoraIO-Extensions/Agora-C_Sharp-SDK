using System;
using System.Collections.Generic;

namespace Agora.Rtm
{
    public sealed class RtmClient : IRtmClient
    {
        private bool _disposed = false;
        private RtmClientImpl _rtcClientImpl = null;
        private const int ErrorCode = -7;
        internal Dictionary<string, StreamChannel> _streamChannelDic = new Dictionary<string, StreamChannel>();

        private RtmLock _rtmLock = null;
        private RtmPresence _rtmPresence = null;
        private RtmStorage _rtmStorage = null;

        private RtmClient()
        {
            _rtcClientImpl = RtmClientImpl.GetInstance();
            _rtmLock = RtmLock.GetInstance(_rtcClientImpl.GetRtmLockImpl());
            _rtmPresence = RtmPresence.GetInstance(_rtcClientImpl.GetRtmPresenceImpl());
            _rtmStorage = RtmStorage.GetInstance(_rtcClientImpl.GetRtmStorageImpl());
        }

        ~RtmClient()
        {
            Dispose();
        }

        private static IRtmClient instance = null;

        public static IRtmClient CreateAgoraRtmClient()
        {
            return instance ?? (instance = new RtmClient());
        }

        public override int Dispose()
        {
            if (_disposed) return 0;

            GC.SuppressFinalize(this);

            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }

            _streamChannelDic.Clear();

            RtmLock.ReleaseInstance();
            RtmPresence.ReleaseInstance();
            RtmStorage.ReleaseInstance();

            _rtcClientImpl.Dispose();
            _rtcClientImpl = null;

            instance = null;
            _disposed = true;
            return 0;
        }


        public override int Initialize(RtmConfig config)
        {
            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.Initialize(config);
        }

        public override IStreamChannel CreateStreamChannel(string channelName)
        {
            if (_rtcClientImpl == null)
            {
                return null;
            }

            if (_streamChannelDic.ContainsKey(channelName))
            {
                return _streamChannelDic[channelName];
            }

            int ret = _rtcClientImpl.CreateStreamChannel(channelName);
            if (ret != 0)
            {
                return null;
            }

            StreamChannel streamChannel = new StreamChannel(this, _rtcClientImpl.GetStreamChannelImpl(), channelName);
            _streamChannelDic.Add(channelName, streamChannel);
            return streamChannel;
        }


        public override int Login(string token)
        {
            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.Login(token);
        }

        public override int Logout()
        {
            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.Logout();
        }

        public override IRtmStorage GetStorage()
        {
            if (_rtcClientImpl == null)
            {
                return null;
            }

            return _rtmStorage;
        }

        public override IRtmLock GetLock()
        {
            if (_rtcClientImpl == null)
            {
                return null;
            }
            return _rtmLock;
        }

        public override IRtmPresence GetPresence()
        {
            if (_rtcClientImpl == null)
            {
                return null;
            }
            return _rtmPresence;
        }

        public override int RenewToken(string token)
        {
            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.RenewToken(token);
        }

        public override int Publish(string channelName, string message, UInt64 length, PublishOptions option, ref UInt64 requestId)
        {
            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.Publish(channelName, message, length, option, ref requestId);
        }

        public override int Subscribe(string channelName, SubscribeOptions options, ref UInt64 requestId)
        {
            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.Subscribe(channelName, options, ref requestId);
        }

        public override int Unsubscribe(string channelName)
        {
            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.Unsubscribe(channelName);
        }

        public override int SetParameters(string parameters)
        {
            if (_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.SetParameters(parameters);
        }
    }
}