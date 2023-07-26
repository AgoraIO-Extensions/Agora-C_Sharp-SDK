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

        public static IRtmClient CreateAgoraRtmClient(RtmConfig config)
        {
            RtmClient rtmClient = (RtmClient)(instance ?? (instance = new RtmClient()));

            RtmStatus status = rtmClient.Initialize(config);
            if (status.Error)
            {
                throw new RTMException(status);
                return null;
            }
            else
            {
                return rtmClient;
            }
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

        public string GetVersion()
        {
            return internalRtmClient.GetVersion();
        }

        internal RtmEventHandler GetRtmEventHandler()
        {
            return this.rtmEventHandler;
        }

        internal Internal.IRtmClient GetInternalRtmClient()
        {
            return this.internalRtmClient;
        }

        internal void InvokeOnMessageEvent(MessageEvent @event)
        {
            if (this.OnMessageEvent != null)
            {
                this.OnMessageEvent.Invoke(@event);
            }
        }

        internal void InvokeOnPresenceEvent(PresenceEvent @event)
        {
            if (this.OnPresenceEvent != null)
            {
                this.OnPresenceEvent.Invoke(@event);
            }
        }

        internal void InvokeOnTopicEvent(TopicEvent @event)
        {
            if (this.OnTopicEvent != null)
            {
                this.OnTopicEvent.Invoke(@event);
            }
        }

        internal void InvokeOnLockEvent(LockEvent @event)
        {
            if (this.OnLockEvent != null)
            {
                this.OnLockEvent.Invoke(@event);
            }
        }

        internal void InvokeOnStorageEvent(StorageEvent @event)
        {
            if (this.OnStorageEvent != null)
            {
                this.OnStorageEvent.Invoke(@event);
            }
        }

        internal void InvokeOnConnectionStateChange(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason)
        {
            if (this.OnConnectionStateChange != null)
            {
                this.OnConnectionStateChange.Invoke(channelName, state, reason);
            }
        }
        internal void InvokeOnTokenPrivilegeWillExpire(string channelName)
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
            if (errorCode == 0)
            {
                instance = null;
            }
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

        private RtmStatus Initialize(RtmConfig config)
        {
            Internal.RtmConfig internalConfig = new Internal.RtmConfig(config, rtmEventHandler);
            int errorCode = internalRtmClient.Initialize(internalConfig);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMInitializeOperation, this.internalRtmClient);
        }

        public Task<RtmResult<LoginResult>> LoginAsync(string token)
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

        public Task<RtmResult<LogoutResult>> LogoutAsync()
        {
            //fake async
            int errorCode = internalRtmClient.Logout();
            RtmResult<LogoutResult> rtmResult = new RtmResult<LogoutResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMLogoutOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new LogoutResult();
            }

            TaskCompletionSource<RtmResult<LogoutResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<LogoutResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<PublishResult>> PublishAsync(string channelName, byte[] message, PublishOptions option)
        {
            TaskCompletionSource<RtmResult<PublishResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<PublishResult>>();
            UInt64 requestId = 0;
            Internal.PublishOptions internalOptione = new Internal.PublishOptions(option, RTM_MESSAGE_TYPE.BINARY);
            int errorCode = internalRtmClient.Publish(channelName, message, message.Length, internalOptione, ref requestId);
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

        public Task<RtmResult<PublishResult>> PublishAsync(string channelName, string message, PublishOptions option)
        {
            TaskCompletionSource<RtmResult<PublishResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<PublishResult>>();
            UInt64 requestId = 0;
            Internal.PublishOptions internalOptione = new Internal.PublishOptions(option, RTM_MESSAGE_TYPE.STRING);
            int errorCode = internalRtmClient.Publish(channelName, message, message.Length, internalOptione, ref requestId);
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

        public Task<RtmResult<RenewTokenResult>> RenewTokenAsync(string token)
        {
            //fake async
            int errorCode = internalRtmClient.RenewToken(token);
            RtmResult<RenewTokenResult> rtmResult = new RtmResult<RenewTokenResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMRenewTokenOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new RenewTokenResult();
            }

            TaskCompletionSource<RtmResult<RenewTokenResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<RenewTokenResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
        }

        public RtmStatus SetParameters(string parameters)
        {
            int errorCode = internalRtmClient.SetParameters(parameters);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetParametersOperation, this.internalRtmClient);
        }

        public Task<RtmResult<SubscribeResult>> SubscribeAsync(string channelName, SubscribeOptions options)
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

        public Task<RtmResult<UnsubscribeResult>> UnsubscribeAsync(string channelName)
        {
            //fake async
            int errorCode = internalRtmClient.Unsubscribe(channelName);

            RtmResult<UnsubscribeResult> rtmResult = new RtmResult<UnsubscribeResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMUnsubscribeOperation, this.internalRtmClient);
            if (errorCode == 0)
            {
                rtmResult.Response = new UnsubscribeResult();
            }

            TaskCompletionSource<RtmResult<UnsubscribeResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<UnsubscribeResult>>();
            taskCompletionSource.SetResult(rtmResult);
            return taskCompletionSource.Task;
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
