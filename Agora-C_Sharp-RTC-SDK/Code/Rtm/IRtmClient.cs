using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    /**
    * Occurs when receive a message.
    *
    * @param event details of message event.
    */
    public delegate void OnMessageEventHandler(MessageEvent @event);

    /**
    * Occurs when remote user presence changed
    *
    * @param event details of presence event.
    */
    public delegate void OnPresenceEventHandler(PresenceEvent @event);

    /**
    * Occurs when remote user join/leave topic or when user first join this channel,
    * got snapshot of topics in this channel
    *
    * @param event details of topic event.
    */
    public delegate void OnTopicEventHandler(TopicEvent @event);

    /**
    * Occurs when lock state changed
    *
    * @param event details of lock event.
    */
    public delegate void OnLockEventHandler(LockEvent @event);

    /**
    * Occurs when receive storage event
    *
    * @param event details of storage event.
    */
    public delegate void OnStorageEventHandler(StorageEvent @event);


    /**
     * Occurs when the connection state changes between rtm sdk and agora service.
     *
     * @param channelName The name of the channel.
     * @param state The new connection state.
     * @param reason The reason for the connection state change.
     */
    public delegate void OnConnectionStateChangeHandler(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason);

    /**
    * Occurs when token will expire in 30 seconds.
    *
    * @param channelName The name of the channel.
    */
    public delegate void OnTokenPrivilegeWillExpireHandler(string channelName);

    /**
    * The IRtmClient class.
    *
    * This class provides the main methods that can be invoked by your app.
    *
    * IRtmClient is the basic interface class of the Agora RTM SDK.
    * Creating an IRtmClient object and then calling the methods of
    * this object enables you to use Agora RTM SDK's functionality.
    */
    public interface IRtmClient
    {
        /**
        * Occurs when receive a message.
        */
        event OnMessageEventHandler OnMessageEvent;

        /**
        * Occurs when remote user presence changed
        */
        event OnPresenceEventHandler OnPresenceEvent;

        /**
        * Occurs when remote user join/leave topic or when user first join this channel,
        * got snapshot of topics in this channel
        */
        event OnTopicEventHandler OnTopicEvent;

        /**
        * Occurs when lock state changed
        */
        event OnLockEventHandler OnLockEvent;

        /**
        * Occurs when receive storage event
        */
        event OnStorageEventHandler OnStorageEvent;

        /**
        * Occurs when the connection state changes between rtm sdk and agora service.
        */
        event OnConnectionStateChangeHandler OnConnectionStateChange;

        /**
        * Occurs when token will expire in 30 seconds.
        */
        event OnTokenPrivilegeWillExpireHandler OnTokenPrivilegeWillExpire;

        /**
        * Get the version info of the Agora RTM SDK.
        *
        * @return The version info of the Agora RTM SDK.
        */
        string GetVersion();

        /**
        * Release RtmClient
        */
        RtmStatus Dispose();

        /**
        * Login the Agora RTM service. The operation result will be notified by \ref agora::rtm::IRtmEventHandler::onLoginResult callback.
        *
        * @param [in] token Token used to login RTM service.
        * 
        * @return The result of login
        */
        Task<RtmResult<LoginResult>> LoginAsync(string token);

        /**
        * Logout the Agora RTM service. Be noticed that this method will break the rtm service including storage/lock/presence.
        *
        * @return The result of logout
        */
        Task<RtmResult<LogoutResult>> LogoutAsync();

        /**
        * Get the storage instance.
        *
        * @return
        * - return NULL if error occurred
        */
        IRtmStorage GetStorage();

        /**
        * Get the lock instance.
        *
        * @return
        * - return NULL if error occurred
        */
        IRtmLock GetLock();

        /**
        * Get the presence instance.
        *
        * @return
        * - return NULL if error occurred
        */
        IRtmPresence GetPresence();

        /**
        * Renews the token. Once a token is enabled and used, it expires after a certain period of time.
        * You should generate a new token on your server, call this method to renew it.
        *
        * @param [in] token Token used renew.
        * 
        * @return The result of renewToken
        */
        Task<RtmResult<RenewTokenResult>> RenewTokenAsync(string token);

        /**
        * Publish a message in the channel.
        *
        * @param [in] channelName The name of the channel.
        * @param [in] message The content of the message.
        * @param [in] option The option of the message.
        *       
        * @return The result of publish
        */
        Task<RtmResult<PublishResult>> PublishAsync(string channelName, byte[] message, PublishOptions option);

        /**
        * Publish a message in the channel.
        *
        * @param [in] channelName The name of the channel.
        * @param [in] message The content of the message.
        * @param [in] option The option of the message.
        *       
        * @return The result of publish
        */
        Task<RtmResult<PublishResult>> PublishAsync(string channelName, string message, PublishOptions option);

        /**
        * Subscribe a channel.
        *
        * @param [in] channelName The name of the channel.
        * @param [in] options The options of subscribe the channel.
        * 
        * @return The result of subscribe
        */
        Task<RtmResult<SubscribeResult>> SubscribeAsync(string channelName, SubscribeOptions options);

        /**
        * Subscribe a channel.
        *
        * @param [in] channelName The name of the channel.
        * 
        * @return The result of unsubscribe
        */
        Task<RtmResult<UnsubscribeResult>> UnsubscribeAsync(string channelName);

        /**
        * Create a stream channel instance.
        *
        * @param [in] channelName The Name of the channel.
        * 
        * @return
        * - return NULL if error occurred
        */
        IStreamChannel CreateStreamChannel(string channelName);

        /**
        * Set parameters of the sdk or engine
        *
        * @param [in] parameters The parameters in json format
        * 
        * @return The result of setParameter
        */
        RtmStatus SetParameters(string parameters);

        /**
        * Set log file path
        *
        * @param [in] filePath The path of log file
        * 
        * @return The result of SetLogFile
        */
        RtmStatus SetLogFile(string filePath);

        /**
        * Set log file level
        *
        * @param [in] level The Level of log file
        * 
        * @return The result of SetLogLevel
        */
        RtmStatus SetLogLevel(LOG_LEVEL level);

        /**
        * Set  the max log file size
        *
        * @param [in] fileSizeInKBytes The size of log file
        * 
        * @return The result of SetLogFileSize
        */
        RtmStatus SetLogFileSize(uint fileSizeInKBytes);
    }
}