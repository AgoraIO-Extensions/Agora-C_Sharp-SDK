using System;

namespace Agora.Rtm
{
    public class RtmConfig
    {
        public RtmConfig()
        {
            appId = "";
            userId = "";
            areaCode = RTM_AREA_CODE.RTM_AREA_CODE_GLOB;
            presenceTimeout = 300;
            useStringUserId = true;
            logConfig = new RtmLogConfig();
            proxyConfig = new RtmProxyConfig();
            encryptionConfig = new RtmEncryptionConfig();
        }

        public RtmConfig(string appId, string userId, RTM_AREA_CODE areaCode, RtmLogConfig logConfig, RtmProxyConfig proxyConfig, RtmEncryptionConfig encryptionConfig)
        {
            this.appId = appId;
            this.userId = userId;
            this.areaCode = areaCode;
            this.logConfig = logConfig;
            this.proxyConfig = proxyConfig;
            this.encryptionConfig = encryptionConfig;
        }

        public string appId;

        public string userId;

        public RTM_AREA_CODE areaCode;

        public UInt32 presenceTimeout;

        public bool useStringUserId;

        public RtmLogConfig logConfig;

        public RtmProxyConfig proxyConfig;

        public RtmEncryptionConfig encryptionConfig;
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

        LOG_LEVEL_API_CALL = 0x0010,
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

        public string topic;

        public string[] succeedUsers;

        public uint succeedUserCount;

        public string[] failedUsers;

        public uint failedUserCount;
    };

    public class MessageEvent
    {
        public MessageEvent()
        {
            channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_MESSAGE;
            messageType = RTM_MESSAGE_TYPE.RTM_MESSAGE_TYPE_BINARY;
            channelName = "";
            channelTopic = "";
            message = null;
            messageLength = 0;
            publisher = "";
            customType = "";
        }

        public RTM_CHANNEL_TYPE channelType;

        public RTM_MESSAGE_TYPE messageType;

        public string channelName;

        public string channelTopic;

        public IRtmMessage message;

        public uint messageLength;

        public string publisher;

        public string customType;
    };


    public class IntervalInfo
    {
        public UserList joinUserList;

        public UserList leaveUserList;

        public UserList timeoutUserList;

        public UserState[] userStateList;

        public UInt64 userStateCount;

        public IntervalInfo()
        {
            userStateList = new UserState[0];
            userStateCount = 0;
        }
    };

    public class SnapshotInfo
    {

        public UserState[] userStateList;

        public UInt64 userCount;

        public SnapshotInfo()
        {
            userStateList = new UserState[0];
            userCount = 0;
        }
    };

    public class PresenceEvent
    {
        public PresenceEvent()
        {
            type = RTM_PRESENCE_EVENT_TYPE.RTM_PRESENCE_EVENT_TYPE_NONE;
            channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_NONE;
            channelName = "";
            publisher = "";
            stateItems = new StateItem[0];
            stateItemCount = 0;
            interval = new IntervalInfo();
            snapshot = new SnapshotInfo();
        }
        public RTM_PRESENCE_EVENT_TYPE type;

        public RTM_CHANNEL_TYPE channelType;

        public string channelName;

        public string publisher;

        public StateItem[] stateItems;

        public UInt64 stateItemCount;

        public IntervalInfo interval;

        public SnapshotInfo snapshot;
    };

    public class TopicEvent
    {
        public RTM_TOPIC_EVENT_TYPE type;

        public string channelName;

        public string publisher;

        public TopicInfo[] topicInfos;

        public UInt64 topicInfoCount;

        public TopicEvent()
        {
            type = RTM_TOPIC_EVENT_TYPE.RTM_TOPIC_EVENT_TYPE_SNAPSHOT;
            channelName = "";
            publisher = "";
            topicInfos = new TopicInfo[0];
            topicInfoCount = 0;
        }
    };

    public class LockEvent
    {
        public RTM_CHANNEL_TYPE channelType;

        public RTM_LOCK_EVENT_TYPE eventType;

        public string channelName;

        public LockDetail[] lockDetailList;

        public UInt64 count;

        public LockEvent()
        {
            channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_NONE;
            eventType = RTM_LOCK_EVENT_TYPE.RTM_LOCK_EVENT_TYPE_NONE;
            channelName = "";
            lockDetailList = new LockDetail[0];
            count = 0;
        }
    };

    public class StorageEvent
    {
        /**
         * Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE
         */
        public RTM_CHANNEL_TYPE channelType;
        /**
        * Storage type, RTM_STORAGE_TYPE_USER or RTM_STORAGE_TYPE_CHANNEL
        */
        public RTM_STORAGE_TYPE storageType;
        /**
        * Indicate storage event type
        */
        public RTM_STORAGE_EVENT_TYPE eventType;
        /**
         * The target name of user or channel, depends on the RTM_STORAGE_TYPE
         */
        public string target;
        /**
         * The metadata infomation
         */
        public RtmMetadata data;

        public StorageEvent()
        {
            channelType = RTM_CHANNEL_TYPE.RTM_CHANNEL_TYPE_NONE;
            storageType = RTM_STORAGE_TYPE.RTM_STORAGE_TYPE_NONE;
            eventType = RTM_STORAGE_EVENT_TYPE.RTM_STORAGE_EVENT_TYPE_NONE;
            target = "";
            data = null;
        }
    };
}