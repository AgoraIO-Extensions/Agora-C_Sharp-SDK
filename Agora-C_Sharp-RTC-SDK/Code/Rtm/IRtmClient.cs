using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    ///
    /// <summary>
    /// Occurs when receive a message.
    /// </summary>
    ///
    /// <param name="event"> details of message event.</param>
    ///
    public delegate void OnMessageEventHandler(MessageEvent @event);

    ///
    /// <summary>
    /// Occurs when remote user presence changed
    /// </summary>
    ///
    /// <param name="event"> details of presence event.</param>
    ///
    public delegate void OnPresenceEventHandler(PresenceEvent @event);

    ///
    /// <summary>
    /// Occurs when remote user join/leave topic or when user first join this channel,
    /// got snapshot of topics in this channel
    /// </summary>
    ///
    /// <param name="event"> details of topic event.</param>
    ///
    public delegate void OnTopicEventHandler(TopicEvent @event);

    ///
    /// <summary>
    /// Occurs when lock state changed
    /// </summary>
    ///
    /// <param name="event"> details of lock event.</param>
    ///
    public delegate void OnLockEventHandler(LockEvent @event);

    ///
    /// <summary>
    /// Occurs when receive storage event
    /// </summary>
    ///
    /// <param name="event"> details of storage event.</param>
    ///
    public delegate void OnStorageEventHandler(StorageEvent @event);

    ///
    /// <summary>
    /// Occurs when the connection state changes between rtm sdk and agora service.
    /// </summary>
    ///
    /// <param name="channelName"> The name of the channel.</param>
    /// <param name="state"> The new connection state.</param>
    /// <param name="reason"> The reason for the connection state change.</param>
    ///
    public delegate void OnConnectionStateChangedHandler(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason);

    ///
    /// <summary>
    /// Occurs when token will expire in 30 seconds.
    /// </summary>
    ///
    /// <param name="channelName"> The name of the channel.</param>
    ///
    public delegate void OnTokenPrivilegeWillExpireHandler(string channelName);

    ///
    /// <summary>
    /// The IRtmClient class.
    /// This class provides the main methods that can be invoked by your app.
    /// IRtmClient is the basic interface class of the Agora RTM SDK.
    /// Creating an IRtmClient object and then calling the methods of
    /// this object enables you to use Agora RTM SDK's functionality.
    /// </summary>
    ///
    public interface IRtmClient
    {
        ///
        /// <summary>
        /// Occurs when receive a message.
        /// </summary>
        ///
        event OnMessageEventHandler OnMessageEvent;

        ///
        /// <summary>
        /// Occurs when remote user presence changed
        /// </summary>
        ///
        event OnPresenceEventHandler OnPresenceEvent;

        ///
        /// <summary>
        /// Occurs when remote user join/leave topic or when user first join this channel,
        /// got snapshot of topics in this channel
        /// </summary>
        ///
        event OnTopicEventHandler OnTopicEvent;

        ///
        /// <summary>
        /// Occurs when lock state changed
        /// </summary>
        ///
        event OnLockEventHandler OnLockEvent;

        ///
        /// <summary>
        /// Occurs when receive storage event
        /// </summary>
        ///
        event OnStorageEventHandler OnStorageEvent;

        ///
        /// <summary>
        /// Occurs when the connection state changes between rtm sdk and agora service.
        /// </summary>
        ///
        event OnConnectionStateChangedHandler OnConnectionStateChanged;

        ///
        /// <summary>
        /// Occurs when token will expire in 30 seconds.
        /// </summary>
        ///
        event OnTokenPrivilegeWillExpireHandler OnTokenPrivilegeWillExpire;

        ///
        /// <summary>
        /// Get the version info of the Agora RTM SDK.
        /// </summary>
        ///
        /// <returns>
        /// The version info of the Agora RTM SDK.
        /// </returns>
        ///
        string GetVersion();

        ///
        /// <summary>
        /// Release RtmClient
        /// </summary>
        ///
        RtmStatus Dispose();

        ///
        /// <summary>
        /// Login the Agora RTM service. The operation result will be notified by \ref agora::rtm::IRtmEventHandler::onLoginResult callback.
        /// </summary>
        ///
        /// <param name="token"> Token used to login RTM service.</param>
        ///
        /// <returns>
        /// The result of login
        /// </returns>
        ///
        Task<RtmResult<LoginResult>> LoginAsync(string token);

        ///
        /// <summary>
        /// Logout the Agora RTM service. Be noticed that this method will break the rtm service including storage/lock/presence.
        /// </summary>
        ///
        /// <returns>
        /// The result of logout
        /// </returns>
        ///
        Task<RtmResult<LogoutResult>> LogoutAsync();

        ///
        /// <summary>
        /// Get the storage instance.
        /// </summary>
        ///
        /// <returns>
        ///
        /// - return NULL if error occurred
        /// </returns>
        ///
        IRtmStorage GetStorage();

        ///
        /// <summary>
        /// Get the lock instance.
        /// </summary>
        ///
        /// <returns>
        ///
        /// - return NULL if error occurred
        /// </returns>
        ///
        IRtmLock GetLock();

        ///
        /// <summary>
        /// Get the presence instance.
        /// </summary>
        ///
        /// <returns>
        ///
        /// - return NULL if error occurred
        /// </returns>
        ///
        IRtmPresence GetPresence();

        ///
        /// <summary>
        /// Renews the token. Once a token is enabled and used, it expires after a certain period of time.
        /// You should generate a new token on your server, call this method to renew it.
        /// </summary>
        ///
        /// <param name="token"> New token.</param>
        ///
        /// <returns>
        /// The result of renewToken
        /// </returns>
        ///
        Task<RtmResult<RenewTokenResult>> RenewTokenAsync(string token);

        ///
        /// <summary>
        /// Publish a message in the channel.
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="message"> The content of the message.</param>
        /// <param name="option"> The option of the message.</param>
        ///
        /// <returns>
        /// The result of publish
        /// </returns>
        ///
        Task<RtmResult<PublishResult>> PublishAsync(string channelName, byte[] message, PublishOptions option);

        ///
        /// <summary>
        /// Publish a message in the channel.
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="message"> The content of the message.</param>
        /// <param name="option"> The option of the message.</param>
        ///
        /// <returns>
        /// The result of publish
        /// </returns>
        ///
        Task<RtmResult<PublishResult>> PublishAsync(string channelName, string message, PublishOptions option);

        ///
        /// <summary>
        /// Subscribe a channel.
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        /// <param name="options"> The options of subscribe the channel.</param>
        ///
        /// <returns>
        /// The result of subscribe
        /// </returns>
        ///
        Task<RtmResult<SubscribeResult>> SubscribeAsync(string channelName, SubscribeOptions options);

        ///
        /// <summary>
        /// Subscribe a channel.
        /// </summary>
        ///
        /// <param name="channelName"> The name of the channel.</param>
        ///
        /// <returns>
        /// The result of unsubscribe
        /// </returns>
        ///
        Task<RtmResult<UnsubscribeResult>> UnsubscribeAsync(string channelName);

        ///
        /// <summary>
        /// Create a stream channel instance.
        /// </summary>
        ///
        /// <param name="channelName"> The Name of the channel.</param>
        ///
        /// <returns>
        ///
        /// - return NULL if error occurred
        /// </returns>
        ///
        IStreamChannel CreateStreamChannel(string channelName);

        ///
        /// <summary>
        /// Set parameters of the sdk or engine
        /// </summary>
        ///
        /// <param name="parameters"> The parameters in json format</param>
        ///
        /// <returns>
        /// The result of setParameter
        /// </returns>
        ///
        RtmStatus SetParameters(string parameters);

        ///
        /// <summary>
        /// Set log file path
        /// </summary>
        ///
        /// <param name="filePath"> The path of log file</param>
        ///
        /// <returns>
        /// The result of SetLogFile
        /// </returns>
        ///
        RtmStatus SetLogFile(string filePath);

        ///
        /// <summary>
        /// Set log file level
        /// </summary>
        ///
        /// <param name="level"> The Level of log file</param>
        ///
        /// <returns>
        /// The result of SetLogLevel
        /// </returns>
        ///
        RtmStatus SetLogLevel(LOG_LEVEL level);

        ///
        /// <summary>
        /// Set  the max log file size
        /// </summary>
        ///
        /// <param name="fileSizeInKBytes"> The size of the log file in kilobytes (KB).</param>
        ///
        /// <returns>
        /// The result of SetLogFileSize
        /// </returns>
        ///
        RtmStatus SetLogFileSize(uint fileSizeInKBytes);
    }
}