using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public delegate void OnMessageEventHandler(MessageEvent @event);

    public delegate void OnPresenceEventHandler(PresenceEvent @event);

    public delegate void OnTopicEventHandler(TopicEvent @event);

    public delegate void OnLockEventHandler(LockEvent @event);

    public delegate void OnStorageEventHandler(StorageEvent @event);

    public delegate void OnConnectionStateChangeHandler(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason);

    public delegate void OnTokenPrivilegeWillExpireHandler(string channelName);

    public interface IRtmClient
    {
        event OnMessageEventHandler OnMessageEvent;

        event OnPresenceEventHandler OnPresenceEvent;

        event OnTopicEventHandler OnTopicEvent;

        event OnLockEventHandler OnLockEvent;

        event OnStorageEventHandler OnStorageEvent;

        event OnConnectionStateChangeHandler OnConnectionStateChange;

        event OnTokenPrivilegeWillExpireHandler OnTokenPrivilegeWillExpire;

        RtmStatus Dispose();

        Task<RtmResult<LoginResult>> LoginAsync(string token);

        RtmStatus Logout();

        IRtmStorage GetStorage();

        IRtmLock GetLock();

        IRtmPresence GetPresence();

        RtmStatus RenewToken(string token);

        Task<RtmResult<PublishResult>> PublishAsync(string channelName, byte[] message, PublishOptions option);

        Task<RtmResult<PublishResult>> PublishAsync(string channelName, string message, PublishOptions option);

        Task<RtmResult<SubscribeResult>> SubscribeAsync(string channelName, SubscribeOptions options);

        Task<RtmResult<UnsubscribeResult>> UnsubscribeAsync(string channelName);

        IStreamChannel CreateStreamChannel(string channelName);

        RtmStatus SetParameters(string parameters);

        RtmStatus SetLogFile(string filePath);

        RtmStatus SetLogLevel(LOG_LEVEL level);

        RtmStatus SetLogFileSize(uint fileSizeInKBytes);
    }
}