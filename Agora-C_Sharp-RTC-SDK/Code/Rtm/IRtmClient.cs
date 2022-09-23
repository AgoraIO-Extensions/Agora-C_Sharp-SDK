namespace Agora.Rtm
{
    public abstract class IRtmClient
    {
        public abstract int Initialize(RtmConfig config);

        public abstract void Dispose();

        public abstract IStreamChannel CreateStreamChannel(string channelName);

        public abstract void ReleaseStreamChannel(IStreamChannel channel);
    }
}