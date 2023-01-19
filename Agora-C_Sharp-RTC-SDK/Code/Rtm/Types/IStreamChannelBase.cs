using System;

namespace Agora.Rtm
{
    public enum RTM_MESSAGE_QOS
    {
        RTM_MESSAGE_QOS_UNORDERED = 0,

        RTM_MESSAGE_QOS_ORDERED = 1,
    };

    public enum RTM_MESSAGE_PRIORITY
    {
        RTM_MESSAGE_PRIORITY_HIGHEST = 0,
      
        RTM_MESSAGE_PRIORITY_HIGH = 1,
       
        RTM_MESSAGE_PRIORITY_NORMAL = 4,
       
        RTM_MESSAGE_PRIORITY_LOW = 8,
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
            this.qos = RTM_MESSAGE_QOS.RTM_MESSAGE_QOS_ORDERED;
            this.priority = RTM_MESSAGE_PRIORITY.RTM_MESSAGE_PRIORITY_NORMAL;
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
            userCount = 0;
        }

        public TopicOptions(string[] users, uint userCount)
        {
            this.users = users;
            this.userCount = userCount;
        }

        public string[] users;

        public uint userCount;
    };

  
}