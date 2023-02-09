using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class RtmClient : IRtmClient
    {
        public event OnMessageEventHandler OnMessageEvent;
        public event OnPresenceEventHandler OnPresenceEvent;
        public event OnTopicEventHandler OnTopicEvent;
        public event OnLockEventHandler OnLockEvent;
        public event OnStorageEventHandler OnStorageEvent;
        public event OnConnectionStateChangeHandler OnConnectionStateChange;
        public event OnTokenPrivilegeWillExpireHandler OnTokenPrivilegeWillExpire;

        private Internal.IRtmClient internalRtmClient;
        private RtmEventHandler rtmEventHandler;

        private static IRtmClient instance = null;

        public static IRtmClient CreateAgoraRtmClient()
        {
            return instance ?? (instance = new RtmClient());
        }

        public static IRtmClient Get()
        {
            return instance;
        }

        public RtmClient()
        {
            internalRtmClient = Internal.RtmClient.CreateAgoraRtmClient();
            rtmEventHandler = new RtmEventHandler(this);
        }

        internal RtmEventHandler GetRtmEventHandler()
        {
            return this.rtmEventHandler;
        }

        internal Internal.IRtmClient GetInternalRtmClient()
        {
            return this.internalRtmClient;
        }

        public void InvokeOnMessageEvent(MessageEvent @event)
        {
            if (this.OnMessageEvent != null)
            {
                this.OnMessageEvent.Invoke(@event);
            }
        }

        public void InvokeOnPresenceEvent(PresenceEvent @event)
        {
            if (this.OnPresenceEvent != null)
            {
                this.OnPresenceEvent.Invoke(@event);
            }
        }

        public void InvokeOnTopicEvent(TopicEvent @event)
        {
            if (this.OnTopicEvent != null)
            {
                this.OnTopicEvent.Invoke(@event);
            }
        }

        public void InvokeOnLockEvent(LockEvent @event)
        {
            if (this.OnLockEvent != null)
            {
                this.OnLockEvent.Invoke(@event);
            }
        }

        public void InvokeOnStorageEvent(StorageEvent @event)
        {
            if (this.OnStorageEvent != null)
            {
                this.OnStorageEvent.Invoke(@event);
            }
        }

        public void InvokeOnConnectionStateChange(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason)
        {
            if (this.OnConnectionStateChange != null)
            {
                this.OnConnectionStateChange.Invoke(channelName, state, reason);
            }
        }
        public void InvokeOnTokenPrivilegeWillExpire(string channelName)
        {
            if (this.OnTokenPrivilegeWillExpire != null)
            {
                this.OnTokenPrivilegeWillExpire.Invoke(channelName);
            }
        }

        public IStreamChannel CreateStreamChannel(string channelName)
        {
            Internal.IStreamChannel internalStreamChannel = this.internalRtmClient.CreateStreamChannel(channelName);
            if (internalStreamChannel == null)
            {
                return null;
            }
            else
            {
                return new StreamChannel(internalStreamChannel, rtmEventHandler, internalRtmClient);
            }
        }

        public RtmStatus Dispose()
        {
            int errorCode = internalRtmClient.Dispose();
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMDisposeOperation, this.internalRtmClient);
        }

        public IRtmLock GetLock()
        {
            Internal.IRtmLock internalRtmLock = this.internalRtmClient.GetLock();
            return new RtmLock(internalRtmLock, rtmEventHandler, internalRtmClient);
        }

        public IRtmPresence GetPresence()
        {
            Internal.IRtmPresence internalRtmPresence = this.internalRtmClient.GetPresence();
            return new RtmPresence(internalRtmPresence, rtmEventHandler, internalRtmClient);
        }

        public IRtmStorage GetStorage()
        {
            Internal.IRtmStorage internalRtmStorage = this.internalRtmClient.GetStorage();
            return new RtmStorage(internalRtmStorage, rtmEventHandler, internalRtmClient);
        }

        public RtmStatus Initialize(RtmConfig config)
        {
            Internal.RtmConfig internalConfig = new Internal.RtmConfig(config, rtmEventHandler);
            int errorCode = internalRtmClient.Initialize(internalConfig);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMInitializeOperation, this.internalRtmClient);
        }

        public Task<RtmResult<LoginResult>> Login(string token)
        {
            TaskCompletionSource<RtmResult<LoginResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<LoginResult>>();
            int errorCode = internalRtmClient.Login(token);
            if (errorCode != 0)
            {
                RtmResult<LoginResult> result = new RtmResult<LoginResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMLoginOperation, this.internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutLoginResultTask(taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public RtmStatus Logout()
        {
            int errorCode = internalRtmClient.Logout();
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMLogoutOperation, this.internalRtmClient);
        }

        public Task<RtmResult<PublishResult>> Publish(string channelName, byte[] message, int length, PublishOptions option)
        {
            TaskCompletionSource<RtmResult<PublishResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<PublishResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmClient.Publish(channelName, message, length, option, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<PublishResult> result = new RtmResult<PublishResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMPublishOperation, this.internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutPublishResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<PublishResult>> Publish(string channelName, string message, int length, PublishOptions option)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(message);
            return this.Publish(channelName, bytes, bytes.Length, option);
        }

        public RtmStatus RenewToken(string token)
        {
            int errorCode = internalRtmClient.RenewToken(token);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMRenewTokenOperation, this.internalRtmClient);
        }

        public RtmStatus SetParameters(string parameters)
        {
            int errorCode = internalRtmClient.SetParameters(parameters);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetParametersOperation, this.internalRtmClient);
        }

        public Task<RtmResult<SubscribeResult>> Subscribe(string channelName, SubscribeOptions options)
        {
            TaskCompletionSource<RtmResult<SubscribeResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SubscribeResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmClient.Subscribe(channelName, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SubscribeResult> result = new RtmResult<SubscribeResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMSubscribeOperation, this.internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSubscribeResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public RtmStatus Unsubscribe(string channelName)
        {
            int errorCode = internalRtmClient.Unsubscribe(channelName);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMUnsubscribeOperation, this.internalRtmClient);
        }

        public RtmStatus SetLogFile(string filePath)
        {
            int errorCode = internalRtmClient.SetLogFile(filePath);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetLogFileOperation, this.internalRtmClient);
        }

        public RtmStatus SetLogLevel(LOG_LEVEL level)
        {
            int errorCode = internalRtmClient.SetLogLevel(level);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetLogLevelOperation, this.internalRtmClient);
        }

        public RtmStatus SetLogFileSize(uint fileSizeInKBytes)
        {
            int errorCode = internalRtmClient.SetLogFileSize(fileSizeInKBytes);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetLogFileSizeOperation, this.internalRtmClient);
        }
    }
}
