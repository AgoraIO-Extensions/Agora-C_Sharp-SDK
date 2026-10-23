using System;
namespace Agora.Rtm
{

    public enum RTM_LINK_STATE
    {
        ///
        /// <summary>
        /// The initial state.
        /// </summary>
        ///
        IDLE = 0,
        ///
        /// <summary>
        /// The SDK is connecting to the server.
        /// </summary>
        ///
        CONNECTING = 1,
        ///
        /// <summary>
        /// The SDK has connected to the server.
        /// </summary>
        ///
        CONNECTED = 2,
        ///
        /// <summary>
        /// The SDK is disconnected from the server.
        /// </summary>
        ///
        DISCONNECTED = 3,
        ///
        /// <summary>
        /// The SDK link is suspended.
        /// </summary>
        ///
        SUSPENDED = 4,
        ///
        /// <summary>
        /// The SDK is failed to connect to the server.
        /// </summary>
        ///
        FAILED = 5,
    };

    ///
    /// <summary>
    /// Rtm link operation.
    /// </summary>
    ///
    public enum RTM_LINK_OPERATION
    {
        ///
        /// <summary>
        /// Login.
        /// </summary>
        ///
        LOGIN = 0,
        ///
        /// <summary>
        /// Logout.
        /// </summary>
        ///
        LOGOUT = 1,
        ///
        /// <summary>
        /// Join
        /// </summary>
        ///
        JOIN = 2,
        ///
        /// <summary>
        /// Leave.
        /// </summary>
        ///
        LEAVE = 3,
        ///
        /// <summary>
        /// Server reject
        /// </summary>
        ///
        SERVER_REJECT = 4,
        ///
        /// <summary>
        /// Auto reconnect
        /// </summary>
        ///
        AUTO_RECONNECT = 5,
        ///
        /// <summary>
        /// Reconnected
        /// </summary>
        ///
        RECONNECTED = 6,
        ///
        /// <summary>
        /// Heartbeat lost
        /// </summary>
        ///
        HEARTBEAT_LOST = 7,
        ///
        /// <summary>
        /// Server timeout
        /// </summary>
        ///
        SERVER_TIMEOUT = 8,
        ///
        /// <summary>
        /// Network change
        /// </summary>
        ///
        NETWORK_CHANGE = 9,
    };


    ///
    /// <summary>
    /// Rtm service type.
    /// </summary>
    ///
    public enum RTM_SERVICE_TYPE
    {
        ///
        /// <summary>
        /// The type of rtm service not specified.
        /// </summary>
        ///
        NONE = 0x00000000,
        ///
        /// <summary>
        /// The basic functionality of rtm service.
        /// </summary>
        ///
        MESSAGE = 0x00000001,
        ///
        /// <summary>
        /// The advanced functionality of rtm service.
        /// </summary>
        ///
        STREAM = 0x00000002,
    };

    ///
    /// <summary>
    /// Rtm link state change reason.
    /// </summary>
    ///
    public enum RTM_LINK_STATE_CHANGE_REASON
    {
        ///
        /// <summary>
        /// Unknown reason.
        /// </summary>
        ///
        UNKNOWN = 0,
        ///
        /// <summary>
        /// Login.
        /// </summary>
        ///
        LOGIN = 1,
        ///
        /// <summary>
        /// Login success.
        /// </summary>
        ///
        LOGIN_SUCCESS = 2,
        ///
        /// <summary>
        /// Login timeout.
        /// </summary>
        ///
        LOGIN_TIMEOUT = 3,
        ///
        /// <summary>
        /// Login not authorized.
        /// </summary>
        ///
        LOGIN_NOT_AUTHORIZED = 4,
        ///
        /// <summary>
        /// Login rejected.
        /// </summary>
        ///
        LOGIN_REJECTED = 5,
        ///
        /// <summary>
        /// Re-login.
        /// </summary>
        ///
        RELOGIN = 6,
        ///
        /// <summary>
        /// Logout.
        /// </summary>
        ///
        LOGOUT = 7,
        ///
        /// <summary>
        /// Auto reconnect.
        /// </summary>
        ///
        AUTO_RECONNECT = 8,
        ///
        /// <summary>
        /// Reconnect timeout.
        /// </summary>
        ///
        RECONNECT_TIMEOUT = 9,
        ///
        /// <summary>
        /// Reconnect success.
        /// </summary>
        ///
        RECONNECT_SUCCESS = 10,
        ///
        /// <summary>
        /// Join.
        /// </summary>
        ///
        JOIN = 11,
        ///
        /// <summary>
        /// Join success.
        /// </summary>
        ///
        JOIN_SUCCESS = 12,
        ///
        /// <summary>
        /// Join failed.
        /// </summary>
        ///
        JOIN_FAILED = 13,
        ///
        /// <summary>
        /// Rejoin.
        /// </summary>
        ///
        REJOIN = 14,
        ///
        /// <summary>
        /// Leave.
        /// </summary>
        ///
        LEAVE = 15,
        ///
        /// <summary>
        /// Invalid token.
        /// </summary>
        ///
        INVALID_TOKEN = 16,
        ///
        /// <summary>
        /// Token expired.
        /// </summary>
        ///
        TOKEN_EXPIRED = 17,
        ///
        /// <summary>
        /// Inconsistent app ID.
        /// </summary>
        ///
        INCONSISTENT_APP_ID = 18,
        ///
        /// <summary>
        /// Invalid channel name.
        /// </summary>
        ///
        INVALID_CHANNEL_NAME = 19,
        ///
        /// <summary>
        /// Invalid user ID.
        /// </summary>
        ///
        INVALID_USER_ID = 20,
        ///
        /// <summary>
        /// Not initialized.
        /// </summary>
        ///
        NOT_INITIALIZED = 21,
        ///
        /// <summary>
        /// Rtm service not connected.
        /// </summary>
        ///
        RTM_SERVICE_NOT_CONNECTED = 22,
        ///
        /// <summary>
        /// Channel instance exceed limitation.
        /// </summary>
        ///
        CHANNEL_INSTANCE_EXCEED_LIMITATION = 23,
        ///
        /// <summary>
        /// Operation rate exceed limitation.
        /// </summary>
        ///
        OPERATION_RATE_EXCEED_LIMITATION = 24,
        ///
        /// <summary>
        /// Channel in error state.
        /// </summary>
        ///
        CHANNEL_IN_ERROR_STATE = 25,
        ///
        /// <summary>
        /// Presence not connected.
        /// </summary>
        ///
        PRESENCE_NOT_CONNECTED = 26,
        ///
        /// <summary>
        /// Same UID login.
        /// </summary>
        ///
        SAME_UID_LOGIN = 27,
        ///
        /// <summary>
        /// Kicked out by server.
        /// </summary>
        ///
        KICKED_OUT_BY_SERVER = 28,
        ///
        /// <summary>
        /// Keep alive timeout.
        /// </summary>
        ///
        KEEP_ALIVE_TIMEOUT = 29,
        ///
        /// <summary>
        /// Connection error.
        /// </summary>
        ///
        CONNECTION_ERROR = 30,
        ///
        /// <summary>
        /// Presence not ready.
        /// </summary>
        ///
        PRESENCE_NOT_READY = 31,
        ///
        /// <summary>
        /// Network change.
        /// </summary>
        ///
        NETWORK_CHANGE = 32,
        ///
        /// <summary>
        /// Service not supported.
        /// </summary>
        ///
        SERVICE_NOT_SUPPORTED = 33,
        ///
        /// <summary>
        /// Stream channel not available.
        /// </summary>
        ///
        STREAM_CHANNEL_NOT_AVAILABLE = 34,
        ///
        /// <summary>
        /// storage not available.
        /// </summary>
        ///
        STORAGE_NOT_AVAILABLE = 35,
        ///
        /// <summary>
        /// Lock not available.
        /// </summary>
        ///
        LOCK_NOT_AVAILABLE = 36,
    };

    ///
    /// <summary>
    /// Rtm protocol type for underlying connection.
    /// </summary>
    ///
    public enum RTM_PROTOCOL_TYPE
    {
        ///
        /// <summary>
        /// TCP and UDP (default).
        /// </summary>
        ///
        TCP_UDP = 0,
        ///
        /// <summary>
        /// Use TCP only.
        /// </summary>
        ///
        TCP_ONLY = 1,
    };

    ///
    /// <summary>
    /// IP areas.
    /// </summary>
    ///
    public enum RTM_AREA_CODE : uint
    {
        ///
        /// <summary>
        /// Mainland China.
        /// </summary>
        ///
        CN = 0x00000001,
        ///
        /// <summary>
        /// North America.
        /// </summary>
        ///
        NA = 0x00000002,
        ///
        /// <summary>
        /// Europe.
        /// </summary>
        ///
        EU = 0x00000004,
        ///
        /// <summary>
        /// Asia, excluding Mainland China.
        /// </summary>
        ///
        AS = 0x00000008,
        ///
        /// <summary>
        /// Japan.
        /// </summary>
        ///
        JP = 0x00000010,
        ///
        /// <summary>
        /// India.
        /// </summary>
        ///
        IN = 0x00000020,
        ///
        /// <summary>
        /// (Default) Global.
        /// </summary>
        ///
        GLOB = (0xFFFFFFFF)
    }

    ///
    /// <summary>
    /// The log level for rtm sdk.
    /// </summary>
    ///
    public enum RTM_LOG_LEVEL
    {
        ///
        /// <summary>
        /// 0x0000: No logging.
        /// </summary>
        ///
        NONE = 0x0000,
        ///
        /// <summary>
        /// 0x0001: Informational messages.
        /// </summary>
        ///
        INFO = 0x0001,
        ///
        /// <summary>
        /// 0x0002: Warnings.
        /// </summary>
        ///
        WARN = 0x0002,
        ///
        /// <summary>
        /// 0x0004: Errors.
        /// </summary>
        ///
        ERROR = 0x0004,
        ///
        /// <summary>
        /// 0x0008: Critical errors that may lead to program termination.
        /// </summary>
        ///
        FATAL = 0x0008,
    }

    public enum RTM_ENCRYPTION_MODE
    {
        NONE = 0,

        AES_128_GCM = 1,

        AES_256_GCM = 2,
    }

    ///
    /// <summary>
    /// The error codes of rtm client.
    /// </summary>
    ///
    public enum RTM_ERROR_CODE
    {
        ///
        /// <summary>
        /// 0: No error occurs.
        /// </summary>
        ///
        OK = 0,

        ///
        /// <summary>
        /// -10001 ~ -11000 : reserved for generic error.
        /// -10001: The SDK is not initialized.
        /// </summary>
        ///
        NOT_INITIALIZED = -10001,
        ///
        /// <summary>
        /// -10002: The user didn't login the RTM system.
        /// </summary>
        ///
        NOT_LOGIN = -10002,
        ///
        /// <summary>
        /// -10003: The app ID is invalid.
        /// </summary>
        ///
        INVALID_APP_ID = -10003,
        ///
        /// <summary>
        /// -10004: The event handler is invalid.
        /// </summary>
        ///
        INVALID_EVENT_HANDLER = -10004,
        ///
        /// <summary>
        /// -10005: The token is invalid.
        /// </summary>
        ///
        INVALID_TOKEN = -10005,
        ///
        /// <summary>
        /// -10006: The user ID is invalid.
        /// </summary>
        ///
        INVALID_USER_ID = -10006,
        ///
        /// <summary>
        /// -10007: The service is not initialized.
        /// </summary>
        ///
        INIT_SERVICE_FAILED = -10007,
        ///
        /// <summary>
        /// -10008: The channel name is invalid.
        /// </summary>
        ///
        INVALID_CHANNEL_NAME = -10008,
        ///
        /// <summary>
        /// -10009: The token has expired.
        /// </summary>
        ///
        TOKEN_EXPIRED = -10009,
        ///
        /// <summary>
        /// -10010: There is no server resources now.
        /// </summary>
        ///
        LOGIN_NO_SERVER_RESOURCES = -10010,
        ///
        /// <summary>
        /// -10011: The login timeout.
        /// </summary>
        ///
        LOGIN_TIMEOUT = -10011,
        ///
        /// <summary>
        /// -10012: The login is rejected by server.
        /// </summary>
        ///
        LOGIN_REJECTED = -10012,
        ///
        /// <summary>
        /// -10013: The login is aborted due to unrecoverable error.
        /// </summary>
        ///
        LOGIN_ABORTED = -10013,
        ///
        /// <summary>
        /// -10014: The parameter is invalid.
        /// </summary>
        ///
        INVALID_PARAMETER = -10014,
        ///
        /// <summary>
        /// -10015: The login is not authorized. Happens user login the RTM system without granted from console.
        /// </summary>
        ///
        LOGIN_NOT_AUTHORIZED = -10015,
        ///
        /// <summary>
        /// -10016: Try to login or join with inconsistent app ID.
        /// </summary>
        ///
        INCONSISTENT_APPID = -10016,
        ///
        /// <summary>
        /// -10017: Already call same request.
        /// </summary>
        ///
        DUPLICATE_OPERATION = -10017,
        ///
        /// <summary>
        /// -10018: Already call destroy or release, this instance is forbidden to call any api, please create new instance.
        /// </summary>
        ///
        INSTANCE_ALREADY_RELEASED = -10018,
        ///
        /// <summary>
        /// -10019: The channel type is invalid.
        /// </summary>
        ///
        INVALID_CHANNEL_TYPE = -10019,
        ///
        /// <summary>
        /// -10020: The encryption parameter is invalid.
        /// </summary>
        ///
        INVALID_ENCRYPTION_PARAMETER = -10020,
        ///
        /// <summary>
        /// -10021: The operation is too frequent.
        /// </summary>
        ///
        OPERATION_RATE_EXCEED_LIMITATION = -10021,


        ///
        /// <summary>
        /// -10022: The service is not configured in private config mode.
        /// </summary>
        ///
        SERVICE_NOT_SUPPORTED = -10022,
        ///
        /// <summary>
        /// -10023: This login operation stopped by a new login operation or logout operation.
        /// </summary>
        ///
        LOGIN_CANCELED = -10023,
        ///
        /// <summary>
        /// -10024: The private config is invalid, set private config should both set serviceType and accessPointHosts.
        /// </summary>
        ///
        INVALID_PRIVATE_CONFIG = -10024,
        ///
        /// <summary>
        /// -10025: Perform operation failed due to RTM service is not connected.
        /// </summary>
        ///
        NOT_CONNECTED = -10025,
        ///
        /// <summary>
        /// -11001 ~ -12000 : reserved for channel error.
        /// -11001: The user has not joined the channel.
        /// </summary>
        ///
        CHANNEL_NOT_JOINED = -11001,
        ///
        /// <summary>
        /// -11002: The user has not subscribed the channel.
        /// </summary>
        ///
        CHANNEL_NOT_SUBSCRIBED = -11002,
        ///
        /// <summary>
        /// -11003: The topic member count exceeds the limit.
        /// </summary>
        ///
        CHANNEL_EXCEED_TOPIC_USER_LIMITATION = -11003,
        ///
        /// <summary>
        /// -11004: The channel is reused in RTC.
        /// </summary>
        ///
        CHANNEL_IN_REUSE = -11004,
        ///
        /// <summary>
        /// -11005: The channel instance count exceeds the limit.
        /// </summary>
        ///
        CHANNEL_INSTANCE_EXCEED_LIMITATION = -11005,
        ///
        /// <summary>
        /// -11006: The channel is in error state.
        /// </summary>
        ///
        CHANNEL_IN_ERROR_STATE = -11006,
        ///
        /// <summary>
        /// -11007: The channel join failed.
        /// </summary>
        ///
        CHANNEL_JOIN_FAILED = -11007,
        ///
        /// <summary>
        /// -11008: The topic name is invalid.
        /// </summary>
        ///
        CHANNEL_INVALID_TOPIC_NAME = -11008,
        ///
        /// <summary>
        /// -11009: The message is invalid.
        /// </summary>
        ///
        CHANNEL_INVALID_MESSAGE = -11009,
        ///
        /// <summary>
        /// -11010: The message length exceeds the limit.
        /// </summary>
        ///
        CHANNEL_MESSAGE_LENGTH_EXCEED_LIMITATION = -11010,
        ///
        /// <summary>
        /// -11011: The user list is invalid.
        /// </summary>
        ///
        CHANNEL_INVALID_USER_LIST = -11011,
        ///
        /// <summary>
        /// -11012: The stream channel is not available.
        /// </summary>
        ///
        CHANNEL_NOT_AVAILABLE = -11012,
        ///
        /// <summary>
        /// -11013: The topic is not subscribed.
        /// </summary>
        ///
        CHANNEL_TOPIC_NOT_SUBSCRIBED = -11013,
        ///
        /// <summary>
        /// -11014: The topic count exceeds the limit.
        /// </summary>
        ///
        CHANNEL_EXCEED_TOPIC_LIMITATION = -11014,
        ///
        /// <summary>
        /// -11015: Join topic failed.
        /// </summary>
        ///
        CHANNEL_JOIN_TOPIC_FAILED = -11015,
        ///
        /// <summary>
        /// -11016: The topic is not joined.
        /// </summary>
        ///
        CHANNEL_TOPIC_NOT_JOINED = -11016,
        ///
        /// <summary>
        /// -11017: The topic does not exist.
        /// </summary>
        ///
        CHANNEL_TOPIC_NOT_EXIST = -11017,
        ///
        /// <summary>
        /// -11018: The topic meta is invalid.
        /// </summary>
        ///
        CHANNEL_INVALID_TOPIC_META = -11018,
        ///
        /// <summary>
        /// -11019: Subscribe channel timeout.
        /// </summary>
        ///
        CHANNEL_SUBSCRIBE_TIMEOUT = -11019,
        ///
        /// <summary>
        /// -11020: Subscribe channel too frequent.
        /// </summary>
        ///
        CHANNEL_SUBSCRIBE_TOO_FREQUENT = -11020,
        ///
        /// <summary>
        /// -11021: Subscribe channel failed.
        /// </summary>
        ///
        CHANNEL_SUBSCRIBE_FAILED = -11021,
        ///
        /// <summary>
        /// -11022: Unsubscribe channel failed.
        /// </summary>
        ///
        CHANNEL_UNSUBSCRIBE_FAILED = -11022,
        ///
        /// <summary>
        /// -11023: Encrypt message failed.
        /// </summary>
        ///
        CHANNEL_ENCRYPT_MESSAGE_FAILED = -11023,
        ///
        /// <summary>
        /// -11024: Publish message failed.
        /// </summary>
        ///
        CHANNEL_PUBLISH_MESSAGE_FAILED = -11024,
        ///
        /// <summary>
        /// -11025: Publish message too frequent.
        /// </summary>
        ///
        CHANNEL_PUBLISH_MESSAGE_TOO_FREQUENT = -11025,
        ///
        /// <summary>
        /// -11026: Publish message timeout.
        /// </summary>
        ///
        CHANNEL_PUBLISH_MESSAGE_TIMEOUT = -11026,
        ///
        /// <summary>
        /// -11027: The connection state is invalid.
        /// </summary>
        ///
        CHANNEL_NOT_CONNECTED = -11027,
        ///
        /// <summary>
        /// -11028: Leave channel failed.
        /// </summary>
        ///
        CHANNEL_LEAVE_FAILED = -11028,
        ///
        /// <summary>
        /// -11029: The custom type length exceeds the limit.
        /// </summary>
        ///
        CHANNEL_CUSTOM_TYPE_LENGTH_OVERFLOW = -11029,
        ///
        /// <summary>
        /// -11030: The custom type is invalid.
        /// </summary>
        ///
        CHANNEL_INVALID_CUSTOM_TYPE = -11030,
        ///
        /// <summary>
        /// -11031: unsupported message type (in MacOS/iOS platform，message only support NSString and NSData)
        /// </summary>
        ///
        CHANNEL_UNSUPPORTED_MESSAGE_TYPE = -11031,
        ///
        /// <summary>
        /// -11032: The channel presence is not ready.
        /// </summary>
        ///
        CHANNEL_PRESENCE_NOT_READY = -11032,
        ///
        /// <summary>
        /// -11033: The destination user of publish message is offline.
        /// </summary>
        ///
        CHANNEL_RECEIVER_OFFLINE = -11033,

        ///
        /// <summary>
        /// -11034: The channel join operation is canceled.
        /// </summary>
        ///
        CHANNEL_JOIN_CANCELED = -11034,

        ///
        /// <summary>
        /// -11035: The message receiver is offline but the message store in history succeeded.
        /// </summary>
        ///
        CHANNEL_RECEIVER_OFFLINE_BUT_STORE_SUCCEEDED = -11035,
        ///
        /// <summary>
        /// -11036: The message receiver is offline and the message store in history failed.
        /// </summary>
        ///
        CHANNEL_RECEIVER_OFFLINE_AND_STORE_FAILED = -11036,
        ///
        /// <summary>
        /// -11037: The message delivered successfully but store in history failed.
        /// </summary>
        ///
        CHANNEL_MESSAGE_DELIVERED_BUT_STORE_FAILED = -11037,
        ///
        /// <summary>
        /// -12001 ~ -13000 : reserved for storage error.
        /// -12001: The storage operation failed.
        /// </summary>
        ///
        STORAGE_OPERATION_FAILED = -12001,
        ///
        /// <summary>
        /// -12002: The metadata item count exceeds the limit.
        /// </summary>
        ///
        STORAGE_METADATA_ITEM_EXCEED_LIMITATION = -12002,
        ///
        /// <summary>
        /// -12003: The metadata item is invalid.
        /// </summary>
        ///
        STORAGE_INVALID_METADATA_ITEM = -12003,
        ///
        /// <summary>
        /// -12004: The argument in storage operation is invalid.
        /// </summary>
        ///
        STORAGE_INVALID_ARGUMENT = -12004,
        ///
        /// <summary>
        /// -12005: The revision in storage operation is invalid.
        /// </summary>
        ///
        STORAGE_INVALID_REVISION = -12005,
        ///
        /// <summary>
        /// -12006: The metadata length exceeds the limit.
        /// </summary>
        ///
        STORAGE_METADATA_LENGTH_OVERFLOW = -12006,
        ///
        /// <summary>
        /// -12007: The lock name in storage operation is invalid.
        /// </summary>
        ///
        STORAGE_INVALID_LOCK_NAME = -12007,
        ///
        /// <summary>
        /// -12008: The lock in storage operation is not acquired.
        /// </summary>
        ///
        STORAGE_LOCK_NOT_ACQUIRED = -12008,
        ///
        /// <summary>
        /// -12009: The metadata key is invalid.
        /// </summary>
        ///
        STORAGE_INVALID_KEY = -12009,
        ///
        /// <summary>
        /// -12010: The metadata value is invalid.
        /// </summary>
        ///
        STORAGE_INVALID_VALUE = -12010,
        ///
        /// <summary>
        /// -12011: The metadata key length exceeds the limit.
        /// </summary>
        ///
        STORAGE_KEY_LENGTH_OVERFLOW = -12011,
        ///
        /// <summary>
        /// -12012: The metadata value length exceeds the limit.
        /// </summary>
        ///
        STORAGE_VALUE_LENGTH_OVERFLOW = -12012,
        ///
        /// <summary>
        /// -12013: The metadata key already exists.
        /// </summary>
        ///
        STORAGE_DUPLICATE_KEY = -12013,
        ///
        /// <summary>
        /// -12014: The revision in storage operation is outdated.
        /// </summary>
        ///
        STORAGE_OUTDATED_REVISION = -12014,
        ///
        /// <summary>
        /// -12015: The storage operation performed without subscribing.
        /// </summary>
        ///
        STORAGE_NOT_SUBSCRIBE = -12015,
        ///
        /// <summary>
        /// -12016: The metadata item is invalid.
        /// </summary>
        ///
        STORAGE_INVALID_METADATA_INSTANCE = -12016,
        ///
        /// <summary>
        /// -12017: The user count exceeds the limit when try to subscribe.
        /// </summary>
        ///
        STORAGE_SUBSCRIBE_USER_EXCEED_LIMITATION = -12017,
        ///
        /// <summary>
        /// -12018: The storage operation timeout.
        /// </summary>
        ///
        STORAGE_OPERATION_TIMEOUT = -12018,
        ///
        /// <summary>
        /// -12019: The storage service not available.
        /// </summary>
        ///
        STORAGE_NOT_AVAILABLE = -12019,

        ///
        /// <summary>
        /// -13001 ~ -14000 : reserved for presence error.
        /// -13001: The user is not connected.
        /// </summary>
        ///
        PRESENCE_NOT_CONNECTED = -13001,
        ///
        /// <summary>
        /// -13002: The presence is not writable.
        /// </summary>
        ///
        PRESENCE_NOT_WRITABLE = -13002,
        ///
        /// <summary>
        /// -13003: The argument in presence operation is invalid.
        /// </summary>
        ///
        PRESENCE_INVALID_ARGUMENT = -13003,
        ///
        /// <summary>
        /// -13004: The cached presence state count exceeds the limit.
        /// </summary>
        ///
        PRESENCE_CACHED_TOO_MANY_STATES = -13004,
        ///
        /// <summary>
        /// -13005: The state count exceeds the limit.
        /// </summary>
        ///
        PRESENCE_STATE_COUNT_OVERFLOW = -13005,
        ///
        /// <summary>
        /// -13006: The state key is invalid.
        /// </summary>
        ///
        PRESENCE_INVALID_STATE_KEY = -13006,
        ///
        /// <summary>
        /// -13007: The state value is invalid.
        /// </summary>
        ///
        PRESENCE_INVALID_STATE_VALUE = -13007,
        ///
        /// <summary>
        /// -13008: The state key length exceeds the limit.
        /// </summary>
        ///
        PRESENCE_STATE_KEY_SIZE_OVERFLOW = -13008,
        ///
        /// <summary>
        /// -13009: The state value length exceeds the limit.
        /// </summary>
        ///
        PRESENCE_STATE_VALUE_SIZE_OVERFLOW = -13009,
        ///
        /// <summary>
        /// -13010: The state key already exists.
        /// </summary>
        ///
        PRESENCE_STATE_DUPLICATE_KEY = -13010,
        ///
        /// <summary>
        /// -13011: The user is not exist.
        /// </summary>
        ///
        PRESENCE_USER_NOT_EXIST = -13011,
        ///
        /// <summary>
        /// -13012: The presence operation timeout.
        /// </summary>
        ///
        PRESENCE_OPERATION_TIMEOUT = -13012,
        ///
        /// <summary>
        /// -13013: The presence operation failed.
        /// </summary>
        ///
        PRESENCE_OPERATION_FAILED = -13013,

        ///
        /// <summary>
        /// -14001 ~ -15000 : reserved for lock error.
        /// -14001: The lock operation failed.
        /// </summary>
        ///
        LOCK_OPERATION_FAILED = -14001,
        ///
        /// <summary>
        /// -14002: The lock operation timeout.
        /// </summary>
        ///
        LOCK_OPERATION_TIMEOUT = -14002,
        ///
        /// <summary>
        /// -14003: The lock operation is performing.
        /// </summary>
        ///
        LOCK_OPERATION_PERFORMING = -14003,
        ///
        /// <summary>
        /// -14004: The lock already exists.
        /// </summary>
        ///
        LOCK_ALREADY_EXIST = -14004,
        ///
        /// <summary>
        /// -14005: The lock name is invalid.
        /// </summary>
        ///
        LOCK_INVALID_NAME = -14005,
        ///
        /// <summary>
        /// -14006: The lock is not acquired.
        /// </summary>
        ///
        LOCK_NOT_ACQUIRED = -14006,
        ///
        /// <summary>
        /// -14007: Acquire lock failed.
        /// </summary>
        ///
        LOCK_ACQUIRE_FAILED = -14007,
        ///
        /// <summary>
        /// -14008: The lock is not exist.
        /// </summary>
        ///
        LOCK_NOT_EXIST = -14008,
        ///
        /// <summary>
        /// -14009: The lock service is not available.
        /// </summary>
        ///
        LOCK_NOT_AVAILABLE = -14009,
        ///
        /// <summary>
        /// -15001 ~ -16000 : reserved for history error.
        /// -15001: The history operation failed.
        /// </summary>
        ///
        HISTORY_OPERATION_FAILED = -15001,
        ///
        /// <summary>
        /// -15002: The timestamp is invalid.
        /// </summary>
        ///
        HISTORY_INVALID_TIMESTAMP = -15002,
        ///
        /// <summary>
        /// -15003: The history operation timeout.
        /// </summary>
        ///
        HISTORY_OPERATION_TIMEOUT = -15003,
        ///
        /// <summary>
        /// -15004: The history operation is not permitted.
        /// </summary>
        ///
        HISTORY_OPERATION_NOT_PERMITTED = -15004,
        ///
        /// <summary>
        /// -15005: The history service not available.
        /// </summary>
        ///
        HISTORY_NOT_AVAILABLE = -15005,
    }


    public enum RTM_CONNECTION_STATE
    {

        DISCONNECTED = 1,

        CONNECTING = 2,

        CONNECTED = 3,

        RECONNECTING = 4,

        FAILED = 5,
    }

    ///
    /// <summary>
    /// Reasons for connection state change.
    /// </summary>
    ///
    public enum RTM_CONNECTION_CHANGE_REASON
    {
        ///
        /// <summary>
        /// 0: The SDK is connecting to the server.
        /// </summary>
        ///
        CONNECTING = 0,
        ///
        /// <summary>
        /// 1: The SDK has joined the channel successfully.
        /// </summary>
        ///
        JOIN_SUCCESS = 1,
        ///
        /// <summary>
        /// 2: The connection between the SDK and the server is interrupted.
        /// </summary>
        ///
        INTERRUPTED = 2,
        ///
        /// <summary>
        /// 3: The connection between the SDK and the server is banned by the server.
        /// </summary>
        ///
        BANNED_BY_SERVER = 3,
        ///
        /// <summary>
        /// 4: The SDK fails to join the channel for more than 20 minutes and stops reconnecting to the channel.
        /// </summary>
        ///
        JOIN_FAILED = 4,
        ///
        /// <summary>
        /// 5: The SDK has left the channel.
        /// </summary>
        ///
        LEAVE_CHANNEL = 5,
        ///
        /// <summary>
        /// 6: The connection fails because the App ID is not valid.
        /// </summary>
        ///
        INVALID_APP_ID = 6,
        ///
        /// <summary>
        /// 7: The connection fails because the channel name is not valid.
        /// </summary>
        ///
        INVALID_CHANNEL_NAME = 7,
        ///
        /// <summary>
        /// 8: The connection fails because the token is not valid.
        /// </summary>
        ///
        INVALID_TOKEN = 8,
        ///
        /// <summary>
        /// 9: The connection fails because the token has expired.
        /// </summary>
        ///
        TOKEN_EXPIRED = 9,
        ///
        /// <summary>
        /// 10: The connection is rejected by the server.
        /// </summary>
        ///
        REJECTED_BY_SERVER = 10,
        ///
        /// <summary>
        /// 11: The connection changes to reconnecting because the SDK has set a proxy server.
        /// </summary>
        ///
        SETTING_PROXY_SERVER = 11,
        ///
        /// <summary>
        /// 12: When the connection state changes because the app has renewed the token.
        /// </summary>
        ///
        RENEW_TOKEN = 12,
        ///
        /// <summary>
        /// 13: The IP Address of the app has changed. A change in the network type or IP/Port changes the IP
        /// address of the app.
        /// </summary>
        ///
        CLIENT_IP_ADDRESS_CHANGED = 13,
        ///
        /// <summary>
        /// 14: A timeout occurs for the keep-alive of the connection between the SDK and the server.
        /// </summary>
        ///
        KEEP_ALIVE_TIMEOUT = 14,
        ///
        /// <summary>
        /// 15: The SDK has rejoined the channel successfully.
        /// </summary>
        ///
        REJOIN_SUCCESS = 15,
        ///
        /// <summary>
        /// 16: The connection between the SDK and the server is lost.
        /// </summary>
        ///
        LOST = 16,
        ///
        /// <summary>
        /// 17: The change of connection state is caused by echo test.
        /// </summary>
        ///
        ECHO_TEST = 17,
        ///
        /// <summary>
        /// 18: The local IP Address is changed by user.
        /// </summary>
        ///
        CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,
        ///
        /// <summary>
        /// 19: The connection is failed due to join the same channel on another device with the same uid.
        /// </summary>
        ///
        SAME_UID_LOGIN = 19,
        ///
        /// <summary>
        /// 20: The connection is failed due to too many broadcasters in the channel.
        /// </summary>
        ///
        TOO_MANY_BROADCASTERS = 20,
        ///
        /// <summary>
        /// 21: The connection is failed due to license validation failure.
        /// </summary>
        ///
        LICENSE_VALIDATION_FAILURE = 21,

        ///
        /// <summary>
        /// 22: The connection is failed due to certification verify failure.
        /// </summary>
        ///
        CERTIFICATION_VERIFY_FAILURE = 22,
        ///
        /// <summary>
        /// 22: The connection is failed due to user vid not support stream channel.
        /// </summary>
        ///
        STREAM_CHANNEL_NOT_AVAILABLE = 23,
        ///
        /// <summary>
        /// 23: The connection is failed due to token and appid inconsistent.
        /// </summary>
        ///
        INCONSISTENT_APPID = 24,
        ///
        /// <summary>
        /// 10001: The connection of rtm edge service has been successfully established.
        /// </summary>
        ///
        LOGIN_SUCCESS = 10001,
        ///
        /// <summary>
        /// 10002: User log out Agora RTM system.
        /// </summary>
        ///
        LOGOUT = 10002,
        ///
        /// <summary>
        /// 10003: User log out Agora RTM system.
        /// </summary>
        ///
        PRESENCE_NOT_READY = 10003,
    }

    ///
    /// <summary>
    /// RTM channel type.
    /// </summary>
    ///
    public enum RTM_CHANNEL_TYPE
    {
        ///
        /// <summary>
        /// 0: Unknown channel type.
        /// </summary>
        ///
        NONE = 0,
        ///
        /// <summary>
        /// 1: Message channel.
        /// </summary>
        ///
        MESSAGE = 1,
        ///
        /// <summary>
        /// 2: Stream channel.
        /// </summary>
        ///
        STREAM = 2,
        ///
        /// <summary>
        /// 3: User.
        /// </summary>
        ///
        USER = 3,
    }

    public enum RTM_MESSAGE_TYPE
    {
        ///
        /// <summary>
        /// 0: The binary message.
        /// </summary>
        ///
        BINARY = 0,
        ///
        /// <summary>
        /// 1: The ascii message.
        /// </summary>
        ///
        STRING = 1,
    }
    ;

    ///
    /// <summary>
    /// Storage type indicate the storage event was triggered by user or channel
    /// </summary>
    ///
    public enum RTM_STORAGE_TYPE
    {
        ///
        /// <summary>
        /// 0: Unknown type.
        /// </summary>
        ///
        NONE = 0,
        ///
        /// <summary>
        /// 1: The user storage event.
        /// </summary>
        ///
        USER = 1,
        ///
        /// <summary>
        /// 2: The channel storage event.
        /// </summary>
        ///
        CHANNEL = 2,
    }

    ///
    /// <summary>
    /// The storage event type, indicate storage operation
    /// </summary>
    ///
    public enum RTM_STORAGE_EVENT_TYPE
    {
        ///
        /// <summary>
        /// 0: Unknown event type.
        /// </summary>
        ///
        NONE = 0,
        ///
        /// <summary>
        /// 1: Triggered when user subscribe user metadata state or join channel with options.withMetadata = true
        /// </summary>
        ///
        SNAPSHOT = 1,
        ///
        /// <summary>
        /// 2: Triggered when a remote user set metadata
        /// </summary>
        ///
        SET = 2,
        ///
        /// <summary>
        /// 3: Triggered when a remote user update metadata
        /// </summary>
        ///
        UPDATE = 3,
        ///
        /// <summary>
        /// 4: Triggered when a remote user remove metadata
        /// </summary>
        ///
        REMOVE = 4,
    }

    ///
    /// <summary>
    /// The lock event type, indicate lock operation
    /// </summary>
    ///
    public enum RTM_LOCK_EVENT_TYPE
    {
        ///
        /// <summary>
        /// 0: Unknown event type
        /// </summary>
        ///
        NONE = 0,
        ///
        /// <summary>
        /// 1: Triggered when user subscribe lock state
        /// </summary>
        ///
        SNAPSHOT = 1,
        ///
        /// <summary>
        /// 2: Triggered when a remote user set lock
        /// </summary>
        ///
        SET = 2,
        ///
        /// <summary>
        /// 3: Triggered when a remote user remove lock
        /// </summary>
        ///
        REMOVED = 3,
        ///
        /// <summary>
        /// 4: Triggered when a remote user acquired lock
        /// </summary>
        ///
        ACQUIRED = 4,
        ///
        /// <summary>
        /// 5: Triggered when a remote user released lock
        /// </summary>
        ///
        RELEASED = 5,
        ///
        /// <summary>
        /// 6: Triggered when user reconnect to rtm service,
        /// detect the lock has been acquired and released by others.
        /// </summary>
        ///
        EXPIRED = 6,
    }

    public enum RTM_PROXY_TYPE
    {
        ///
        /// <summary>
        /// 0: Link without proxy
        /// </summary>
        ///
        NONE = 0,

        ///
        /// <summary>
        /// 1: Link with http proxy
        /// </summary>
        ///
        HTTP = 1,


        ///
        /// <summary>
        /// 2: Link with tcp cloud proxy
        /// </summary>
        ///
        CLOUD_TCP = 2,
    }

    ///
    /// <summary>
    /// Topic event type
    /// </summary>
    ///
    public enum RTM_TOPIC_EVENT_TYPE
    {
        ///
        /// <summary>
        /// 0: Unknown event type
        /// </summary>
        ///
        NONE = 0,
        ///
        /// <summary>
        /// 1: The topic snapshot of this channel
        /// </summary>
        ///
        SNAPSHOT = 1,
        ///
        /// <summary>
        /// 2: Triggered when remote user join a topic
        /// </summary>
        ///
        REMOTE_JOIN = 2,
        ///
        /// <summary>
        /// 3: Triggered when remote user leave a topic
        /// </summary>
        ///
        REMOTE_LEAVE = 3,
    }

    ///
    /// <summary>
    /// Presence event type
    /// </summary>
    ///
    public enum RTM_PRESENCE_EVENT_TYPE
    {
        ///
        /// <summary>
        /// 0: Unknown event type
        /// </summary>
        ///
        NONE = 0,
        ///
        /// <summary>
        /// 1: The presence snapshot of this channel
        /// </summary>
        ///
        SNAPSHOT = 1,
        ///
        /// <summary>
        /// 2: The presence event triggered in interval mode
        /// </summary>
        ///
        INTERVAL = 2,
        ///
        /// <summary>
        /// 3: Triggered when remote user join channel
        /// </summary>
        ///
        REMOTE_JOIN = 3,
        ///
        /// <summary>
        /// 4: Triggered when remote user leave channel
        /// </summary>
        ///
        REMOTE_LEAVE = 4,
        ///
        /// <summary>
        /// 5: Triggered when remote user's connection timeout
        /// </summary>
        ///
        REMOTE_TIMEOUT = 5,
        ///
        /// <summary>
        /// 6: Triggered when user changed state
        /// </summary>
        ///
        REMOTE_STATE_CHANGED = 6,
        ///
        /// <summary>
        /// 7: Triggered when user joined channel without presence service
        /// </summary>
        ///
        ERROR_OUT_OF_SERVICE = 7,
    }

    ///
    /// <summary>
    /// Definition of LogConfiguration
    /// </summary>
    ///
    public class RtmLogConfig
    {
        ///
        /// <summary>
        /// The log file path, default is NULL for default log path
        /// </summary>
        ///
        public string filePath;
        ///
        /// <summary>
        /// The log file size, KB , set 1024KB to use default log size
        /// </summary>
        ///
        public uint fileSizeInKB;
        ///
        /// <summary>
        /// The log level, set LOG_LEVEL_INFO to use default log level
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// Topic publisher information
    /// </summary>
    ///
    public class PublisherInfo
    {
        ///
        /// <summary>
        /// The publisher user ID
        /// </summary>
        ///
        public string publisherUserId;

        ///
        /// <summary>
        /// The metadata of the publisher
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// Topic information
    /// </summary>
    ///
    public class TopicInfo
    {
        ///
        /// <summary>
        /// The name of the topic
        /// </summary>
        ///
        public string topic;

        ///
        /// <summary>
        /// The publisher array
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// User state property
    /// </summary>
    ///
    public class StateItem
    {
        ///
        /// <summary>
        /// The key of the state item.
        /// </summary>
        ///
        public string key;

        ///
        /// <summary>
        /// The value of the state item.
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// The information of a Lock.
    /// </summary>
    ///
    public class LockDetail
    {
        ///
        /// <summary>
        /// The name of the lock.
        /// </summary>
        ///
        public string lockName;

        ///
        /// <summary>
        /// The owner of the lock. Only valid when user getLocks or receive LockEvent with RTM_LOCK_EVENT_TYPE_SNAPSHOT
        /// </summary>
        ///
        public string owner;

        ///
        /// <summary>
        /// The ttl of the lock.
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// The states of user.
    /// </summary>
    ///
    public class UserState
    {
        ///
        /// <summary>
        /// The user id.
        /// </summary>
        ///
        public string userId;

        ///
        /// <summary>
        /// The user states.
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// The subscribe option.
    /// </summary>
    ///
    public class SubscribeOptions
    {
        ///
        /// <summary>
        /// Whether to subscribe channel with message
        /// </summary>
        ///
        public bool withMessage;

        ///
        /// <summary>
        /// Whether to subscribe channel with metadata
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

        ///
        /// <summary>
        /// Whether to subscribe channel in quiet mode
        /// Quiet mode means remote user will not receive any notification when we subscribe or
        /// unsubscribe or change our presence state
        /// </summary>
        ///
        public bool beQuiet;

        public SubscribeOptions()
        {
            withMessage = true;
            withMetadata = false;
            withPresence = true;
            withLock = false;
            beQuiet = false;
        }
    };

    ///
    /// <summary>
    /// The channel information.
    /// </summary>
    ///
    public class ChannelInfo
    {
        ///
        /// <summary>
        /// The channel which the message was published
        /// </summary>
        ///
        public string channelName;

        ///
        /// <summary>
        /// Which channel type, RTM_CHANNEL_TYPE_STREAM or RTM_CHANNEL_TYPE_MESSAGE
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// The option to query user presence.
    /// </summary>
    ///
    public class PresenceOptions
    {
        ///
        /// <summary>
        /// Whether to display user id in query result
        /// </summary>
        ///
        public bool includeUserId;

        ///
        /// <summary>
        /// Whether to display user state in query result
        /// </summary>
        ///
        public bool includeState;

        ///
        /// <summary>
        /// The paging object used for pagination.
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// The option to query user presence.
    /// </summary>
    ///
    public class GetOnlineUsersOptions
    {
        ///
        /// <summary>
        /// Whether to display user id in query result
        /// </summary>
        ///
        public bool includeUserId;
        ///
        /// <summary>
        /// Whether to display user state in query result
        /// </summary>
        ///
        public bool includeState;
        ///
        /// <summary>
        /// The paging object used for pagination.
        /// </summary>
        ///
        public string page;

        public GetOnlineUsersOptions()
        {
            includeUserId = true;
            includeState = false;
            page = "";
        }

        public GetOnlineUsersOptions(bool includeUserId, bool includeState, string page)
        {
            this.includeUserId = includeUserId;
            this.includeState = includeState;
            this.page = page;
        }
    }

    ///
    /// <summary>
    /// Publish message option
    /// </summary>
    ///
    public class PublishOptions
    {
        ///
        /// <summary>
        /// The channel type.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE channelType;
        ///
        /// <summary>
        /// The custom type of the message, up to 32 bytes for customize
        /// </summary>
        ///
        public string customType;

        ///
        /// <summary>
        /// Whether to store in history, true to enable
        /// </summary>
        ///
        public bool storeInHistory;

        public PublishOptions()
        {
            channelType = RTM_CHANNEL_TYPE.MESSAGE;
            customType = "";
            storeInHistory = false;
        }

        public PublishOptions(RTM_CHANNEL_TYPE channelType, string customType, bool storeInHistory)
        {
            this.channelType = channelType;
            this.customType = customType;
            this.storeInHistory = storeInHistory;
        }
    };

    ///
    /// <summary>
    /// topic message option
    /// </summary>
    ///
    public class TopicMessageOptions
    {
        ///
        /// <summary>
        /// The time to calibrate data with media,
        /// only valid when user join topic with syncWithMedia in stream channel
        /// </summary>
        ///
        public UInt64 sendTs;
        ///
        /// <summary>
        /// The custom type of the message, up to 32 bytes for customize
        /// </summary>
        ///
        public string customType;

        public TopicMessageOptions()
        {
            sendTs = 0;
            customType = "";
        }

        public TopicMessageOptions(UInt64 sendTs, string customType)
        {
            this.sendTs = sendTs;
            this.customType = customType;
        }
    };

    ///
    /// <summary>
    /// Proxy configuration
    /// </summary>
    ///
    public class RtmProxyConfig
    {
        ///
        /// <summary>
        /// The Proxy type.
        /// </summary>
        ///
        public RTM_PROXY_TYPE proxyType;

        ///
        /// <summary>
        /// The Proxy server address.
        /// </summary>
        ///
        public string server;

        ///
        /// <summary>
        /// The Proxy server port.
        /// </summary>
        ///
        public UInt16 port;

        ///
        /// <summary>
        /// The Proxy user account.
        /// </summary>
        ///
        public string account;

        ///
        /// <summary>
        /// The Proxy password.
        /// </summary>
        ///
        public string password;

        public RtmProxyConfig()
        {
            proxyType = RTM_PROXY_TYPE.NONE;
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

    ///
    /// <summary>
    /// encryption configuration
    /// </summary>
    ///
    public class RtmEncryptionConfig
    {
        ///
        /// <summary>
        /// The encryption mode.
        /// </summary>
        ///
        public RTM_ENCRYPTION_MODE encryptionMode;

        ///
        /// <summary>
        /// The encryption key in the string format.
        /// </summary>
        ///
        public string encryptionKey;

        ///
        /// <summary>
        /// The encryption salt.
        /// </summary>
        ///
        private byte[] encryptionSalt32 = new byte[32];

        public byte[] encryptionSalt
        {
            set
            {
                if (value.Length > 32)
                {
                    var status = new RtmStatus();
                    status.Error = true;
                    status.ErrorCode = (int)RTM_ERROR_CODE.INVALID_ENCRYPTION_PARAMETER;
                    status.Reason = "encryptionSalt length must be 32";
                    throw new RTMException(status);
                }
                else
                {
                    Buffer.BlockCopy(value, 0, encryptionSalt32, 0, value.Length);
                    if (value.Length < 32)
                    {
                        for (int i = value.Length; i < 32; i++)
                        {
                            encryptionSalt32[i] = 0;
                        }
                    }
                }
            }

            get
            {
                return encryptionSalt32;
            }
        }

        public RtmEncryptionConfig()
        {
            encryptionMode = RTM_ENCRYPTION_MODE.NONE;
            encryptionKey = "";
            encryptionSalt = new byte[32];
        }
    };

    ///
    /// <summary>
    /// Private configuration
    /// </summary>
    ///
    public class RtmPrivateConfig
    {
        ///
        /// <summary>
        /// Rtm service type.
        /// </summary>
        ///
        public RTM_SERVICE_TYPE serviceType;

        ///
        /// <summary>
        /// Local access point hosts list.
        /// </summary>
        ///
        public string[] accessPointHosts;

        public RtmPrivateConfig()
        {
            serviceType = RTM_SERVICE_TYPE.NONE;
            accessPointHosts = new string[0];
        }
    };

    ///
    /// <summary>
    /// The option to query history message.
    /// </summary>
    ///
    public class GetHistoryMessagesOptions
    {
        ///
        /// <summary>
        /// The maximum count of messages to get.
        /// </summary>
        ///
        public ushort messageCount;
        ///
        /// <summary>
        /// The start timestamp of this query range.
        /// </summary>
        ///
        public UInt64 start;
        ///
        /// <summary>
        /// The end timestamp of this query range.
        /// </summary>
        ///
        public UInt64 end;

        public GetHistoryMessagesOptions()
        {
            messageCount = 100;
            start = 0;
            end = 0;
        }
    };

    ///
    /// <summary>
    /// The details of history message
    /// </summary>
    ///
    public class HistoryMessage
    {
        ///
        /// <summary>
        /// Message type
        /// </summary>
        ///
        public RTM_MESSAGE_TYPE messageType;
        ///
        /// <summary>
        /// The publisher
        /// </summary>
        ///
        public string publisher;
        ///
        /// <summary>
        /// The payload
        /// </summary>
        ///
        public IRtmMessage message;
        ///
        /// <summary>
        /// The custom type of the message
        /// </summary>
        ///
        public string customType;
        ///
        /// <summary>
        /// Timestamp of the message received by rtm server
        /// </summary>
        ///
        public UInt64 timestamp;

        public HistoryMessage()
        {
            messageType = RTM_MESSAGE_TYPE.BINARY;
            publisher = "";
            message = null;
            customType = "";
            timestamp = 0;
        }
    };


    public class Metadata
    {
        ///
        /// <summary>
        /// the major revision of metadata.
        /// </summary>
        ///
        public Int64 majorRevision;
        ///
        /// <summary>
        /// The metadata item array.
        /// </summary>
        ///
        public MetadataItem[] items;

        public Metadata()
        {
            majorRevision = 0;
            items = new MetadataItem[0];
        }
    }
}
