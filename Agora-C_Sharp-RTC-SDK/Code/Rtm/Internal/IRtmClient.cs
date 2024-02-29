using System;
using System.Threading.Tasks;
namespace Agora.Rtm.Internal
{
    public abstract class IRtmClient
    {
        public abstract int Initialize(RtmConfig config);

        public abstract string GetVersion();

        public abstract int Dispose();

        public abstract int Login(string token);

        public abstract int Logout();

        public abstract IRtmStorage GetStorage();

        public abstract IRtmLock GetLock();

        public abstract IRtmPresence GetPresence();

        public abstract int RenewToken(string token);

        public abstract int Publish(string channelName, byte[] message, int length, PublishOptions option, ref UInt64 requestId);

        public abstract int Publish(string channelName, string message, int length, PublishOptions option, ref UInt64 requestId);

        public abstract int Subscribe(string channelName, SubscribeOptions options, ref UInt64 requestId);

        public abstract int Unsubscribe(string channelName);

        public abstract IStreamChannel CreateStreamChannel(string channelName);

        public abstract int SetParameters(string parameters);

        public abstract int SetLogFile(string filePath);

        public abstract int SetLogLevel(LOG_LEVEL level);

        public abstract int SetLogFileSize(uint fileSizeInKBytes);
    }
}