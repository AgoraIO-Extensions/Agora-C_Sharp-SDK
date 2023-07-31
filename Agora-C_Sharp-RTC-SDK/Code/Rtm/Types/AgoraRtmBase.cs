using System;
namespace Agora.Rtm
{
    /**
    * IP areas.
    */
    public enum RTM_AREA_CODE : uint
    {
        /**
        * Mainland China.
        */
        CN = 0x00000001,
        /**
         * North America.
         */
        NA = 0x00000002,
        /**
         * Europe.
         */
        EU = 0x00000004,
        /**
         * Asia, excluding Mainland China.
         */
        AS = 0x00000008,
        /**
         * Japan.
         */
        JP = 0x00000010,
        /**
         * India.
         */
        IN = 0x00000020,
        /**
         * (Default) Global.
         */
        GLOB = (0xFFFFFFFF)
    };

    /**
    * The log level for rtm sdk.
    */
    public enum RTM_LOG_LEVEL
    {
        /**
         * 0x0000: No logging.
         */
        NONE = 0x0000,
        /**
         * 0x0001: Informational messages.
         */
        INFO = 0x0001,
        /**
         * 0x0002: Warnings.
         */
        WARN = 0x0002,
        /**
         * 0x0004: Errors.
         */
        ERROR = 0x0004,
        /**
         * 0x0008: Critical errors that may lead to program termination.
         */
        FATAL = 0x0008,
    };

    public enum RTM_ENCRYPTION_MODE
    {
        NONE = 0,

        AES_128_GCM = 1,

        AES_256_GCM = 2,
    };


    /**
    * The error codes of rtm client.
    */
    public enum RTM_ERROR_CODE
    {
        /**
         * 0: No error occurs.
         */
        OK = 0,

        /**
         * -10001 ~ -11000 : reserved for generic error.
         * -10001: The SDK is not initialized.
         */
        NOT_INITIALIZED = -10001,
        /**
         * -10002: The user didn't login the RTM system.
         */
        NOT_LOGIN = -10002,
        /**
         * -10003: The app ID is invalid.
         */
        INVALID_APP_ID = -10003,
        /**
         * -10004: The event handler is invalid.
         */
        INVALID_EVENT_HANDLER = -10004,
        /**
         * -10005: The token is invalid.
         */
        INVALID_TOKEN = -10005,
        /**
         * -10006: The user ID is invalid.
         */
        INVALID_USER_ID = -10006,
        /**
         * -10007: The service is not initialized.
         */
        INIT_SERVICE_FAILED = -10007,
        /**
         * -10008: The channel name is invalid.
         */
        INVALID_CHANNEL_NAME = -10008,
        /**
         * -10009: The token has expired.
         */
        TOKEN_EXPIRED = -10009,
        /**
         * -10010: There is no server resources now.
         */
        LOGIN_NO_SERVER_RESOURCES = -10010,
        /**
         * -10011: The login timeout.
         */
        LOGIN_TIMEOUT = -10011,
        /**
         * -10012: The login is rejected by server.
         */
        LOGIN_REJECTED = -10012,
        /**
         * -10013: The login is aborted due to unrecoverable error.
         */
        LOGIN_ABORTED = -10013,
        /**
         * -10014: The parameter is invalid.
         */
        INVALID_PARAMETER = -10014,
        /**
         * -10015: The login is not authorized. Happens user login the RTM system without granted from console.
         */
        LOGIN_NOT_AUTHORIZED = -10015,
        /**
         * -10016: Try to login or join with inconsistent app ID.
         */
        INCONSISTENT_APPID = -10016,
        /**
         * -10017: Already call same request.
         */
        DUPLICATE_OPERATION = -10017,
        /**
         * -10018: Already call destroy or release, this instance is forbidden to call any api, please create new instance.
         */
        INSTANCE_ALREADY_RELEASED = -10018,

        /**
         * -11001 ~ -12000 : reserved for channel error.
         * -11001: The user has not joined the channel.
         */
        CHANNEL_NOT_JOINED = -11001,
        /**
         * -11002: The user has not subscribed the channel.
         */
        CHANNEL_NOT_SUBSCRIBED = -11002,
        /**
         * -11003: The topic member count exceeds the limit.
         */
        CHANNEL_EXCEED_TOPIC_USER_LIMITATION = -11003,
        /**
         * -11004: The channel is reused in RTC.
         */
        CHANNEL_IN_REUSE = -11004,
        /**
         * -11005: The channel instance count exceeds the limit.
         */
        CHANNEL_INSTANCE_EXCEED_LIMITATION = -11005,
        /**
         * -11006: The channel is in error state.
         */
        CHANNEL_IN_ERROR_STATE = -11006,
        /**
         * -11007: The channel join failed.
         */
        CHANNEL_JOIN_FAILED = -11007,
        /**
         * -11008: The topic name is invalid.
         */
        CHANNEL_INVALID_TOPIC_NAME = -11008,
        /**
         * -11009: The message is invalid.
         */
        CHANNEL_INVALID_MESSAGE = -11009,
        /**
         * -11010: The message length exceeds the limit.
         */
        CHANNEL_MESSAGE_LENGTH_EXCEED_LIMITATION = -11010,
        /**
         * -11011: The user list is invalid.
         */
        CHANNEL_INVALID_USER_LIST = -11011,
        /**
         * -11012: The stream channel is not available.
         */
        CHANNEL_NOT_AVAILABLE = -11012,
        /**
         * -11013: The topic is not subscribed.
         */
        CHANNEL_TOPIC_NOT_SUBSCRIBED = -11013,
        /**
         * -11014: The topic count exceeds the limit.
         */
        CHANNEL_EXCEED_TOPIC_LIMITATION = -11014,
        /**
         * -11015: Join topic failed.
         */
        CHANNEL_JOIN_TOPIC_FAILED = -11015,
        /**
         * -11016: The topic is not joined.
         */
        CHANNEL_TOPIC_NOT_JOINED = -11016,
        /**
         * -11017: The topic does not exist.
         */
        CHANNEL_TOPIC_NOT_EXIST = -11017,
        /**
         * -11018: The topic meta is invalid.
         */
        CHANNEL_INVALID_TOPIC_META = -11018,
        /**
         * -11019: Subscribe channel timeout.
         */
        CHANNEL_SUBSCRIBE_TIMEOUT = -11019,
        /**
         * -11020: Subscribe channel too frequent.
         */
        CHANNEL_SUBSCRIBE_TOO_FREQUENT = -11020,
        /**
         * -11021: Subscribe channel failed.
         */
        CHANNEL_SUBSCRIBE_FAILED = -11021,
        /**
         * -11022: Unsubscribe channel failed.
         */
        CHANNEL_UNSUBSCRIBE_FAILED = -11022,
        /**
         * -11023: Encrypt message failed.
         */
        CHANNEL_ENCRYPT_MESSAGE_FAILED = -11023,
        /**
         * -11024: Publish message failed.
         */
        CHANNEL_PUBLISH_MESSAGE_FAILED = -11024,
        /**
         * -11025: Publish message too frequent.
         */
        CHANNEL_PUBLISH_MESSAGE_TOO_FREQUENT = -11025,
        /**
         * -11026: Publish message timeout.
         */
        CHANNEL_PUBLISH_MESSAGE_TIMEOUT = -11026,
        /**
         * -11027: The connection state is invalid.
         */
        CHANNEL_NOT_CONNECTED = -11027,
        /**
         * -11028: Leave channel failed.
         */
        CHANNEL_LEAVE_FAILED = -11028,
        /**
         * -11029: The custom type length exceeds the limit.
         */
        CHANNEL_CUSTOM_TYPE_LENGTH_OVERFLOW = -11029,
        /**
         * -11030: The custom type is invalid.
         */
        CHANNEL_INVALID_CUSTOM_TYPE = -11030,
        /**
         * -11031: unsupported message type (in MacOS/iOS platform，message only support NSString and NSData)
         */
        CHANNEL_UNSUPPORTED_MESSAGE_TYPE = -11031,
        /**
         * -11032: The channel presence is not ready.
         */
        CHANNEL_PRESENCE_NOT_READY = -11032,

        /**
         * -12001 ~ -13000 : reserved for storage error.
         * -12001: The storage operation failed.
         */
        STORAGE_OPERATION_FAILED = -12001,
        /**
         * -12002: The metadata item count exceeds the limit.
         */
        STORAGE_METADATA_ITEM_EXCEED_LIMITATION = -12002,
        /**
         * -12003: The metadata item is invalid.
         */
        STORAGE_INVALID_METADATA_ITEM = -12003,
        /**
         * -12004: The argument in storage operation is invalid.
         */
        STORAGE_INVALID_ARGUMENT = -12004,
        /**
         * -12005: The revision in storage operation is invalid.
         */
        STORAGE_INVALID_REVISION = -12005,
        /**
         * -12006: The metadata length exceeds the limit.
         */
        STORAGE_METADATA_LENGTH_OVERFLOW = -12006,
        /**
         * -12007: The lock name in storage operation is invalid.
         */
        STORAGE_INVALID_LOCK_NAME = -12007,
        /**
         * -12008: The lock in storage operation is not acquired.
         */
        STORAGE_LOCK_NOT_ACQUIRED = -12008,
        /**
         * -12009: The metadata key is invalid.
         */
        STORAGE_INVALID_KEY = -12009,
        /**
         * -12010: The metadata value is invalid.
         */
        STORAGE_INVALID_VALUE = -12010,
        /**
         * -12011: The metadata key length exceeds the limit.
         */
        STORAGE_KEY_LENGTH_OVERFLOW = -12011,
        /**
         * -12012: The metadata value length exceeds the limit.
         */
        STORAGE_VALUE_LENGTH_OVERFLOW = -12012,
        /**
         * -12013: The metadata key already exists.
         */
        STORAGE_DUPLICATE_KEY = -12013,
        /**
         * -12014: The revision in storage operation is outdated.
         */
        STORAGE_OUTDATED_REVISION = -12014,
        /**
         * -12015: The storage operation performed without subscribing.
         */
        STORAGE_NOT_SUBSCRIBE = -12015,
        /**
         * -12016: The metadata item is invalid.
         */
        STORAGE_INVALID_METADATA_INSTANCE = -12016,
        /**
         * -12017: The user count exceeds the limit when try to subscribe.
         */
        STORAGE_SUBSCRIBE_USER_EXCEED_LIMITATION = -12017,
        /**
         * -12018: The storage operation timeout.
         */
        STORAGE_OPERATION_TIMEOUT = -12018,
        /**
         * -12019: The storage service not available.
         */
        STORAGE_NOT_AVAILABLE = -12019,

        /**
         * -13001 ~ -14000 : reserved for presence error.
         * -13001: The user is not connected.
         */
        PRESENCE_NOT_CONNECTED = -13001,
        /**
         * -13002: The presence is not writable.
         */
        PRESENCE_NOT_WRITABLE = -13002,
        /**
         * -13003: The argument in presence operation is invalid.
         */
        PRESENCE_INVALID_ARGUMENT = -13003,
        /**
         * -13004: The cached presence state count exceeds the limit.
         */
        PRESENCE_CACHED_TOO_MANY_STATES = -13004,
        /**
         * -13005: The state count exceeds the limit.
         */
        PRESENCE_STATE_COUNT_OVERFLOW = -13005,
        /**
         * -13006: The state key is invalid.
         */
        PRESENCE_INVALID_STATE_KEY = -13006,
        /**
         * -13007: The state value is invalid.
         */
        PRESENCE_INVALID_STATE_VALUE = -13007,
        /**
         * -13008: The state key length exceeds the limit.
         */
        PRESENCE_STATE_KEY_SIZE_OVERFLOW = -13008,
        /**
         * -13009: The state value length exceeds the limit.
         */
        PRESENCE_STATE_VALUE_SIZE_OVERFLOW = -13009,
        /**
         * -13010: The state key already exists.
         */
        PRESENCE_STATE_DUPLICATE_KEY = -13010,
        /**
         * -13011: The user is not exist.
         */
        PRESENCE_USER_NOT_EXIST = -13011,
        /**
         * -13012: The presence operation timeout.
         */
        PRESENCE_OPERATION_TIMEOUT = -13012,
        /**
         * -13013: The presence operation failed.
         */
        PRESENCE_OPERATION_FAILED = -13013,

        /**
         * -14001 ~ -15000 : reserved for lock error.
         * -14001: The lock operation failed.
         */
        LOCK_OPERATION_FAILED = -14001,
        /**
         * -14002: The lock operation timeout.
         */
        LOCK_OPERATION_TIMEOUT = -14002,
        /**
         * -14003: The lock operation is performing.
         */
        LOCK_OPERATION_PERFORMING = -14003,
        /**
         * -14004: The lock already exists.
         */
        LOCK_ALREADY_EXIST = -14004,
        /**
         * -14005: The lock name is invalid.
         */
        LOCK_INVALID_NAME = -14005,
        /**
         * -14006: The lock is not acquired.
         */
        LOCK_NOT_ACQUIRED = -14006,
        /**
         * -14007: Acquire lock failed.
         */
        LOCK_ACQUIRE_FAILED = -14007,
        /**
         * -14008: The lock is not exist.
         */
        LOCK_NOT_EXIST = -14008,
        /**
         * -14009: The lock service is not available.
         */
        LOCK_NOT_AVAILABLE = -14009,
    };


    public enum RTM_CONNECTION_STATE
    {

        DISCONNECTED = 1,

        CONNECTING = 2,

        CONNECTED = 3,

        RECONNECTING = 4,

        FAILED = 5,
    };


    /**
    * Reasons for connection state change.
    */
    public enum RTM_CONNECTION_CHANGE_REASON
    {
        /**
         * 0: The SDK is connecting to the server.
         */
        CONNECTING = 0,
        /**
         * 1: The SDK has joined the channel successfully.
         */
        JOIN_SUCCESS = 1,
        /**
         * 2: The connection between the SDK and the server is interrupted.
         */
        INTERRUPTED = 2,
        /**
         * 3: The connection between the SDK and the server is banned by the server.
         */
        BANNED_BY_SERVER = 3,
        /**
         * 4: The SDK fails to join the channel for more than 20 minutes and stops reconnecting to the channel.
         */
        JOIN_FAILED = 4,
        /**
         * 5: The SDK has left the channel.
         */
        LEAVE_CHANNEL = 5,
        /**
         * 6: The connection fails because the App ID is not valid.
         */
        INVALID_APP_ID = 6,
        /**
         * 7: The connection fails because the channel name is not valid.
         */
        INVALID_CHANNEL_NAME = 7,
        /**
         * 8: The connection fails because the token is not valid.
         */
        INVALID_TOKEN = 8,
        /**
         * 9: The connection fails because the token has expired.
         */
        TOKEN_EXPIRED = 9,
        /**
         * 10: The connection is rejected by the server.
         */
        REJECTED_BY_SERVER = 10,
        /**
         * 11: The connection changes to reconnecting because the SDK has set a proxy server.
         */
        SETTING_PROXY_SERVER = 11,
        /**
         * 12: When the connection state changes because the app has renewed the token.
         */
        RENEW_TOKEN = 12,
        /**
         * 13: The IP Address of the app has changed. A change in the network type or IP/Port changes the IP
         * address of the app.
         */
        CLIENT_IP_ADDRESS_CHANGED = 13,
        /**
         * 14: A timeout occurs for the keep-alive of the connection between the SDK and the server.
         */
        KEEP_ALIVE_TIMEOUT = 14,
        /**
         * 15: The SDK has rejoined the channel successfully.
         */
        REJOIN_SUCCESS = 15,
        /**
         * 16: The connection between the SDK and the server is lost.
         */
        LOST = 16,
        /**
         * 17: The change of connection state is caused by echo test.
         */
        ECHO_TEST = 17,
        /**
         * 18: The local IP Address is changed by user.
         */
        CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,
        /**
         * 19: The connection is failed due to join the same channel on another device with the same uid.
         */
        SAME_UID_LOGIN = 19,
        /**
         * 20: The connection is failed due to too many broadcasters in the channel.
         */
        TOO_MANY_BROADCASTERS = 20,
        /**
         * 21: The connection is failed due to license validation failure.
         */
        LICENSE_VALIDATION_FAILURE = 21,
        /**
         * 22: The connection is failed due to user vid not support stream channel.
         */
        STREAM_CHANNEL_NOT_AVAILABLE = 22,
        /**
         * 23: The connection is failed due to token and appid inconsistent.
         */
        INCONSISTENT_APPID = 23,
        /**
         * 10001: The connection of rtm edge service has been successfully established.
         */
        LOGIN_SUCCESS = 10001,
        /**
         * 10002: User log out Agora RTM system.
         */
        LOGOUT = 10002,
        /**
         * 10003: User log out Agora RTM system.
         */
        PRESENCE_NOT_READY = 10003,
    }

    /**
    * RTM channel type.
    */
    public enum RTM_CHANNEL_TYPE
    {
        /**
         * 0: Unknown channel type.
         */
        NONE = 0,
        /**
         * 1: Message channel.
         */
        MESSAGE = 1,
        /**
         * 2: Stream channel.
         */
        STREAM = 2,
    };


    public enum RTM_PRESENCE_TYPE
    {
        REMOTE_JOIN_CHANNEL = 0,

        REMOTE_LEAVE_CHANNEL = 1,

        REMOTE_CONNECTION_TIMEOUT = 2,

        REMOTE_JOIN_TOPIC = 3,

        REMOTE_LEAVE_TOPIC = 4,

        SELF_JOIN_CHANNEL = 5,

        USER_STATE_CHANGED = 6,
    };

    public enum RTM_MESSAGE_TYPE
    {

          BINARY = 0,

          STRING = 1,
    };


    /**
    @brief Storage type indicate the storage event was triggered by user or channel
    */
    public enum RTM_STORAGE_TYPE
    {
        /**
          0: Unknown type.
          */
          NONE = 0,
        /**
          1: The user storage event.
          */
          USER = 1,
        /**
          2: The channel storage event.
          */
          CHANNEL = 2,
    };

    /**
    * The storage event type, indicate storage operation
    */
    public enum RTM_STORAGE_EVENT_TYPE
    {
        /**
          0: Unknown event type.
          */
          NONE = 0,
        /**
          1: Triggered when user subscribe user metadata state or join channel with options.withMetadata = true
          */
          SNAPSHOT = 1,
        /**
          2: Triggered when a remote user set metadata
          */
          SET = 2,
        /**
          3: Triggered when a remote user update metadata
          */
          UPDATE = 3,
        /**
          4: Triggered when a remote user remove metadata
          */
          REMOVE = 4,
    };



    /**
     * The lock event type, indicate lock operation
     */
    public enum RTM_LOCK_EVENT_TYPE
    {
        /**
         * 0: Unknown event type
         */
          NONE = 0,
        /**
         * 1: Triggered when user subscribe lock state
         */
          SNAPSHOT = 1,
        /**
         * 2: Triggered when a remote user set lock
         */
          LOCK_SET = 2,
        /**
         * 3: Triggered when a remote user remove lock
         */
          LOCK_REMOVED = 3,
        /**
         * 4: Triggered when a remote user acquired lock
         */
          LOCK_ACQUIRED = 4,
        /**
         * 5: Triggered when a remote user released lock
         */
          LOCK_RELEASED = 5,
        /**
         * 6: Triggered when user reconnect to rtm service,
         * detect the lock has been acquired and released by others.
         */
          LOCK_EXPIRED = 6,
    };

    public enum RTM_PROXY_TYPE
    {

          NONE = 0,

          HTTP = 1,
    };

    /**
    @brief Topic event type
    */
    public enum RTM_TOPIC_EVENT_TYPE
    {
        /**
         * 0: Unknown event type
         */
          NONE = 0,
        /**
         * 1: The topic snapshot of this channel
         */
          SNAPSHOT = 1,
        /**
         * 2: Triggered when remote user join a topic
         */
          REMOTE_JOIN_TOPIC = 2,
        /**
         * 3: Triggered when remote user leave a topic
         */
          REMOTE_LEAVE_TOPIC = 3,
    };

    /**
    @brief Presence event type
    */
    public enum RTM_PRESENCE_EVENT_TYPE
    {
        /**
         * 0: Unknown event type
         */
          NONE = 0,
        /**
         * 1: The presence snapshot of this channel
         */
          SNAPSHOT = 1,
        /**
         * 2: The presence event triggered in interval mode
         */
          INTERVAL = 2,
        /**
         * 3: Triggered when remote user join channel
         */
          REMOTE_JOIN_CHANNEL = 3,
        /**
         * 4: Triggered when remote user leave channel
         */
          REMOTE_LEAVE_CHANNEL = 4,
        /**
         * 5: Triggered when remote user's connection timeout
         */
          REMOTE_TIMEOUT = 5,
        /**
         * 6: Triggered when user changed state
         */
          REMOTE_STATE_CHANGED = 6,
        /**
         * 7: Triggered when user joined channel without presence service
         */
          ERROR_OUT_OF_SERVICE = 7,
    };

    /** 
    * Definition of LogConfiguration
    */
    public class RtmLogConfig
    {
        /**
         * The log file path, default is NULL for default log path
         */
        public string filePath;
        /** 
         * The log file size, KB , set 1024KB to use default log size
         */
        public uint fileSizeInKB;
        /**
         *  The log level, set LOG_LEVEL_INFO to use default log level
         */
        public RTM_LOG_LEVEL level;

        public RtmLogConfig()
        {
            filePath = "";
            fileSizeInKB = 1024;
            level = RTM_LOG_LEVEL.INFO;
        }

        public RtmLogConfig(string filePath, uint fileSize = 1024, RTM_LOG_LEVEL level = RTM_LOG_LEVEL.INFO)
        {
            this.filePath = filePath;
            this.fileSizeInKB = fileSize;
            this.level = level;
        }
    };

    

    public class PublisherInfo
    {
        public string publisherUserId;

        public string publisherMeta;

        public PublisherInfo()
        {
            publisherUserId = "";
            publisherMeta = "";
        }

        public PublisherInfo(string publisherUserId, string publisherMeta)
        {
            this.publisherUserId = publisherUserId;
            this.publisherMeta = publisherMeta;
        }
    };


    public class TopicInfo
    {
        public string topic;

        public PublisherInfo[] publishers;
      
        public TopicInfo()
        {
            topic = "";
            publishers = new PublisherInfo[0];
          
        }

        public TopicInfo(string topic, PublisherInfo[] publishers)
        {
            this.topic = topic;
            this.publishers = publishers;
        }
    };


    public class StateItem
    {

        public string key;

        public string value;

        public StateItem()
        {
            key = "";
            value = "";
        }

        public StateItem(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    };


    public class LockDetail
    {
        public string lockName;

        public string owner;

        public uint ttl;

        public LockDetail()
        {
            lockName = "";
            owner = "";
            ttl = 0;
        }

        public LockDetail(string lockName, string owner, uint ttl)
        {
            this.lockName = lockName;
            this.owner = owner;
            this.ttl = ttl;
        }
    }


    public class UserState
    {

        public string userId;

        public StateItem[] states;

        public UserState()
        {
            userId = "";
            states = null;
        }

        public UserState(string userId, StateItem[] states)
        {
            this.userId = userId;
            this.states = states;
        }
    };


    public class SubscribeOptions
    {

        public bool withMessage;

        public bool withMetadata;

        public bool withPresence;

        public bool withLock;

        public SubscribeOptions()
        {
            withMessage = true;
            withMetadata = false;
            withPresence = true;
            withLock = false;
        }

        public SubscribeOptions(bool withMessage, bool withMetadata, bool withPresence, bool withLock)
        {
            this.withMessage = withMessage;
            this.withMetadata = withMetadata;
            this.withPresence = withPresence;
            this.withLock = withLock;
        }
    };


    public class ChannelInfo
    {
        public string channelName;

        public RTM_CHANNEL_TYPE channelType;

        public ChannelInfo()
        {
            channelName = "";
            channelType = RTM_CHANNEL_TYPE.MESSAGE;
        }

        public ChannelInfo(string channelName, RTM_CHANNEL_TYPE channelType)
        {
            this.channelName = channelName;
            this.channelType = channelType;
        }
    };

    public class PresenceOptions
    {

        public bool includeUserId;

        public bool includeState;

        public string page;

        public PresenceOptions()
        {
            includeUserId = true;
            includeState = false;
            page = "";
        }

        public PresenceOptions(bool includeUserId, bool includeState, string page)
        {
            this.includeUserId = includeUserId;
            this.includeState = includeState;
            this.page = page;
        }
    };


    public class PublishOptions
    {
        public UInt64 sendTs;

        public string customType;

        public PublishOptions()
        {
            sendTs = 0;
            customType = "";
        }

        public PublishOptions(UInt64 sendTs, string customType)
        {
            this.sendTs = sendTs;
            this.customType = customType;
        }
    };


    public class RtmProxyConfig
    {

        public RTM_PROXY_TYPE proxyType;

        public string server;

        public UInt16 port;

        public string account;

        public string password;

        public RtmProxyConfig()
        {
            proxyType = RTM_PROXY_TYPE.  NONE;
            server = "";
            port = 0;
            account = "";
            password = "";
        }

        public RtmProxyConfig(RTM_PROXY_TYPE proxyType, string server, UInt16 port, string account, string password)
        {
            this.proxyType = proxyType;
            this.server = server;
            this.port = port;
            this.account = account;
            this.password = password;
        }

    };


    public class RtmEncryptionConfig
    {

        public RTM_ENCRYPTION_MODE encryptionMode;

        public string encryptionKey;

        private byte[] encryptionSalt32 = new byte[32];

        public byte[] encryptionSalt
        {
            set { Buffer.BlockCopy(value, 0, encryptionSalt32, 0, 32); }

            get { return encryptionSalt32; }
        }

        public RtmEncryptionConfig()
        {
            encryptionMode = RTM_ENCRYPTION_MODE.NONE;
            encryptionKey = "";
            encryptionSalt = new byte[32];
        }
    };

    public class RtmMetadata
    {
        public Int64 majorRevision;
        public MetadataItem[] metadataItems;
        public UInt64 metadataItemsSize;

        public RtmMetadata()
        {
            majorRevision = 0;
            metadataItems = new MetadataItem[0];
            metadataItemsSize = 0;
        }
    }
}
