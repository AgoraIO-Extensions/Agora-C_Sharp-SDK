using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    internal class RtmClient : IRtmClient
    {
        public event OnMessageEventHandler OnMessageEvent;
        public event OnPresenceEventHandler OnPresenceEvent;
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
                return new StreamChannel(internalStreamChannel, rtmEventHandler);
            }
        }

        public int Dispose()
        {
            return internalRtmClient.Dispose();
        }

        public IRtmLock GetLock()
        {
            Internal.IRtmLock internalRtmLock = this.internalRtmClient.GetLock();
            return new RtmLock(internalRtmLock, rtmEventHandler);
        }

        public IRtmPresence GetPresence()
        {
            Internal.IRtmPresence internalRtmPresence = this.internalRtmClient.GetPresence();
            return new RtmPresence(internalRtmPresence, rtmEventHandler);
        }

        public IRtmStorage GetStorage()
        {
            Internal.IRtmStorage internalRtmStorage = this.internalRtmClient.GetStorage();
            return new RtmStorage(internalRtmStorage, rtmEventHandler);
        }

        public int Initialize(RtmConfig config)
        {
            Internal.RtmConfig internalConfig = new Internal.RtmConfig(config, rtmEventHandler);
            return internalRtmClient.Initialize(internalConfig);
        }

        public Task<RtmResult<LoginResult>> Login(string token)
        {
            TaskCompletionSource<RtmResult<LoginResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<LoginResult>>();
            int errorCode = internalRtmClient.Login(token);
            if (errorCode != 0)
            {
                RtmResult<LoginResult> result = new RtmResult<LoginResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMLoginOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutLoginResultTask(taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public int Logout()
        {
            return internalRtmClient.Logout();
        }

        public Task<RtmResult<PublishResult>> Publish(string channelName, byte[] message, int length, PublishOptions option)
        {
            TaskCompletionSource<RtmResult<PublishResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<PublishResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmClient.Publish(channelName, message, length, option, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<PublishResult> result = new RtmResult<PublishResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMPublishOperation);
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

        public int RenewToken(string token)
        {
            return internalRtmClient.RenewToken(token);
        }

        public int SetParameters(string parameters)
        {
            return internalRtmClient.SetParameters(parameters);
        }

        public Task<RtmResult<SubscribeResult>> Subscribe(string channelName, SubscribeOptions options)
        {
            TaskCompletionSource<RtmResult<SubscribeResult>> taskCompletionSource = new TaskCompletionSource<RtmResult<SubscribeResult>>();
            UInt64 requestId = 0;
            int errorCode = internalRtmClient.Subscribe(channelName, options, ref requestId);
            if (errorCode != 0)
            {
                RtmResult<SubscribeResult> result = new RtmResult<SubscribeResult>();
                result.Status = Tools.GenerateFailedStatus(errorCode, RtmOperation.RTMSubscribeOperation);
                taskCompletionSource.SetResult(result);
            }
            else
            {
                rtmEventHandler.PutSubscribeResultTask(requestId, taskCompletionSource);
            }
            return taskCompletionSource.Task;
        }

        public int Unsubscribe(string channelName)
        {
            return internalRtmClient.Unsubscribe(channelName);
        }
    }
}
