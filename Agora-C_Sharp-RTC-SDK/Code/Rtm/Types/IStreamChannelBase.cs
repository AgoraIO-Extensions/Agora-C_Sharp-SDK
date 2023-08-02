using System;

namespace Agora.Rtm
{
    /**
     * The qos of rtm message.
    */
    public enum RTM_MESSAGE_QOS
    {
        /**
        * Will not ensure that messages arrive in order.
        */
        UNORDERED = 0,
        /**
        * Will ensure that messages arrive in order.
        */
        ORDERED = 1,
    };

    /**
    * The priority of rtm message.
    */
    public enum RTM_MESSAGE_PRIORITY
    {
        /**
        * The highest priority
        */
        HIGHEST = 0,

        /**
        * The high priority
        */
        HIGH = 1,

        /**
        * The normal priority (Default)
        */
        NORMAL = 4,

        /**
        * The low priority
        */
        LOW = 8,
    };

    /**
    * Join channel options.
    */
    public class JoinChannelOptions
    {
        public JoinChannelOptions()
        {
            token = "";
            withMetadata = false;
            withPresence = true;
            withLock = false;
        }

        /**
        * Token used to join channel.
        */
        public string token;

        /**
        * Whether to subscribe channel metadata information
        */
        public bool withMetadata;

        /**
        * Whether to subscribe channel with user presence
        */
        public bool withPresence;

        /**
        * Whether to subscribe channel with lock
        */
        public bool withLock;
    };

    /**
    * Join topic options.
    */
    public class JoinTopicOptions
    {
        public JoinTopicOptions()
        {
            this.qos = RTM_MESSAGE_QOS.ORDERED;
            this.priority = RTM_MESSAGE_PRIORITY.NORMAL;
            this.meta = "";
            this.syncWithMedia = true;
        }

        /**
        * The qos of rtm message.
        */
        public RTM_MESSAGE_QOS qos;

        /**
        * The priority of rtm message.
        */
        public RTM_MESSAGE_PRIORITY priority;

        /**
        * The metaData of topic.
        */
        public string meta;

        /**
        * The rtm data will sync with media
        */
        public bool syncWithMedia;
    };

    /**
    * Topic options.
    */
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

        /**
        * The list of users to subscribe.
        */
        public string[] users;
    };


}