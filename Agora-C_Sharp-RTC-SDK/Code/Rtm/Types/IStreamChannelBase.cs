using System;

namespace Agora.Rtm
{
    public enum RTM_MESSAGE_QOS
    {
        UNORDERED = 0,

        ORDERED = 1,
    };

    public enum RTM_MESSAGE_PRIORITY
    {
        HIGHEST = 0,

        HIGH = 1,

        NORMAL = 4,

        LOW = 8,
    };

    public class JoinChannelOptions
    {
        public JoinChannelOptions()
        {
            token = "";
            withMetadata = false;
            withPresence = true;
            withLock = false;
        }
        public string token;

        public bool withMetadata;

        public bool withPresence;

        public bool withLock;
    };

    public class JoinTopicOptions
    {
        public JoinTopicOptions()
        {
            this.qos = RTM_MESSAGE_QOS.ORDERED;
            this.priority = RTM_MESSAGE_PRIORITY.NORMAL;
            this.meta = "";
            this.syncWithMedia = true;
        }

        public RTM_MESSAGE_QOS qos;

        public RTM_MESSAGE_PRIORITY priority;

        public string meta;

        public bool syncWithMedia;
    };

    public class TopicOptions
    {
        public TopicOptions()
        {
            users = new string[0];
        }

        public TopicOptions(string[] users, uint userCount)
        {
            this.users = users;
        }

        public string[] users;
    };


}