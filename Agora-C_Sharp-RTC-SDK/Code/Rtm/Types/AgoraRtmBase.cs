using System;
namespace Agora.Rtm
{
    public enum AREA_CODE : uint
    {

        AREA_CODE_CN = 0x00000001,

        AREA_CODE_NA = 0x00000002,

        AREA_CODE_EU = 0x00000004,

        AREA_CODE_AS = 0x00000008,

        AREA_CODE_JP = 0x00000010,

        AREA_CODE_IN = 0x00000020,

        AREA_CODE_GLOB = 0xFFFFFFFF,
    };


    public enum AREA_CODE_EX : uint
    {

        AREA_CODE_OC = 0x00000040,

        AREA_CODE_SA = 0x00000080,

        AREA_CODE_AF = 0x00000100,

        AREA_CODE_KR = 0x00000200,

        AREA_CODE_HKMC = 0x00000400,

        AREA_CODE_US = 0x00000800,

        AREA_CODE_OVS = 0xFFFFFFFE,
    };


    public enum RTM_ENCRYPTION_MODE
    {
        RTM_ENCRYPTION_MODE_NONE = 0,

        RTM_ENCRYPTION_MODE_AES_128_GCM = 1,

        RTM_ENCRYPTION_MODE_AES_256_GCM = 2,
    };


    public enum RTM_ERROR_CODE
    {

        RTM_ERR_TOPIC_ALREADY_JOINED = 10001,

        RTM_ERR_EXCEED_JOIN_TOPIC_LIMITATION = 10002,

        RTM_ERR_INVALID_TOPIC_NAME = 10003,

        RTM_ERR_PUBLISH_TOPIC_MESSAGE_FAILED = 10004,

        RTM_ERR_EXCEED_SUBSCRIBE_TOPIC_LIMITATION = 10005,

        RTM_ERR_EXCEED_USER_LIMITATION = 10006,

        RTM_ERR_EXCEED_CHANNEL_LIMITATION = 10007,

        RTM_ERR_ALREADY_JOIN_CHANNEL = 10008,

        RTM_ERR_NOT_JOIN_CHANNEL = 10009,

        RTM_ERR_ALREADY_LOGIN = 10010,

        RTM_ERR_NOT_LOGIN = 10011,

        RTM_ERR_DUPLICATE_TOKEN = 10012,

        RTM_ERR_NOT_SUBSCRIBED = 10013,

        RTM_ERR_ALREADY_SUBSCRIBED = 10014,

        RTM_ERR_ENCRYPTION_FAILED = 10015,

        RTM_ERR_METADATA_SIZE_OVERFLOW = 10101,

        RTM_ERR_METADATA_ITEM_SIZE_OVERFLOW = 10102,

        RTM_ERR_METADATA_KEY_SIZE_OVERFLOW = 10103,

        RTM_ERR_METADATA_VALUE_SIZE_OVERFLOW = 10104,

        RTM_ERR_METADATA_INVALID_KEY = 10105,

        RTM_ERR_METADATA_INVALID_REVISION = 10106,

        RTM_ERR_METADATA_NOT_SUBSCRIBED = 10107,

        RTM_ERR_METADATA_ALREADY_SUBSCRIBED = 10108,

        RTM_ERR_METADATA_EXCEED_SUBSCRIPTION_LIMIT = 10109,

        RTM_ERR_METADATA_WITH_INVALID_LOCK = 10110,

        RTM_ERR_LOCK_OPERATION_PERFORMING = 10201,

        RTM_ERR_RELEASE_LOCK_NOT_ACQUIRED = 10202,

        RTM_ERR_PRESENCE_SERVICE_NOT_READY = 10301,

        RTM_ERR_PRESENCE_OPERATION_WITHOUT_JOIN_CHANNEL = 10302,

        RTM_ERR_PRESENCE_STATE_SIZE_OVERFLOW = 10303,

        RTM_ERR_PRESENCE_STATE_KEY_SIZE_OVERFLOW = 10304,

        RTM_ERR_PRESENCE_STATE_INVALID_KEY = 10305,

        RTM_ERR_PRESENCE_STATE_DUPLICATE_KEY = 10306,

        RTM_ERR_PRESENCE_STATE_VALUE_SIZE_OVERFLOW = 10307,
    };


    public enum RTM_CONNECTION_STATE
    {

        RTM_CONNECTION_STATE_DISCONNECTED = 1,

        RTM_CONNECTION_STATE_CONNECTING = 2,

        RTM_CONNECTION_STATE_CONNECTED = 3,

        RTM_CONNECTION_STATE_RECONNECTING = 4,

        RTM_CONNECTION_STATE_FAILED = 5,
    };


    public enum RTM_CONNECTION_CHANGE_REASON
    {

        RTM_CONNECTION_CHANGED_CONNECTING = 0,

        RTM_CONNECTION_CHANGED_JOIN_SUCCESS = 1,

        RTM_CONNECTION_CHANGED_INTERRUPTED = 2,

        RTM_CONNECTION_CHANGED_BANNED_BY_SERVER = 3,

        RTM_CONNECTION_CHANGED_JOIN_FAILED = 4,

        RTM_CONNECTION_CHANGED_LEAVE_CHANNEL = 5,

        RTM_CONNECTION_CHANGED_INVALID_APP_ID = 6,

        RTM_CONNECTION_CHANGED_INVALID_CHANNEL_NAME = 7,

        RTM_CONNECTION_CHANGED_INVALID_TOKEN = 8,

        RTM_CONNECTION_CHANGED_TOKEN_EXPIRED = 9,

        RTM_CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,

        RTM_CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,

        RTM_CONNECTION_CHANGED_RENEW_TOKEN = 12,

        RTM_CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,

        RTM_CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,

        RTM_CONNECTION_CHANGED_REJOIN_SUCCESS = 15,

        RTM_CONNECTION_CHANGED_LOST = 16,

        RTM_CONNECTION_CHANGED_ECHO_TEST = 17,

        RTM_CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,

        RTM_CONNECTION_CHANGED_SAME_UID_LOGIN = 19,

        RTM_CONNECTION_CHANGED_TOO_MANY_BROADCASTERS = 20,

        RTM_CONNECTION_CHANGED_STREAM_CHANNEL_NOT_AVAILABLE = 22,

        RTM_CONNECTION_CHANGED_LOGIN_SUCCESS = 10001,
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

        RTM_PRESENCE_TYPE_USER_STATE_CHANGED = 6,
    };

    public enum RTM_CHANNEL_ERROR_CODE
    {

        RTM_CHANNEL_ERROR_OK = 0,

        RTM_CHANNEL_ERROR_EXCEED_LIMITATION = 1,

        RTM_CHANNEL_ERROR_USER_NOT_EXIST = 2,

        RTM_CHANNEL_ERROR_PUBLISH_MESSAGE_FAILED = 3,

        RTM_CHANNEL_ERROR_PUBLISH_MESSAGE_TIMEOUT = 4,

        RTM_CHANNEL_ERROR_SUBSCRIBE_FAILED = 5,

        RTM_CHANNEL_ERROR_SUBSCRIBE_TIMEOUT = 6,

        RTM_CHANNEL_ERROR_STREAM_CHANNEL_NOT_AVAILABLE = 7,
    };


    public enum RTM_LOGIN_ERROR_CODE
    {

        RTM_LOGIN_ERROR_OK = 0,

        RTM_LOGIN_ERROR_REJECTED = 1,

        RTM_LOGIN_ERROR_INVALID_APP_ID = 2,

        RTM_LOGIN_ERROR_INVALID_TOKEN = 3,

        RTM_LOGIN_ERROR_TOKEN_EXPIRED = 4,

        RTM_LOGIN_ERROR_NOT_AUTHORIZED = 5,

        RTM_LOGIN_ERROR_TIMEOUT = 6,

        RTM_LOGIN_ERROR_NO_SERVER_RESOURCES = 7,
    };


    public enum RTM_MESSAGE_TYPE
    {

        RTM_MESSAGE_TYPE_BINARY = 0,

        RTM_MESSAGE_TYPE_STRING = 1,
    };


    public enum RTM_STORAGE_TYPE
    {

        RTM_STORAGE_TYPE_USER = 0,

        RTM_STORAGE_TYPE_CHANNEL = 1,
    };


    public enum RTM_LOCK_EVENT_TYPE
    {

        RTM_LOCK_EVENT_TYPE_SNAPSHOT = 0,

        RTM_LOCK_EVENT_TYPE_LOCK_SET = 1,

        RTM_LOCK_EVENT_TYPE_LOCK_REMOVED = 2,

        RTM_LOCK_EVENT_TYPE_LOCK_ACQUIRED = 3,

        RTM_LOCK_EVENT_TYPE_LOCK_RELEASED = 4,

        RTM_LOCK_EVENT_TYPE_LOCK_EXPIRED = 5,
    };


    public enum OPERATION_ERROR_CODE
    {

        OPERATION_ERROR_OK = 0,

        OPERATION_ERROR_FAILURE = 1,

        OPERATION_ERROR_INVALID_ARGUMENT = 2,

        OPERATION_ERROR_TIMEOUT = 3,

        OPERATION_ERROR_OUTDATED_REVISION = 4,

        OPERATION_ERROR_USER_NOT_EXIST = 5,

        OPERATION_ERROR_EXCEED_LIMITATION = 6,

        OPERATION_ERROR_SET_LOCK_ALREADY_EXIST = 7,

        OPERATION_ERROR_ACQUIRE_NOT_EXIST_LOCK = 8,

        OPERATION_ERROR_ACQUIRE_LOCK_FAILED = 9,
    };


    public enum RTM_PROXY_TYPE
    {

        RTM_PROXY_TYPE_NONE = 0,

        RTM_PROXY_TYPE_HTTP = 1,
    };

    public enum RTM_TOPIC_EVENT_TYPE
    {
        RTM_TOPIC_EVENT_TYPE_SNAPSHOT = 0,

        RTM_TOPIC_EVENT_TYPE_REMOTE_JOIN_TOPIC = 1,

        RTM_TOPIC_EVENT_TYPE_REMOTE_LEAVE_TOPIC = 2,
    };

    public enum RTM_PRESENCE_EVENT_TYPE
    {
        RTM_PRESENCE_EVENT_TYPE_SNAPSHOT = 0,

        RTM_PRESENCE_EVENT_TYPE_INTERVAL = 1,

        RTM_PRESENCE_EVENT_TYPE_REMOTE_JOIN_CHANNEL = 2,

        RTM_PRESENCE_EVENT_TYPE_REMOTE_LEAVE_CHANNEL = 3,

        RTM_PRESENCE_EVENT_TYPE_REMOTE_CONNECTION_TIMEOUT = 4,

        RTM_PRESENCE_EVENT_TYPE_REMOTE_STATE_CHANGED = 5,
    };


    public class UserList
    {
        public UserList()
        {
            users = new string[0];
            userCount = 0;
        }

        public UserList(string[] users, uint userCount)
        {
            this.users = users;
            this.userCount = userCount;
        }

        public string[] users;

        public uint userCount;
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
        public ulong publisherCount;

        public TopicInfo()
        {
            topic = "";
            publishers = new PublisherInfo[0];
            publisherCount = 0;
        }

        public TopicInfo(string topic, PublisherInfo[] publishers, ulong publisherCount)
        {
            this.topic = topic;
            this.publishers = publishers;
            this.publisherCount = publisherCount;
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

        public UInt64 statesCount;

        public UserState()
        {
            userId = "";
            states = null;
            statesCount = 0;
        }

        public UserState(string userId, StateItem[] states, UInt64 statesCount)
        {
            this.userId = userId;
            this.states = states;
            this.statesCount = statesCount;
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

        public ChannelInfo(string channelName, RTM_CHANNEL_TYPE channelType)
        {
            this.channelName = channelName;
            this.channelType = channelType;
        }
    };

    public class PresenceOptions
    {

        public bool withUserId;

        public bool withState;

        public PresenceOptions()
        {
            withUserId = true;
            withState = false;
        }

        public PresenceOptions(bool withUserId, bool withState)
        {
            this.withUserId = withUserId;
            this.withState = withState;
        }
    };


    public class PublishOptions
    {
        public RTM_MESSAGE_TYPE type;

        public UInt64 sendTs;

        public PublishOptions()
        {
            type = RTM_MESSAGE_TYPE.RTM_MESSAGE_TYPE_BINARY;
            sendTs = 0;
        }

        public PublishOptions(RTM_MESSAGE_TYPE type, UInt64 sendTs)
        {
            this.type = type;
            this.sendTs = sendTs;
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
            proxyType = RTM_PROXY_TYPE.RTM_PROXY_TYPE_NONE;
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

        private byte[] encryptionKdfSalt32 = new byte[32];

        public byte[] encryptionKdfSalt
        {
            set { Buffer.BlockCopy(value, 0, encryptionKdfSalt32, 0, 32); }

            get { return encryptionKdfSalt32; }
        }

        public RtmEncryptionConfig()
        {
            encryptionMode = RTM_ENCRYPTION_MODE.RTM_ENCRYPTION_MODE_NONE;
            encryptionKey = "";
            encryptionKdfSalt = new byte[32];
        }
    };

    public class RtmMetadata
    {
        public Int64 majorRevision;
        public MetadataItem[] metadataItems;
        public UInt64 metadataItemsSize;

        public RtmMetadata()
        {

        }
    }
}
