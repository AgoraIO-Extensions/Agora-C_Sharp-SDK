using System;

namespace Agora.Rtm
{
    public class RtmConfig
    {
        public RtmConfig()
        {
            appId = "";
            userId = "";
            eventHandler = null;
            logConfig = new LogConfig();
        }

        public RtmConfig(string appId, string userId, IRtmEventHandler eventHandler, LogConfig logConfig)
        {
            this.appId = appId;
            this.userId = userId;
            this.eventHandler = eventHandler;
            this.logConfig = logConfig;
        }

        public string appId { set; get; }

        public string userId { set; get; }

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

    public class TopicInfo
    {
        public TopicInfo()
        {
            topic = "";
            numOfPublisher = 0;
            publisherUserIds = new string[0];
            publisherMetas = new string[0];
        }

        public TopicInfo(string topic, uint numOfPublisher, string[] publisherUserIds, string[] publisherMetas)
        {
            this.topic = topic;
            this.numOfPublisher = numOfPublisher;
            this.publisherUserIds = publisherUserIds;
            this.publisherMetas = publisherMetas;
        }

        public string topic { set; get; }

        public uint numOfPublisher { set; get; }

        public string[] publisherUserIds { set; get; }

        public string[] publisherMetas { set; get; }
    };

    public enum RTM_ERROR_CODE
    {
        RTM_ERR_TOPIC_ALREADY_EXIST = 10001,
        RTM_ERR_EXCEED_CREATE_TOPIC_LIMITATION = 10002,
        RTM_ERR_INVALID_TOPIC_NAME = 10003,
        RTM_ERR_PUBLISH_TOPIC_FAILED = 10004,
        RTM_ERR_EXCEED_SUBSCRIBE_TOPIC_LIMITATION = 10005,
        RTM_ERR_EXCEED_USER_LIMITATION = 10006,
        RTM_ERR_EXCEED_CHANNEL_LIMITATION = 10007,
        RTM_ERR_ALREADY_JOIN_CHANNEL = 10008,
        RTM_ERR_NOT_JOIN_CHANNEL = 10009,
    };

    public enum RTM_CONNECTION_STATE
    {
        /**
        * 1: The SDK is disconnected from the server.
        */
        RTM_CONNECTION_STATE_DISCONNECTED = 1,
        /**
        * 2: The SDK is connecting to the server.
        */
        RTM_CONNECTION_STATE_CONNECTING = 2,
        /**
        * 3: The SDK is connected to the server and has joined a channel. You can now publish or subscribe to
        * a track in the channel.
        */
        RTM_CONNECTION_STATE_CONNECTED = 3,
        /**
        * 4: The SDK keeps rejoining the channel after being disconnected from the channel, probably because of
        * network issues.
        */
        RTM_CONNECTION_STATE_RECONNECTING = 4,
        /**
        * 5: The SDK fails to connect to the server or join the channel.
        */
        RTM_CONNECTION_STATE_FAILED = 5,
    };

    public enum RTM_CONNECTION_CHANGE_REASON
    {
        /**
        * 0: The SDK is connecting to the server.
        */
        RTM_CONNECTION_CHANGE_CONNECTING = 0,
        /**
        * 1: The SDK has joined the channel successfully.
        */
        RTM_CONNECTION_CHANGE_JOIN_SUCCESS = 1,
        /**
        * 2: The connection between the SDK and the server is interrupted.
        */
        RTM_CONNECTION_CHANGE_INTERRUPTED = 2,
        /**
        * 3: The connection between the SDK and the server is banned by the server.
        */
        RTM_CONNECTION_CHANGE_BANNED_BY_SERVER = 3,
        /**
        * 4: The SDK fails to join the channel for more than 20 minutes and stops reconnecting to the channel.
        */
        RTM_CONNECTION_CHANGE_JOIN_FAILED = 4,
        /**
        * 5: The SDK has left the channel.
        */
        RTM_CONNECTION_CHANGE_LEAVE_CHANNEL = 5,
        /**
        * 6: The connection fails because the App ID is not valid.
        */
        RTM_CONNECTION_CHANGE_INVALID_APP_ID = 6,
        /**
        * 7: The connection fails because the channel name is not valid.
        */
        RTM_CONNECTION_CHANGE_INVALID_CHANNEL_NAME = 7,
        /**
        * 8: The connection fails because the token is not valid.
        */
        RTM_CONNECTION_CHANGE_INVALID_TOKEN = 8,
        /**
        * 9: The connection fails because the token has expired.
        */
        RTM_CONNECTION_CHANGE_TOKEN_EXPIRED = 9,
        /**
        * 10: The connection is rejected by the server.
        */
        RTM_CONNECTION_CHANGE_REJECTED_BY_SERVER = 10,
        /**
        * 11: The connection changes to reconnecting because the SDK has set a proxy server.
        */
        RTM_CONNECTION_CHANGE_SETTING_PROXY_SERVER = 11,
        /**
        * 12: When the connection state changes because the app has renewed the token.
        */
        RTM_CONNECTION_CHANGE_RENEW_TOKEN = 12,
        /**
        * 13: The IP Address of the app has changed. A change in the network type or IP/Port changes the IP
        * address of the app.
        */
        RTM_CONNECTION_CHANGE_CLIENT_IP_ADDRESS_CHANGED = 13,
        /**
        * 14: A timeout occurs for the keep-alive of the connection between the SDK and the server.
        */
        RTM_CONNECTION_CHANGE_KEEP_ALIVE_TIMEOUT = 14,
        /**
        * 15: The SDK has rejoined the channel successfully.
        */
        RTM_CONNECTION_CHANGE_REJOIN_SUCCESS = 15,
        /**
        * 16: The connection between the SDK and the server is lost.
        */
        RTM_CONNECTION_CHANGE_LOST = 16,
        /**
        * 17: The change of connection state is caused by echo test.
        */
        RTM_CONNECTION_CHANGE_ECHO_TEST = 17,
        /**
        * 18: The local IP Address is changed by user.
        */
        RTM_CONNECTION_CHANGE_CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,
        /**
        * 19: The connection is failed due to join the same channel on another device with the same uid.
        */
        RTM_CONNECTION_CHANGE_SAME_UID_LOGIN = 19,
        /**
        * 20: The connection is failed due to too many broadcasters in the channel.
        */
        RTM_CONNECTION_CHANGE_TOO_MANY_BROADCASTERS = 20,
    };

    public enum RTM_CHANNEL_TYPE
    {
        RTM_CHANNEL_TYPE_MESSAGE = 0,

        RTM_CHANNEL_TYPE_STREAM = 1,
    };

    public enum RTM_PRESENCE_TYPE
    {
        RTM_PRESENCE_TYPE_REMOTE_JOIN_CHANNEL = 0,
        RTM_PRESENCE_TYPE_REMOTE_LEAVE_CHANNEL = 1,
        RTM_PRESENCE_TYPE_REMOTE_CONNECTION_TIMEOUT = 2,
        RTM_PRESENCE_TYPE_REMOTE_JOIN_TOPIC = 3,
        RTM_PRESENCE_TYPE_REMOTE_LEAVE_TOPIC = 4,
        RTM_PRESENCE_TYPE_SELF_JOIN_CHANNEL = 5,
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
            message ="";
            publisher = "";
        }

        public MessageEvent(RTM_CHANNEL_TYPE channelType, string channelName, string channelTopic, string message, string publisher)
        {
            this.channelType = channelType;
            this.channelName = channelName;
            this.channelTopic = channelTopic;
            this.message = message;
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
        * The publisher
        */
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