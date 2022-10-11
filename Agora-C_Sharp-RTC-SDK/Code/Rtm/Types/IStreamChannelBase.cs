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
        public JoinChannelOptions()
        {
            this.token = "";
        }
        public string token { set; get; }
    };

    public class JoinTopicOptions
    {
        public JoinTopicOptions()
        {
            this.qos = RTM_MESSAGE_QOS.RTM_MESSAGE_QOS_ORDERED;
            this.meta = IntPtr.Zero;
            this.metaLength = 0;
        }

        public JoinTopicOptions(RTM_MESSAGE_QOS qos, IntPtr meta, uint metaLength)
        {
            this.qos = qos;
            this.meta = meta;
            this.metaLength = metaLength;
        }
    
        public RTM_MESSAGE_QOS qos { set; get; }

        public IntPtr meta { set; get; }

        public uint metaLength { set; get; }
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

        public string[] users { set; get; }

        public uint userCount { set; get; }
    };

    public class UserList
    {
        public UserList()
        {
            users = new string[0];
            userCount = 0;
        }

        public UserList(string[] users, uint userCount)
        {
            this.users = users;
            this.userCount = userCount;
        }

        public string[] users { set; get; }

        public uint userCount { set; get; }
    };
}