using System;
namespace Agora.Rtm.Internal
{
    public class PublishOptions
    {
        public RTM_CHANNEL_TYPE channelType;

        public RTM_MESSAGE_TYPE messageType;

        public string customType;

        public PublishOptions()
        {
        }

        public PublishOptions(Agora.Rtm.PublishOptions options, RTM_MESSAGE_TYPE messageType)
        {
            this.messageType = messageType;
            this.channelType = options.channelType;
            this.customType = options.customType;
        }
    };

    public class TopicMessageOptions
    {
        public RTM_MESSAGE_TYPE messageType;

        public UInt64 sendTs;

        public string customType;

        public TopicMessageOptions()
        {

        }

        public TopicMessageOptions(Agora.Rtm.TopicMessageOptions options, RTM_MESSAGE_TYPE messageType)
        {
            this.messageType = messageType;
            this.sendTs = options.sendTs;
            this.customType = options.customType;
        }
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

        public string[] users;

        public uint userCount;
    };

}
