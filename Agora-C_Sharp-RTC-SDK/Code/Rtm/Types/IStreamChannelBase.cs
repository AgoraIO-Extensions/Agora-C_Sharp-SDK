using System;

namespace Agora.Rtm
{
    public enum RTM_MESSAGE_QOS
    {
        RTM_MESSAGE_QOS_UNORDERED = 0,

        RTM_MESSAGE_QOS_ORDERED = 1,
    };

    public class JoinChannelOptions
    {
        public string token { set; get; }
    };

    public class CreateTopicOptions
    {
        public CreateTopicOptions()
        {
            this.qos = RTM_MESSAGE_QOS.RTM_MESSAGE_QOS_ORDERED;
            this.meta = "";
            this.metaLength = 0;
        }
    
        public RTM_MESSAGE_QOS qos { set; get; }

        public string meta { set; get; }

        public uint metaLength { set; get; }
    };

    public class TopicOptions
    {
        public string[] users { set; get; }

        public uint userCount { set; get; }
    };

    public class UserList
    {
        public string[] users { set; get; }

        public uint userCount { set; get; }
    };
}