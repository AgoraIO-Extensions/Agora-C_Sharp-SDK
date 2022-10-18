namespace Agora.Rtm
{
    public abstract class IRtmClient
    {
        public abstract int Initialize(RtmConfig config);

        public abstract int Release();

        public abstract IStreamChannel CreateStreamChannel(string channelName);
    }
}