using System;
namespace Agora.Rtm
{
    public abstract class IRtmClient
    {
        public abstract int Initialize(RtmConfig config);

        public abstract int Release();

        public abstract int Login(string token);

        public abstract int Logout();

        public abstract IRtmStorage GetStorage();

        public abstract IRtmLock GetLock();

        public abstract IRtmPresence GetPresence();

        public abstract int RenewToken(string token);

        public abstract int Publish(string channelName, string message, UInt64 length, PublishOptions option, ref UInt64 requestId);

        public abstract int Subscribe(string channelName, SubscribeOptions options, ref UInt64 requestId);

        public abstract int Unsubscribe(string channelName);

        public abstract IStreamChannel CreateStreamChannel(string channelName);

        public abstract int SetParameters(string parameters);
    }
}