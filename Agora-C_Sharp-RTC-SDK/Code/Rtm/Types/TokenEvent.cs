namespace Agora.Rtm
{
    public enum RTM_TOKEN_EVENT_TYPE
    {
        WILL_EXPIRE = 1,
        READ_PERMISSION_REVOKED = 2
    }

    public class ChannelList
    {
        public string[] channels = new string[0];
        public ulong count;
    }

    public class AffectedResources
    {
        public ChannelList messageChannels = new ChannelList();
    }

    public class TokenEvent
    {
        public RTM_TOKEN_EVENT_TYPE eventType = RTM_TOKEN_EVENT_TYPE.WILL_EXPIRE;
        public string reason;
        public AffectedResources affectedResources = new AffectedResources();
        public ulong timestamp;
    }
}
