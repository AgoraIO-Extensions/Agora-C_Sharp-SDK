using System;

namespace Agora.Rtm
{
    /**
     *  Configurations for RTM Client.
    */
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

        /**
        * The App ID of your project.
        */
        public string appId;

        /**
        * The ID of the user.
        */
        public string userId;

        /**
        * The region for connection. This advanced feature applies to scenarios that
        * have regional restrictions.
        *
        * For the regions that Agora supports, see #AREA_CODE.
        *
        * After specifying the region, the SDK connects to the Agora servers within
        * that region.
        */
        public RTM_AREA_CODE areaCode;

        /**
        * Presence timeout in seconds, specify the timeout value when you lost connection between sdk
        * and rtm service.
        */
        public UInt32 presenceTimeout;

        /**
        * Whether to use String user IDs, if you are using RTC products with Int user IDs,
        * set this value as 'false'. Otherwise errors might occur.
        */
        public bool useStringUserId;

        /**
        * The config for customer set log path, log size and log level.
        */
        public RtmLogConfig logConfig;

        /**
        * The config for proxy setting
        */
        public RtmProxyConfig proxyConfig;

        /**
        * The config for encryption setting
        */
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

        ///
        /// <summary>
        /// 0x0010: Output all API_CALL log information.
        /// </summary>
        ///
        API_CALL = 0x0010,
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

        /**
        * Which channel type, RTM_CHANNEL_TYPE.STREAM or RTM_CHANNEL_TYPE.MESSAGE
        */
        public RTM_CHANNEL_TYPE channelType;

        /**
        * Message type
        */
        public RTM_MESSAGE_TYPE messageType;

        /**
        * The channel which the message was published
        */
        public string channelName;

        /**
        * If the channelType is RTM_CHANNEL_TYPE_STREAM, which topic the message came from. only for RTM_CHANNEL_TYPE_STREAM
        */
        public string channelTopic;

        /**
         * The payload
         */
        public IRtmMessage message;

        /**
        * The publisher
        */
        public string publisher;

        /**
        * The custom type of the message
        */
        public string customType;
    };


    public class IntervalInfo
    {
        /**
        * Joined users during this interval
        */
        public string[] joinUserList;

        /**
        * Left users during this interval
        */
        public string[] leaveUserList;

        /**
        * Timeout users during this interval
        */
        public string[] timeoutUserList;

        /**
        * The user state changed during this interval
        */
        public UserState[] userStateList;

        public IntervalInfo()
        {
            userStateList = new UserState[0];
        }
    };

    public class SnapshotInfo
    {
        /**
        * The user state in this snapshot event
        */
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

        /**
        * Indicate presence event type
        */
        public RTM_PRESENCE_EVENT_TYPE type;

        /**
        * Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE
        */
        public RTM_CHANNEL_TYPE channelType;

        /**
        * The channel which the presence event was triggered
        */
        public string channelName;

        /**
        * The user who triggered this event.
        */
        public string publisher;

        /**
        * The user states
        */
        public StateItem[] stateItems;

        /**
        * Only valid when in interval mode
        */
        public IntervalInfo interval;

        /**
        * Only valid when receive snapshot event
        */
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
        /**
        * Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE
        */
        public RTM_CHANNEL_TYPE channelType;

        /**
        * Lock event type, indicate lock states
        */
        public RTM_LOCK_EVENT_TYPE eventType;

        /**
        * The channel which the lock event was triggered
        */
        public string channelName;

        /**
        * The detail information of locks
        */
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