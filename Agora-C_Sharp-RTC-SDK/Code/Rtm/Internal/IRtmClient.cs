using System;
using System.Threading.Tasks;
namespace Agora.Rtm.Internal
{
    public abstract class IRtmClient
    {
        public abstract string GetVersion();

        public abstract int Dispose();

        public abstract int Login(string token, ref UInt64 requestId);

        public abstract int Logout(ref UInt64 requestId);

        public abstract IRtmStorage GetStorage();

        public abstract IRtmLock GetLock();

        public abstract IRtmPresence GetPresence();

        public abstract int RenewToken(string token, ref UInt64 requestId);

        public abstract int Publish(string channelName, byte[] message, int length, PublishOptions option, ref UInt64 requestId);

        public abstract int Publish(string channelName, string message, int length, PublishOptions option, ref UInt64 requestId);

        public abstract int Subscribe(string channelName, SubscribeOptions options, ref UInt64 requestId);

        public abstract int Unsubscribe(string channelName, ref UInt64 requestId);

        public abstract IStreamChannel CreateStreamChannel(string channelName, ref int errorCode);

        public abstract int SetParameters(string parameters);

        public abstract int SetLogFile(string filePath);

        public abstract int SetLogLevel(LOG_LEVEL level);

        public abstract int SetLogFileSize(uint fileSizeInKBytes);
    }
}