using System;
using System.Threading.Tasks;

namespace Agora.Rtm
{
    public class RtmClient : IRtmClient
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
            throw new NotImplementedException();
        }

        public int Dispose()
        {
            return internalRtmClient.Dispose();
        }

        public IRtmLock GetLock()
        {
            throw new NotImplementedException();//todo
        }

        public IRtmPresence GetPresence()
        {
            throw new NotImplementedException();//todo
        }

        public IRtmStorage GetStorage()
        {
            throw new NotImplementedException();//todo
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
            throw new NotImplementedException();
        }

        public Task<RtmResult<PublishResult>> Publish(string channelName, byte[] message, int length, PublishOptions option)
        {
            throw new NotImplementedException();
        }

        public Task<RtmResult<PublishResult>> Publish(string channelName, string message, int length, PublishOptions option)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(message);
            return this.Publish(channelName, bytes, bytes.Length, option);
        }

        public int RenewToken(string token)
        {
            throw new NotImplementedException();
        }

        public int SetParameters(string parameters)
        {
            throw new NotImplementedException();
        }

        public Task<RtmResult<SubscribeResult>> Subscribe(string channelName, SubscribeOptions options, ref ulong requestId)
        {
            throw new NotImplementedException();
        }

        public int Unsubscribe(string channelName)
        {
            throw new NotImplementedException();
        }
    }
}
