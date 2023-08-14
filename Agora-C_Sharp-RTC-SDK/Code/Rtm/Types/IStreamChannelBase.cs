using System;

namespace Agora.Rtm
{
    ///
    /// <summary>
    /// The qos of rtm message.
    /// </summary>
    ///
    public enum RTM_MESSAGE_QOS
    {
        ///
        /// <summary>
        /// Will not ensure that messages arrive in order.
        /// </summary>
        ///
        UNORDERED = 0,
        ///
        /// <summary>
        /// Will ensure that messages arrive in order.
        /// </summary>
        ///
        ORDERED = 1,
    }

    ///
    /// <summary>
    /// The priority of rtm message.
    /// </summary>
    ///
    public enum RTM_MESSAGE_PRIORITY
    {
        ///
        /// <summary>
        /// The highest priority
        /// </summary>
        ///
        HIGHEST = 0,

        ///
        /// <summary>
        /// The high priority
        /// </summary>
        ///
        HIGH = 1,

        ///
        /// <summary>
        /// The normal priority (Default)
        /// </summary>
        ///
        NORMAL = 4,

        ///
        /// <summary>
        /// The low priority
        /// </summary>
        ///
        LOW = 8,
    }

    ///
    /// <summary>
    /// Join channel options.
    /// </summary>
    ///
    public class JoinChannelOptions
    {
        public JoinChannelOptions()
        {
            token = "";
            withMetadata = false;
            withPresence = true;
            withLock = false;
        }

        ///
        /// <summary>
        /// Token used to join channel.
        /// </summary>
        ///
        public string token;

        ///
        /// <summary>
        /// Whether to subscribe channel metadata information
        /// </summary>
        ///
        public bool withMetadata;

        ///
        /// <summary>
        /// Whether to subscribe channel with user presence
        /// </summary>
        ///
        public bool withPresence;

        ///
        /// <summary>
        /// Whether to subscribe channel with lock
        /// </summary>
        ///
        public bool withLock;
    };

    ///
    /// <summary>
    /// Join topic options.
    /// </summary>
    ///
    public class JoinTopicOptions
    {
        public JoinTopicOptions()
        {
            this.qos = RTM_MESSAGE_QOS.ORDERED;
            this.priority = RTM_MESSAGE_PRIORITY.NORMAL;
            this.meta = "";
            this.syncWithMedia = true;
        }

        ///
        /// <summary>
        /// The qos of rtm message.
        /// </summary>
        ///
        public RTM_MESSAGE_QOS qos;

        ///
        /// <summary>
        /// The priority of rtm message.
        /// </summary>
        ///
        public RTM_MESSAGE_PRIORITY priority;

        ///
        /// <summary>
        /// The metaData of topic.
        /// </summary>
        ///
        public string meta;

        ///
        /// <summary>
        /// The rtm data will sync with media
        /// </summary>
        ///
        public bool syncWithMedia;
    };

    ///
    /// <summary>
    /// Topic options.
    /// </summary>
    ///
    public class TopicOptions
    {
        public TopicOptions()
        {
            users = new string[0];
        }

        public TopicOptions(string[] users)
        {
            this.users = users;
        }

        ///
        /// <summary>
        /// The list of users to subscribe.
        /// </summary>
        ///
        public string[] users;
    };

}