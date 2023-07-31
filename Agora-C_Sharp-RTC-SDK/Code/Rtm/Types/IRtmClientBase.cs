using System;

namespace Agora.Rtm
{
    public class RtmConfig
    {
        public RtmConfig()
        {
            appId = "";
            userId = "";
            areaCode = RTM_AREA_CODE.GLOB;
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
        NONE = 0x0000,

        ///
        /// <summary>
        /// 0x0001: (Default) Output FATAL, ERROR, WARN, and INFO level log information. We recommend setting your log filter to this level.
        /// </summary>
        ///
        INFO = 0x0001,

        ///
        /// <summary>
        /// 0x0002: Output FATAL, ERROR, and WARN level log information.
        /// </summary>
        ///
        WARN = 0x0002,

        ///
        /// <summary>
        /// 0x0004: Output FATAL and ERROR level log information.
        /// </summary>
        ///
        ERROR = 0x0004,

        ///
        /// <summary>
        /// 0x0008: Output FATAL level log information.
        /// </summary>
        ///
        FATAL = 0x0008,

        API_CALL = 0x0010,
    };


    public enum STREAM_CHANNEL_ERROR_CODE
    {
        OK = 0,
        INVALID_ARGUMENT = 1,
        JOIN_FAILURE = 2,
        JOIN_REJECTED = 3,
        REJOIN_FAILURE = 4,
        LEAVE_FAILURE = 5,
        EXCEED_LIMITATION = 6,
    };

    public class TopicSubUsersUpdated
    {
        public TopicSubUsersUpdated()
        {
            topic = "";
            succeedUsers = new string[0];
            failedUsers = new string[0];
        }

        public TopicSubUsersUpdated(string topic, string[] succeedUsers, string[] failedUsers)
        {
            this.topic = topic;
            this.succeedUsers = succeedUsers;
            this.failedUsers = failedUsers;
        }

        public string topic;

        public string[] succeedUsers;

        public string[] failedUsers;
    };

    public class MessageEvent
    {
        public MessageEvent()
        {
            channelType = RTM_CHANNEL_TYPE.MESSAGE;
            messageType = RTM_MESSAGE_TYPE.BINARY;
            channelName = "";
            channelTopic = "";
            message = null;
            publisher = "";
            customType = "";
        }

        public RTM_CHANNEL_TYPE channelType;

        public RTM_MESSAGE_TYPE messageType;

        public string channelName;

        public string channelTopic;

        public IRtmMessage message;

        public string publisher;

        public string customType;
    };


    public class IntervalInfo
    {
        public string[] joinUserList;

        public string[] leaveUserList;

        public string[] timeoutUserList;

        public UserState[] userStateList;

        public IntervalInfo()
        {
            userStateList = new UserState[0];
        }
    };

    public class SnapshotInfo
    {
        public UserState[] userStateList;

        public SnapshotInfo()
        {
            userStateList = new UserState[0];
        }
    };

    public class PresenceEvent
    {
        public PresenceEvent()
        {
            type = RTM_PRESENCE_EVENT_TYPE.NONE;
            channelType = RTM_CHANNEL_TYPE.NONE;
            channelName = "";
            publisher = "";
            stateItems = new StateItem[0];
            interval = new IntervalInfo();
            snapshot = new SnapshotInfo();
        }
        public RTM_PRESENCE_EVENT_TYPE type;

        public RTM_CHANNEL_TYPE channelType;

        public string channelName;

        public string publisher;

        public StateItem[] stateItems;

        public IntervalInfo interval;

        public SnapshotInfo snapshot;
    };

    public class TopicEvent
    {
        public RTM_TOPIC_EVENT_TYPE type;

        public string channelName;

        public string publisher;

        public TopicInfo[] topicInfos;

        public TopicEvent()
        {
            type = RTM_TOPIC_EVENT_TYPE.SNAPSHOT;
            channelName = "";
            publisher = "";
            topicInfos = new TopicInfo[0];
        }
    };

    public class LockEvent
    {
        public RTM_CHANNEL_TYPE channelType;

        public RTM_LOCK_EVENT_TYPE eventType;

        public string channelName;

        public LockDetail[] lockDetailList;

        public LockEvent()
        {
            channelType = RTM_CHANNEL_TYPE.NONE;
            eventType = RTM_LOCK_EVENT_TYPE.NONE;
            channelName = "";
            lockDetailList = new LockDetail[0];
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
            channelType = RTM_CHANNEL_TYPE.NONE;
            storageType = RTM_STORAGE_TYPE.NONE;
            eventType = RTM_STORAGE_EVENT_TYPE.NONE;
            target = "";
            data = null;
        }
    };
}