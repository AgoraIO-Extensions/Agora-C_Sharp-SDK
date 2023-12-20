using System;
using System.Collections.Generic;

namespace Agora.Rtm.Internal
{
    public sealed class RtmClient : Internal.IRtmClient, IStreamChannelCreator
    {
        private bool _disposed = false;
        private RtmClientImpl _rtmClientImpl = null;
        private const int ErrorCode = (int)RTM_ERROR_CODE.NOT_INITIALIZED;
        internal Dictionary<string, StreamChannel> _streamChannelDic = new Dictionary<string, StreamChannel>();

        private RtmLock _rtmLock = null;
        private RtmPresence _rtmPresence = null;
        private RtmStorage _rtmStorage = null;

        private RtmClient(IntPtr engine_ptr)
        {
            _rtmClientImpl = RtmClientImpl.GetInstance(engine_ptr);
            _rtmLock = RtmLock.GetInstance(_rtmClientImpl.GetRtmLockImpl());
            _rtmPresence = RtmPresence.GetInstance(_rtmClientImpl.GetRtmPresenceImpl());
            _rtmStorage = RtmStorage.GetInstance(_rtmClientImpl.GetRtmStorageImpl());
        }

        ~RtmClient()
        {
            Dispose();
        }

        private static IRtmClient instance = null;

        public static IRtmClient CreateAgoraRtmClient()
        {
            return instance ?? (instance = new RtmClient(IntPtr.Zero));
        }

        public static IRtmClient CreateAgoraRtmClient(IntPtr engine_ptr)
        {
            return instance ?? (instance = new RtmClient(engine_ptr));
        }

        public static IRtmClient GetInstance()
        {
            return instance;
        }

        public override int Dispose()
        {
            if (_disposed)
                return 0;

            GC.SuppressFinalize(this);

            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }

            _streamChannelDic.Clear();

            RtmLock.ReleaseInstance();
            RtmPresence.ReleaseInstance();
            RtmStorage.ReleaseInstance();

            _rtmClientImpl.Dispose();
            _rtmClientImpl = null;

            instance = null;
            _disposed = true;
            return 0;
        }

        public override int Initialize(RtmConfig config)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.Initialize(config);
        }

        public override string GetVersion()
        {
            if (_rtmClientImpl == null)
            {
                return "";
            }
            return _rtmClientImpl.GetVersion();
        }

        public override IStreamChannel CreateStreamChannel(string channelName)
        {
            if (_rtmClientImpl == null)
            {
                return null;
            }

            if (_streamChannelDic.ContainsKey(channelName))
            {
                return _streamChannelDic[channelName];
            }

            int ret = _rtmClientImpl.CreateStreamChannel(channelName);
            if (ret != 0)
            {
                return null;
            }

            StreamChannel streamChannel = new StreamChannel(this, _rtmClientImpl.GetStreamChannelImpl(), channelName);
            _streamChannelDic.Add(channelName, streamChannel);
            return streamChannel;
        }

        public override int Login(string token)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.Login(token);
        }

        public override int Logout()
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.Logout();
        }

        public override IRtmStorage GetStorage()
        {
            if (_rtmClientImpl == null)
            {
                return null;
            }

            return _rtmStorage;
        }

        public override IRtmLock GetLock()
        {
            if (_rtmClientImpl == null)
            {
                return null;
            }
            return _rtmLock;
        }

        public override IRtmPresence GetPresence()
        {
            if (_rtmClientImpl == null)
            {
                return null;
            }
            return _rtmPresence;
        }

        public override int RenewToken(string token)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.RenewToken(token);
        }

        public override int Publish(string channelName, byte[] message, int length, PublishOptions option, ref UInt64 requestId)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.Publish(channelName, message, message.Length, option, ref requestId);
        }

        public override int Publish(string channelName, string message, int length, PublishOptions option, ref UInt64 requestId)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);
            return _rtmClientImpl.Publish(channelName, bytes, bytes.Length, option, ref requestId);
        }

        public override int Subscribe(string channelName, SubscribeOptions options, ref UInt64 requestId)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.Subscribe(channelName, options, ref requestId);
        }

        public override int Unsubscribe(string channelName)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.Unsubscribe(channelName);
        }

        public override int SetParameters(string parameters)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.SetParameters(parameters);
        }

        public void RemoveStreamChannelIfExist(string channelName)
        {
            if (this._streamChannelDic.ContainsKey(channelName))
            {
                this._streamChannelDic.Remove(channelName);
            }
        }

        public override int SetLogFile(string filePath)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.SetLogFile(filePath);
        }

        public override int SetLogLevel(LOG_LEVEL level)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.SetLogLevel(level);
        }

        public override int SetLogFileSize(uint fileSizeInKBytes)
        {
            if (_rtmClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtmClientImpl.SetLogFileSize(fileSizeInKBytes);
        }
    }
}