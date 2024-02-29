using System;

namespace Agora.Rtm
{
    ///
    /// <summary>
    /// Configurations for RTM Client.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// The App ID of your project.
        /// </summary>
        ///
        public string appId;

        ///
        /// <summary>
        /// The ID of the user.
        /// </summary>
        ///
        public string userId;

        ///
        /// <summary>
        /// The region for connection. This advanced feature applies to scenarios that
        /// have regional restrictions.
        /// For the regions that Agora supports, see #AREA_CODE.
        /// After specifying the region, the SDK connects to the Agora servers within
        /// that region.
        /// </summary>
        ///
        public RTM_AREA_CODE areaCode;

        ///
        /// <summary>
        /// Presence timeout in seconds, specify the timeout value when you lost connection between sdk
        /// and rtm service.
        /// </summary>
        ///
        public UInt32 presenceTimeout;

        ///
        /// <summary>
        /// Whether to use String user IDs, if you are using RTC products with Int user IDs,
        /// set this value as 'false'. Otherwise errors might occur.
        /// </summary>
        ///
        public bool useStringUserId;

        ///
        /// <summary>
        /// The config for customer set log path, log size and log level.
        /// </summary>
        ///
        public RtmLogConfig logConfig;

        ///
        /// <summary>
        /// The config for proxy setting
        /// </summary>
        ///
        public RtmProxyConfig proxyConfig;

        ///
        /// <summary>
        /// The config for encryption setting
        /// </summary>
        ///
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
    }

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

        ///
        /// <summary>
        /// Which channel type, RTM_CHANNEL_TYPE.STREAM or RTM_CHANNEL_TYPE.MESSAGE
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE channelType;

        ///
        /// <summary>
        /// Message type
        /// </summary>
        ///
        public RTM_MESSAGE_TYPE messageType;

        ///
        /// <summary>
        /// The channel which the message was published
        /// </summary>
        ///
        public string channelName;

        ///
        /// <summary>
        /// If the channelType is RTM_CHANNEL_TYPE_STREAM, which topic the message came from. only for RTM_CHANNEL_TYPE_STREAM
        /// </summary>
        ///
        public string channelTopic;

        ///
        /// <summary>
        /// The payload
        /// </summary>
        ///
        public IRtmMessage message;

        ///
        /// <summary>
        /// The publisher
        /// </summary>
        ///
        public string publisher;

        ///
        /// <summary>
        /// The custom type of the message
        /// </summary>
        ///
        public string customType;
    };

    public class IntervalInfo
    {
        ///
        /// <summary>
        /// Joined users during this interval
        /// </summary>
        ///
        public string[] joinUserList;

        ///
        /// <summary>
        /// Left users during this interval
        /// </summary>
        ///
        public string[] leaveUserList;

        ///
        /// <summary>
        /// Timeout users during this interval
        /// </summary>
        ///
        public string[] timeoutUserList;

        ///
        /// <summary>
        /// The user state changed during this interval
        /// </summary>
        ///
        public UserState[] userStateList;

        public IntervalInfo()
        {
            userStateList = new UserState[0];
        }
    };

    public class SnapshotInfo
    {
        ///
        /// <summary>
        /// The user state in this snapshot event
        /// </summary>
        ///
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

        ///
        /// <summary>
        /// Indicate presence event type
        /// </summary>
        ///
        public RTM_PRESENCE_EVENT_TYPE type;

        ///
        /// <summary>
        /// Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE channelType;

        ///
        /// <summary>
        /// The channel which the presence event was triggered
        /// </summary>
        ///
        public string channelName;

        ///
        /// <summary>
        /// The user who triggered this event.
        /// </summary>
        ///
        public string publisher;

        ///
        /// <summary>
        /// The user states
        /// </summary>
        ///
        public StateItem[] stateItems;

        ///
        /// <summary>
        /// Only valid when in interval mode
        /// </summary>
        ///
        public IntervalInfo interval;

        ///
        /// <summary>
        /// Only valid when receive snapshot event
        /// </summary>
        ///
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
        ///
        /// <summary>
        /// Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE channelType;

        ///
        /// <summary>
        /// Lock event type, indicate lock states
        /// </summary>
        ///
        public RTM_LOCK_EVENT_TYPE eventType;

        ///
        /// <summary>
        /// The channel which the lock event was triggered
        /// </summary>
        ///
        public string channelName;

        ///
        /// <summary>
        /// The detail information of locks
        /// </summary>
        ///
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
        ///
        /// <summary>
        /// Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE channelType;
        ///
        /// <summary>
        /// Storage type, RTM_STORAGE_TYPE_USER or RTM_STORAGE_TYPE_CHANNEL
        /// </summary>
        ///
        public RTM_STORAGE_TYPE storageType;
        ///
        /// <summary>
        /// Indicate storage event type
        /// </summary>
        ///
        public RTM_STORAGE_EVENT_TYPE eventType;
        ///
        /// <summary>
        /// The target name of user or channel, depends on the RTM_STORAGE_TYPE
        /// </summary>
        ///
        public string target;
        ///
        /// <summary>
        /// The metadata infomation
        /// </summary>
        ///
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