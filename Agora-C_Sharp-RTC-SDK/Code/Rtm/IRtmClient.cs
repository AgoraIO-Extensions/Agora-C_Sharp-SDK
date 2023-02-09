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

        RtmStatus Initialize(RtmConfig config);

        RtmStatus Dispose();

        Task<RtmResult<LoginResult>> Login(string token);

        RtmStatus Logout();

        IRtmStorage GetStorage();

        IRtmLock GetLock();

        IRtmPresence GetPresence();

        RtmStatus RenewToken(string token);

        Task<RtmResult<PublishResult>> Publish(string channelName, byte[] message, int length, PublishOptions option);

        Task<RtmResult<PublishResult>> Publish(string channelName, string message, int length, PublishOptions option);

        Task<RtmResult<SubscribeResult>> Subscribe(string channelName, SubscribeOptions options);

        RtmStatus Unsubscribe(string channelName);

        IStreamChannel CreateStreamChannel(string channelName);

        RtmStatus SetParameters(string parameters);

        RtmStatus SetLogFile(string filePath);

        RtmStatus SetLogLevel(LOG_LEVEL level);

        RtmStatus SetLogFileSize(uint fileSizeInKBytes);
    }
}