using System;

namespace Agora.Rtm
{
    public class RtmConfig
    {
        public string appId { set; get; }

        public string token { set; get; }

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
            this.fileSizeInKB = 0;
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
    ///
    /// <summary>
    /// The output log level of the SDK.
    /// </summary>
    ///
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
        public string topic { set; get; }

        public uint numOfPublisher { set; get; }

        public string[] publisherUserIds { set; get; }

        public string[] publisherMetas { set; get; }
    };

    public enum RTM_ERROR_CODE
    {
        RTM_ERROR_OK = 0,
        RTM_ERR_INVALID_ARGUMENT = 2,
        RTM_ERR_NOT_READY = 3,
        RTM_ERR_INVALID_APP_ID = 101,
        RTM_ERR_TOPIC_ALREADY_EXIST = 60001,
        RTM_ERR_RESOURCE_NOT_AVAILABLE = 60002,
        RTM_ERR_INVALID_TOPIC_NAME = 60003,
        RTM_ERR_PUBLISH_TOPIC_FAILED = 60004,
        RTM_ERR_EXCEED_TOPIC_LIMITATION = 60005,
        RTM_ERR_EXCEED_USER_LIMITATION = 60006,
        RTM_ERR_EXCEED_CHANNEL_LIMITATION = 60007,
        RTM_ERR_ALREADY_JOIN_CHANNEL = 60008,
        RTM_ERR_NOT_JOIN_CHANNEL = 60009,
    };

    public enum RTM_CHANNEL_CONNECTION_STATE
    {
        /**
        * 1: The SDK is disconnected from the server.
        */
        RTM_CHANNEL_CONNECTION_STATE_DISCONNECTED = 1,
        /**
        * 2: The SDK is connecting to the server.
        */
        RTM_CHANNEL_CONNECTION_STATE_CONNECTING = 2,
        /**
        * 3: The SDK is connected to the server and has joined a channel. You can now publish or subscribe to
        * a track in the channel.
        */
        RTM_CHANNEL_CONNECTION_STATE_CONNECTED = 3,
        /**
        * 4: The SDK keeps rejoining the channel after being disconnected from the channel, probably because of
        * network issues.
        */
        RTM_CHANNEL_CONNECTION_STATE_RECONNECTING = 4,
        /**
        * 5: The SDK fails to connect to the server or join the channel.
        */
        RTM_CHANNEL_CONNECTION_STATE_FAILED = 5,
    };

    public enum RTM_CHANNEL_CONNECTION_CHANGE_REASON
    {
        /**
        * 0: The SDK is connecting to the server.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_CONNECTING = 0,
        /**
        * 1: The SDK has joined the channel successfully.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_JOIN_SUCCESS = 1,
        /**
        * 2: The connection between the SDK and the server is interrupted.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_INTERRUPTED = 2,
        /**
        * 3: The connection between the SDK and the server is banned by the server.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_BANNED_BY_SERVER = 3,
        /**
        * 4: The SDK fails to join the channel for more than 20 minutes and stops reconnecting to the channel.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_JOIN_FAILED = 4,
        /**
        * 5: The SDK has left the channel.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_LEAVE_CHANNEL = 5,
        /**
        * 6: The connection fails because the App ID is not valid.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_INVALID_APP_ID = 6,
        /**
        * 7: The connection fails because the channel name is not valid.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_INVALID_CHANNEL_NAME = 7,
        /**
        * 8: The connection fails because the token is not valid.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_INVALID_TOKEN = 8,
        /**
        * 9: The connection fails because the token has expired.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_TOKEN_EXPIRED = 9,
        /**
        * 10: The connection is rejected by the server.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,
        /**
        * 11: The connection changes to reconnecting because the SDK has set a proxy server.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,
        /**
        * 12: When the connection state changes because the app has renewed the token.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_RENEW_TOKEN = 12,
        /**
        * 13: The IP Address of the app has changed. A change in the network type or IP/Port changes the IP
        * address of the app.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,
        /**
        * 14: A timeout occurs for the keep-alive of the connection between the SDK and the server.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,
        /**
        * 15: The SDK has rejoined the channel successfully.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_REJOIN_SUCCESS = 15,
        /**
        * 16: The connection between the SDK and the server is lost.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_LOST = 16,
        /**
        * 17: The change of connection state is caused by echo test.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_ECHO_TEST = 17,
        /**
        * 18: The local IP Address is changed by user.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,
        /**
        * 19: The connection is failed due to join the same channel on another device with the same uid.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_SAME_UID_LOGIN = 19,
        /**
        * 20: The connection is failed due to too many broadcasters in the channel.
        */
        RTM_CHANNEL_CONNECTION_CHANGED_TOO_MANY_BROADCASTERS = 20,
    };

    public enum RTM_PRESENCE_ACTION_RESULT
    {
        RTM_PRESENCE_GENERAL_OK_RESULT = 0,
        RTM_PRESENCE_SELF_JOIN_SUCCEED = 1,
        RTM_PRESENCE_SELF_REJOIN_SUCCEED = 2,
        RTM_PRESENCE_SELF_LEAVE_SUCCEED = 3,
        RTM_PRESENCE_REMOTE_JOINED = 4,
        RTM_PRESENCE_REMOTE_QUIT = 5,
        RTM_PRESENCE_REMOTE_DROPPED = 6,
        RTM_PRESENCE_JOIN_TOPIC_SUCCEED = 7,
        RTM_PRESENCE_LEAVE_TOPIC_SUCCEED = 8,
    };

    public enum RTM_CHANNEL_TYPE
    {
        RTM_CHANNEL_TYPE_MESSAGE = 0,

        RTM_CHANNEL_TYPE_STREAM = 1,
    };

    public enum RTM_PRESENCE_ACTION_TYPE
    {
        RTM_PRESENCE_ACTION_TYPE_GENERAL = 0,
        RTM_PRESENCE_ACTION_TYPE_SELF_JOIN = 1,
        RTM_PRESENCE_ACTION_TYPE_SELF_LEAVE = 2,
        RTM_PRESENCE_ACTION_TYPE_REMOTE_JOIN = 3,
        RTM_PRESENCE_ACTION_TYPE_REMOTE_LEAVE = 4,
        RTM_PRESENCE_ACTION_TYPE_JOIN_TOPIC = 5,
        RTM_PRESENCE_ACTION_TYPE_LEAVE_TOPIC = 6,
        RTM_PRESENCE_ACTION_TYPE_UPDATE_TOPIC = 7,
        RTM_PRESENCE_ACTION_TYPE_SUBSCRIBE_TOPIC = 8,
        RTM_PRESENCE_ACTION_TYPE_UNSUBSCRIBE_TOPIC = 9,
    };

    public class TopicSubUsersUpdated
    {
        public string topic { set; get; }

        public string[] succeedUsers { set; get; }

        public uint succeedUserCount { set; get; }

        public string[] failedUsers { set; get; }

        public uint failedUserCount { set; get; }
    };

    public class MessageEvent
    {
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
            this.channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
            this.action = RTM_PRESENCE_ACTION_TYPE.RTM_PRESENCE_ACTION_TYPE_GENERAL;
            this.result = RTM_PRESENCE_ACTION_RESULT.RTM_PRESENCE_GENERAL_OK_RESULT;
        }

        /**
        * Which channel type, messageChannel or streamChannel
        */
        public RTM_CHANNEL_TYPE channelType { set; get; }
        /**
        * Can be join, leave, state-change, or timeout for msChannel's and stChannel's presence event
        * Can be join-topic,leave-topic for Topic Presence event
        */
        public RTM_PRESENCE_ACTION_TYPE action { set; get; }
        /**
        * The channel to which the message was published
        */
        public string channelName { set; get; }
        /**
        * The number of users in channel
        */
        public int occupancy { set; get; }
        /**
        * topic information array.
        */
        public TopicInfo topicInfos { set; get; }
        /**
        * The number of topicInfo.
        */
        public uint topicInfoNumber { set; get; }
        /**
        * The ID of the user.
        */
        public string userId { set; get; }
        /**
        * the result infomation of subscribe topic operation.
        */
        public TopicSubUsersUpdated userInfos { set; get; }
        /**
        * presence action result.
        */
        public RTM_PRESENCE_ACTION_RESULT result { set; get; }
    };

    public class StatusEvent
    {
        public StatusEvent()
        {
            this.channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_STREAM;
            this.state = RTM_CHANNEL_CONNECTION_STATE.RTM_CHANNEL_CONNECTION_STATE_DISCONNECTED;
            this.reason = RTM_CHANNEL_CONNECTION_CHANGE_REASON.RTM_CHANNEL_CONNECTION_CHANGED_CONNECTING;
        }
        /**
        * Which channel type, messageChannel or streamChannel
        */
        public RTM_CHANNEL_TYPE channelType { set; get; }
        /**
        * The name of the channel.
        */
        public string channelName { set; get; }
        /**
        * The topics(local created) affected in the status change.
        */
        public string[] affectedTopics { set; get; }
        /**
        * The number of topics(local created) affected in the status change.
        */
        public uint affectedTopicCount { set; get; }
        /**
        * The topics(subscribed remote topic) affected in the status change.
        */
        public string[] subscribedTopics { set; get; }
        /**
        * The number of topics(subscribed remote topic) affected in the status change.
        */
        public uint subscribedTopicCount { set; get; }
        /**
        * connection states between sdk and server.
        */
        public RTM_CHANNEL_CONNECTION_STATE state { set; get; }
        /**
        * the reason for connection state change.
        */
        public RTM_CHANNEL_CONNECTION_CHANGE_REASON reason { set; get; }
    }
}


