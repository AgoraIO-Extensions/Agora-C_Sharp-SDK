using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    public class RtmClient : IRtmClient
    {
        public event OnMessageEventHandler OnMessageEvent;
        public event OnPresenceEventHandler OnPresenceEvent;
        public event OnTopicEventHandler OnTopicEvent;
        public event OnLockEventHandler OnLockEvent;
        public event OnStorageEventHandler OnStorageEvent;
        public event OnConnectionStateChangedHandler OnConnectionStateChanged;
        public event OnTokenPrivilegeWillExpireHandler OnTokenPrivilegeWillExpire;

        private Internal.IRtmClient _internalRtmClient;
        private RtmEventHandler _rtmEventHandler;

        private static IRtmClient _instance = null;

        public static IRtmClient CreateAgoraRtmClient(RtmConfig config)
        {
            RtmClient rtmClient = (RtmClient)(_instance ?? (_instance = new RtmClient()));

            RtmStatus status = rtmClient.Initialize(config);
            if (status.Error)
            {
                throw new RTMException(status);
            }
            else
            {
                return rtmClient;
            }
        }

        public static IRtmClient GetInstance()
        {
            return _instance;
        }

        public RtmClient()
        {
            _internalRtmClient = Internal.RtmClient.CreateAgoraRtmClient();
            _rtmEventHandler = new RtmEventHandler(this);
        }

        public string GetVersion()
        {
            return _internalRtmClient.GetVersion();
        }

        internal RtmEventHandler GetRtmEventHandler()
        {
            return this._rtmEventHandler;
        }

        internal Internal.IRtmClient GetInternalRtmClient()
        {
            return this._internalRtmClient;
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

        internal void InvokeOnConnectionStateChanged(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason)
        {
            if (this.OnConnectionStateChanged != null)
            {
                this.OnConnectionStateChanged.Invoke(channelName, state, reason);
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
            Internal.IStreamChannel internalStreamChannel = this._internalRtmClient.CreateStreamChannel(channelName);
            if (internalStreamChannel == null)
            {
                return null;
            }
            else
            {
                return new StreamChannel(internalStreamChannel, _rtmEventHandler, _internalRtmClient);
            }
        }

        public RtmStatus Dispose()
        {
            int errorCode = _internalRtmClient.Dispose();
            if (errorCode == 0)
            {
                _instance = null;
            }
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMDisposeOperation, this._internalRtmClient);
        }

        public IRtmLock GetLock()
        {
            Internal.IRtmLock internalRtmLock = this._internalRtmClient.GetLock();
            return new RtmLock(internalRtmLock, _rtmEventHandler, _internalRtmClient);
        }

        public IRtmPresence GetPresence()
        {
            Internal.IRtmPresence internalRtmPresence = this._internalRtmClient.GetPresence();
            return new RtmPresence(internalRtmPresence, _rtmEventHandler, _internalRtmClient);
        }

        public IRtmStorage GetStorage()
        {
            Internal.IRtmStorage internalRtmStorage = this._internalRtmClient.GetStorage();
            return new RtmStorage(internalRtmStorage, _rtmEventHandler, _internalRtmClient);
        }

        private RtmStatus Initialize(RtmConfig config)
        {
            Internal.RtmConfig internalConfig = new Internal.RtmConfig(config, _rtmEventHandler);
            int errorCode = _internalRtmClient.Initialize(internalConfig);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMInitializeOperation, this._internalRtmClient);
        }

        public Task<RtmResult<LoginResult>> LoginAsync(string token)
        {
            TaskCompletionSource<RtmResult<LoginResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<LoginResult>>();
            int errorCode = _internalRtmClient.Login(token);
            if (errorCode != 0)
            {
                RtmResult<LoginResult> result = new RtmResult<LoginResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMLoginOperation, this._internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                _rtmEventHandler.PutLoginResultTask(taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<LogoutResult>> LogoutAsync()
        {
            // fake async
            int errorCode = _internalRtmClient.Logout();
            RtmResult<LogoutResult> rtmResult = new RtmResult<LogoutResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMLogoutOperation, this._internalRtmClient);
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
            int errorCode = _internalRtmClient.Publish(channelName, message, message.Length, internalOptione, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<PublishResult> result = new RtmResult<PublishResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMPublishOperation, this._internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                _rtmEventHandler.PutPublishResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<PublishResult>> PublishAsync(string channelName, string message, PublishOptions option)
        {
            TaskCompletionSource<RtmResult<PublishResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<PublishResult>>();
            UInt64 requestId = 0;
            Internal.PublishOptions internalOptione = new Internal.PublishOptions(option, RTM_MESSAGE_TYPE.STRING);
            int errorCode = _internalRtmClient.Publish(channelName, message, message.Length, internalOptione, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<PublishResult> result = new RtmResult<PublishResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMPublishOperation, this._internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                _rtmEventHandler.PutPublishResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<RenewTokenResult>> RenewTokenAsync(string token)
        {
            // fake async
            int errorCode = _internalRtmClient.RenewToken(token);
            RtmResult<RenewTokenResult> rtmResult = new RtmResult<RenewTokenResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMRenewTokenOperation, this._internalRtmClient);
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
            int errorCode = _internalRtmClient.SetParameters(parameters);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetParametersOperation, this._internalRtmClient);
        }

        public Task<RtmResult<SubscribeResult>> SubscribeAsync(string channelName, SubscribeOptions options)
        {
            TaskCompletionSource<RtmResult<SubscribeResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SubscribeResult>>();
            UInt64 requestId = 0;
            int errorCode = _internalRtmClient.Subscribe(channelName, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SubscribeResult> result = new RtmResult<SubscribeResult>();
                result.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMSubscribeOperation, this._internalRtmClient);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                _rtmEventHandler.PutSubscribeResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public Task<RtmResult<UnsubscribeResult>> UnsubscribeAsync(string channelName)
        {
            // fake async
            int errorCode = _internalRtmClient.Unsubscribe(channelName);

            RtmResult<UnsubscribeResult> rtmResult = new RtmResult<UnsubscribeResult>();
            rtmResult.Status = Tools.GenerateStatus(errorCode, RtmOperation.RTMUnsubscribeOperation, this._internalRtmClient);
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
            int errorCode = _internalRtmClient.SetLogFile(filePath);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetLogFileOperation, this._internalRtmClient);
        }

        public RtmStatus SetLogLevel(LOG_LEVEL level)
        {
            int errorCode = _internalRtmClient.SetLogLevel(level);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetLogLevelOperation, this._internalRtmClient);
        }

        public RtmStatus SetLogFileSize(uint fileSizeInKBytes)
        {
            int errorCode = _internalRtmClient.SetLogFileSize(fileSizeInKBytes);
            return Tools.GenerateStatus(errorCode, RtmOperation.RTMSetLogFileSizeOperation, this._internalRtmClient);
        }
    }
}
