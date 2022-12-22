using System;

namespace Agora.Rtm
{
    public class RtmConfig
    {
        public RtmConfig()
        {
            appId = "";
            userId = "";
            useStringUserId = true;
            eventHandler = null;
            logConfig = new LogConfig();
        }

        public RtmConfig(string appId, string userId, IRtmEventHandler eventHandler, LogConfig logConfig, bool useStringUserId = true)
        {
            this.appId = appId;
            this.userId = userId;
            this.useStringUserId = useStringUserId;
            this.eventHandler = eventHandler;
            this.logConfig = logConfig;
        }

        public string appId { set; get; }

        public string userId { set; get; }

        public bool useStringUserId { set; get; }

        public IRtmEventHandler eventHandler { set; get; }

        public LogConfig logConfig { set; get; }
    };

    ///
    /// <summary>
    /// Configuration of Agora SDK log files.
    /// </summary>
    ///
    public class LogConfig
    {
        public LogConfig()
        {
            filePath = "";
            fileSizeInKB = 0;
            level = LOG_LEVEL.LOG_LEVEL_INFO;
        }

        public LogConfig(string filePath, uint fileSize = 1024, LOG_LEVEL level = LOG_LEVEL.LOG_LEVEL_INFO)
        {
            this.filePath = filePath;
            this.fileSizeInKB = fileSize;
            this.level = level;
        }

        ///
        /// <summary>
        /// The complete path of the log files. Ensure that the path for the log file exists and is writable. You can use this parameter to rename the log files.The default file path is:Android：/storage/emulated/0/Android/data/<packagename>/files/agorasdk.log.iOS：App Sandbox/Library/caches/agorasdk.log.macOSIf Sandbox is enabled: App~/Library/Logs/agorasdk.log. For example, /Users/<username>/Library/Containers/<AppBundleIdentifier>/Data/Library/Logs/agorasdk.log.If Sandbox is disabled: ~/Library/Logs/agorasdk.log.Windows：C:\Users\<user_name>\AppData\Local\Agora\<process_name>\agorasdk.log。
        /// </summary>
        ///
        public string filePath { set; get; }

        ///
        /// <summary>
        /// The size (KB) of an agorasdk.log file. The value range is [128,1024]. The default value is 1,024 KB. If you set fileSizeInKByte to a value lower than 128 KB, the SDK adjusts it to 128 KB. If you set fileSizeInKBytes to a value higher than 1,024 KB, the SDK adjusts it to 1,024 KB.
        /// </summary>
        ///
        public uint fileSizeInKB { set; get; }

        ///
        /// <summary>
        /// The output level of the SDK log file. See LOG_LEVEL .For example, if you set the log level to WARN, the SDK outputs the logs within levels FATAL, ERROR, and WARN.
        /// </summary>
        ///
        public LOG_LEVEL level { set; get; }
    };

    [Flags]
    public enum LOG_LEVEL
    {
        ///
        /// <summary>
        /// 0: Do not output any log information.
        /// </summary>
        ///
        LOG_LEVEL_NONE = 0x0000,

        ///
        /// <summary>
        /// 0x0001: (Default) Output FATAL, ERROR, WARN, and INFO level log information. We recommend setting your log filter to this level.
        /// </summary>
        ///
        LOG_LEVEL_INFO = 0x0001,

        ///
        /// <summary>
        /// 0x0002: Output FATAL, ERROR, and WARN level log information.
        /// </summary>
        ///
        LOG_LEVEL_WARN = 0x0002,

        ///
        /// <summary>
        /// 0x0004: Output FATAL and ERROR level log information.
        /// </summary>
        ///
        LOG_LEVEL_ERROR = 0x0004,

        ///
        /// <summary>
        /// 0x0008: Output FATAL level log information.
        /// </summary>
        ///
        LOG_LEVEL_FATAL = 0x0008,
    };

   
    public enum STREAM_CHANNEL_ERROR_CODE
    {
        STREAM_CHANNEL_ERROR_OK = 0,
        STREAM_CHANNEL_ERROR_INVALID_ARGUMENT = 1,
        STREAM_CHANNEL_ERROR_JOIN_FAILURE = 2,
        STREAM_CHANNEL_ERROR_JOIN_REJECTED = 3,
        STREAM_CHANNEL_ERROR_REJOIN_FAILURE = 4,
        STREAM_CHANNEL_ERROR_LEAVE_FAILURE = 5,
        STREAM_CHANNEL_ERROR_EXCEED_LIMITATION = 6,
    };

    public class TopicSubUsersUpdated
    {
        public TopicSubUsersUpdated()
        {
            topic = "";
            succeedUserCount = 0;
            succeedUsers = new string[0];
            failedUserCount = 0;
            failedUsers = new string[0];
        }

        public TopicSubUsersUpdated(string topic, string[] succeedUsers, uint succeedUserCount, string[] failedUsers, uint failedUserCount)
        {
            this.topic = topic;
            this.succeedUserCount = succeedUserCount;
            this.succeedUsers = succeedUsers;
            this.failedUserCount = failedUserCount;
            this.failedUsers = failedUsers;
        }

        public string topic { set; get; }

        public string[] succeedUsers { set; get; }

        public uint succeedUserCount { set; get; }

        public string[] failedUsers { set; get; }

        public uint failedUserCount { set; get; }
    };

    public class MessageEvent
    {
        public MessageEvent()
        {
            channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_MESSAGE;
            channelName = "";
            channelTopic = "";
            message = "";
            messageLength = 0;
            publisher = "";
        }

        public MessageEvent(RTM_CHANNEL_TYPE channelType, string channelName, string channelTopic, string message, uint messageLength, string publisher)
        {
            this.channelType = channelType;
            this.channelName = channelName;
            this.channelTopic = channelTopic;
            this.message = message;
            this.messageLength = messageLength;
            this.publisher = publisher;
        }

        /**
        * Which channel type, messageChannel or streamChannel
        */
        public RTM_CHANNEL_TYPE channelType { set; get; }
        /**
        * The channel to which the message was published
        */
        public string channelName { set; get; }
        /**
        * If the channelType is stChannel, which topic the message come from. only for stChannel type
        */
        public string channelTopic { set; get; }
        /**
        * The payload
        */
        public string message { set; get; }
        /**
        * The payload length
        */
        public uint messageLength { set; get; }
        /**
        * The publisher
        */
        public string publisher { set; get; }
    };

    internal class MessageEventInternal
    {
        public RTM_CHANNEL_TYPE channelType { set; get; }

        public string channelName { set; get; }

        public string channelTopic { set; get; }

        public UInt64 message { set; get; }

        public uint messageLength { set; get; }

        public string publisher { set; get; }
    };

    public class PresenceEvent
    {
        public PresenceEvent()
        {
            channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
            type = RTM_PRESENCE_TYPE.RTM_PRESENCE_TYPE_REMOTE_JOIN_CHANNEL;
            channelName = "";
            topicInfos = new TopicInfo[0];
            topicInfoNumber = 0;
            userId = "";
        }

        public PresenceEvent(RTM_CHANNEL_TYPE channelType, RTM_PRESENCE_TYPE type, string channelName, TopicInfo[] topicInfos, uint topicInfoNumber, string userId)
        {
            this.channelType = channelType;
            this.type = type;
            this.channelName = channelName;
            this.topicInfos = topicInfos;
            this.topicInfoNumber = topicInfoNumber;
            this.userId = userId;
        }

        /**
        * Which channel type, messageChannel or streamChannel
        */
        public RTM_CHANNEL_TYPE channelType { set; get; }
        /**
        * Can be join, leave, state-change, or timeout for msChannel's and stChannel's presence event
        * Can be join-topic,leave-topic for Topic Presence event
        */
        public RTM_PRESENCE_TYPE type { set; get; }
        /**
        * The channel to which the message was published
        */
        public string channelName { set; get; }
        /**
        * topic information array.
        */
        public TopicInfo[] topicInfos { set; get; }
        /**
        * The number of topicInfo.
        */
        public uint topicInfoNumber { set; get; }
        /**
        * The ID of the user.
        */
        public string userId { set; get; }
    };
}