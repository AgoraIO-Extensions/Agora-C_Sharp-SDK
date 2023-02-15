using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Agora.Rtm
{
    internal class RtmEventHandler : Internal.IRtmEventHandler
    {

        private RtmClient rtmClient;

        private List<TaskCompletionSource<RtmResult<LoginResult>>> loginResultTaskArray = new List<TaskCompletionSource<RtmResult<LoginResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<JoinResult>>> joinResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<JoinResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<LeaveResult>>> leaveResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<LeaveResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<JoinTopicResult>>> joinTopicResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<JoinTopicResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<LeaveTopicResult>>> leaveTopicResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<LeaveTopicResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<SubscribeTopicResult>>> topicSubscribedTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<SubscribeTopicResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<SubscribeResult>>> subscribeResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<SubscribeResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<PublishResult>>> publishResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<PublishResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<SetChannelMetadataResult>>> setChannelMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<SetChannelMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<UpdateChannelMetadataResult>>> updateChannelMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<UpdateChannelMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<RemoveChannelMetadataResult>>> removeChannelMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<RemoveChannelMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<GetChannelMetadataResult>>> getChannelMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<GetChannelMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<SetUserMetadataResult>>> setUserMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<SetUserMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<UpdateUserMetadataResult>>> updateUserMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<UpdateUserMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<RemoveUserMetadataResult>>> removeUserMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<RemoveUserMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<GetUserMetadataResult>>> getUserMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<GetUserMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<SubscribeUserMetadataResult>>> subscribeUserMetadataResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<SubscribeUserMetadataResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<SetLockResult>>> setLockResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<SetLockResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<RemoveLockResult>>> removeLockResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<RemoveLockResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<ReleaseLockResult>>> releaseLockResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<ReleaseLockResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<AcquireLockResult>>> acquireLockResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<AcquireLockResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<RevokeLockResult>>> revokeLockResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<RevokeLockResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<GetLocksResult>>> getLocksResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<GetLocksResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<WhoNowResult>>> whoNowResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<WhoNowResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<WhereNowResult>>> whereNowResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<WhereNowResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<SetStateResult>>> presenceSetStateResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<SetStateResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<RemoveStateResult>>> presenceRemoveStateResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<RemoveStateResult>>>();
        private Dictionary<UInt64, TaskCompletionSource<RtmResult<GetStateResult>>> presenceGetStateResultTaskMap = new Dictionary<UInt64, TaskCompletionSource<RtmResult<GetStateResult>>>();



        public RtmEventHandler(RtmClient rtmClient)
        {
            this.rtmClient = rtmClient;
        }

        #region addTask
        public void PutJoinResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<JoinResult>> task)
        {
            joinResultTaskMap.Add(requestId, task);
        }

        public void PutLeaveResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<LeaveResult>> task)
        {
            leaveResultTaskMap.Add(requestId, task);
        }

        public void PutJoinTopicResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<JoinTopicResult>> task)
        {
            joinTopicResultTaskMap.Add(requestId, task);
        }

        public void PutLeaveTopicResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<LeaveTopicResult>> task)
        {
            leaveTopicResultTaskMap.Add(requestId, task);
        }

        public void PutSubscribeTopicResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<SubscribeTopicResult>> task)
        {
            topicSubscribedTaskMap.Add(requestId, task);
        }

        public void PutSubscribeResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<SubscribeResult>> task)
        {
            subscribeResultTaskMap.Add(requestId, task);
        }

        public void PutPublishResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<PublishResult>> task)
        {
            publishResultTaskMap.Add(requestId, task);
        }

        public void PutLoginResultTask(TaskCompletionSource<RtmResult<LoginResult>> task)
        {
            loginResultTaskArray.Add(task);
        }

        public void PutSetChannelMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<SetChannelMetadataResult>> task)
        {
            setChannelMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutUpdateChannelMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<UpdateChannelMetadataResult>> task)
        {
            updateChannelMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutRemoveChannelMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<RemoveChannelMetadataResult>> task)
        {
            removeChannelMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutGetChannelMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<GetChannelMetadataResult>> task)
        {
            getChannelMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutSetUserMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<SetUserMetadataResult>> task)
        {
            setUserMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutUpdateUserMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<UpdateUserMetadataResult>> task)
        {
            updateUserMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutRemoveUserMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<RemoveUserMetadataResult>> task)
        {
            removeUserMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutGetUserMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<GetUserMetadataResult>> task)
        {
            getUserMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutSubscribeUserMetadataResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<SubscribeUserMetadataResult>> task)
        {
            subscribeUserMetadataResultTaskMap.Add(requestId, task);
        }

        public void PutSetLockResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<SetLockResult>> task)
        {
            setLockResultTaskMap.Add(requestId, task);
        }

        public void PutRemoveLockResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<RemoveLockResult>> task)
        {
            removeLockResultTaskMap.Add(requestId, task);
        }

        public void PutReleaseLockResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<ReleaseLockResult>> task)
        {
            releaseLockResultTaskMap.Add(requestId, task);
        }

        public void PutAcquireLockResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<AcquireLockResult>> task)
        {
            acquireLockResultTaskMap.Add(requestId, task);
        }

        public void PutRevokeLockResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<RevokeLockResult>> task)
        {
            revokeLockResultTaskMap.Add(requestId, task);
        }

        public void PutGetLocksResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<GetLocksResult>> task)
        {
            getLocksResultTaskMap.Add(requestId, task);
        }

        public void PutWhoNowResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<WhoNowResult>> task)
        {
            whoNowResultTaskMap.Add(requestId, task);
        }

        public void PutWhereNowResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<WhereNowResult>> task)
        {
            whereNowResultTaskMap.Add(requestId, task);
        }

        public void PutPresenceSetStateResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<SetStateResult>> task)
        {
            presenceSetStateResultTaskMap.Add(requestId, task);
        }

        public void PutPresenceRemoveStateResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<RemoveStateResult>> task)
        {
            presenceRemoveStateResultTaskMap.Add(requestId, task);
        }

        public void PutPresenceGetStateResultTask(UInt64 requestId, TaskCompletionSource<RtmResult<GetStateResult>> task)
        {
            presenceGetStateResultTaskMap.Add(requestId, task);
        }
        #endregion


        #region eventHandler
        public override void OnMessageEvent(MessageEvent @event)
        {
            rtmClient.InvokeOnMessageEvent(@event);
        }

        public override void OnPresenceEvent(PresenceEvent @event)
        {
            rtmClient.InvokeOnPresenceEvent(@event);
        }

        public override void OnTopicEvent(TopicEvent @event)
        {
            rtmClient.InvokeOnTopicEvent(@event);
        }

        public override void OnLockEvent(LockEvent @event)
        {
            rtmClient.InvokeOnLockEvent(@event);
        }

        public override void OnStorageEvent(StorageEvent @event)
        {
            rtmClient.InvokeOnStorageEvent(@event);
        }

        public override void OnConnectionStateChange(string channelName, RTM_CONNECTION_STATE state, RTM_CONNECTION_CHANGE_REASON reason)
        {
            rtmClient.InvokeOnConnectionStateChange(channelName, state, reason);
        }

        public override void OnTokenPrivilegeWillExpire(string channelName)
        {
            rtmClient.InvokeOnTokenPrivilegeWillExpire(channelName);
        }

        public override void OnJoinResult(UInt64 requestId, string channelName, string userId, RTM_CHANNEL_ERROR_CODE errorCode)
        {
            if (joinResultTaskMap.ContainsKey(requestId))
            {
                JoinResult joinResult = new JoinResult();
                joinResult.ChannelName = channelName;
                joinResult.UserId = userId;
                joinResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMJoinOperation, rtmClient.GetInternalRtmClient());

                RtmResult<JoinResult> rtmResult = new RtmResult<JoinResult>();
                rtmResult.Status = status;
                rtmResult.Response = joinResult;

                var task = joinResultTaskMap[requestId];
                task.SetResult(rtmResult);

                joinResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnJoinResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnLeaveResult(UInt64 requestId, string channelName, string userId, RTM_CHANNEL_ERROR_CODE errorCode)
        {
            if (leaveResultTaskMap.ContainsKey(requestId))
            {
                LeaveResult leaveResult = new LeaveResult();
                leaveResult.ChannelName = channelName;
                leaveResult.UserId = userId;
                leaveResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMLeaveOperation, rtmClient.GetInternalRtmClient());

                RtmResult<LeaveResult> rtmResult = new RtmResult<LeaveResult>();
                rtmResult.Status = status;
                rtmResult.Response = leaveResult;

                var task = leaveResultTaskMap[requestId];
                task.SetResult(rtmResult);

                leaveResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnLeaveResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnJoinTopicResult(UInt64 requestId, string channelName, string userId, string topic, string meta, RTM_CHANNEL_ERROR_CODE errorCode)
        {
            if (joinTopicResultTaskMap.ContainsKey(requestId))
            {
                JoinTopicResult joinTopicResult = new JoinTopicResult();
                joinTopicResult.ChannelName = channelName;
                joinTopicResult.UserId = userId;
                joinTopicResult.Topic = topic;
                joinTopicResult.Meta = meta;
                joinTopicResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMJoinTopicOperation, rtmClient.GetInternalRtmClient());

                RtmResult<JoinTopicResult> rtmResult = new RtmResult<JoinTopicResult>();
                rtmResult.Status = status;
                rtmResult.Response = joinTopicResult;

                var task = joinTopicResultTaskMap[requestId];
                task.SetResult(rtmResult);

                joinTopicResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnJoinTopicResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnLeaveTopicResult(UInt64 requestId, string channelName, string userId, string topic, string meta, RTM_CHANNEL_ERROR_CODE errorCode)
        {
            if (leaveTopicResultTaskMap.ContainsKey(requestId))
            {
                LeaveTopicResult leaveTopicResult = new LeaveTopicResult();
                leaveTopicResult.ChannelName = channelName;
                leaveTopicResult.UserId = userId;
                leaveTopicResult.Topic = topic;
                leaveTopicResult.Meta = meta;
                leaveTopicResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMLeaveTopicOperation, rtmClient.GetInternalRtmClient());

                RtmResult<LeaveTopicResult> rtmResult = new RtmResult<LeaveTopicResult>();
                rtmResult.Status = status;
                rtmResult.Response = leaveTopicResult;

                var task = leaveTopicResultTaskMap[requestId];
                task.SetResult(rtmResult);

                leaveTopicResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnLeaveTopicResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnSubscribeTopicResult(UInt64 requestId, string channelName, string userId, string topic, UserList succeedUsers, UserList failedUsers, RTM_CHANNEL_ERROR_CODE errorCode)
        {
            if (topicSubscribedTaskMap.ContainsKey(requestId))
            {
                SubscribeTopicResult topicSubscribed = new SubscribeTopicResult();
                topicSubscribed.ChannelName = channelName;
                topicSubscribed.UserId = userId;
                topicSubscribed.Topic = topic;
                topicSubscribed.SucceedUsers = succeedUsers;
                topicSubscribed.FailedUsers = failedUsers;
                topicSubscribed.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMSubscribeTopicOperation, rtmClient.GetInternalRtmClient());

                RtmResult<SubscribeTopicResult> rtmResult = new RtmResult<SubscribeTopicResult>();
                rtmResult.Status = status;
                rtmResult.Response = topicSubscribed;

                var task = topicSubscribedTaskMap[requestId];
                task.SetResult(rtmResult);

                topicSubscribedTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnTopicSubscribed unrecorded requestId: " + requestId);
            }
        }


        public override void OnSubscribeResult(UInt64 requestId, string channelName, RTM_CHANNEL_ERROR_CODE errorCode)
        {
            if (subscribeResultTaskMap.ContainsKey(requestId))
            {
                SubscribeResult subscribeResult = new SubscribeResult();
                subscribeResult.ChannelName = channelName;
                subscribeResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMSubscribeOperation, rtmClient.GetInternalRtmClient());

                RtmResult<SubscribeResult> rtmResult = new RtmResult<SubscribeResult>();
                rtmResult.Status = status;
                rtmResult.Response = subscribeResult;

                var task = subscribeResultTaskMap[requestId];
                task.SetResult(rtmResult);

                subscribeResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnSubscribeResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnPublishResult(UInt64 requestId, RTM_CHANNEL_ERROR_CODE errorCode)
        {
            if (publishResultTaskMap.ContainsKey(requestId))
            {
                PublishResult publishResult = new PublishResult();
                publishResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMPublishOperation, rtmClient.GetInternalRtmClient());

                RtmResult<PublishResult> rtmResult = new RtmResult<PublishResult>();
                rtmResult.Status = status;
                rtmResult.Response = publishResult;

                var task = publishResultTaskMap[requestId];
                task.SetResult(rtmResult);

                publishResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnPublishResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnLoginResult(RTM_LOGIN_ERROR_CODE errorCode)
        {
            if (loginResultTaskArray.Count > 0)
            {
                LoginResult loginResult = new LoginResult();
                loginResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMLoginOperation, rtmClient.GetInternalRtmClient());

                RtmResult<LoginResult> rtmResult = new RtmResult<LoginResult>();
                rtmResult.Status = status;
                rtmResult.Response = loginResult;

                var loginResultTask = loginResultTaskArray[0];
                loginResultTask.SetResult(rtmResult);
                loginResultTaskArray.RemoveAt(0);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnLoginResult unrecorded");
            }
        }

        public override void OnSetChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, OPERATION_ERROR_CODE errorCode)
        {
            if (setChannelMetadataResultTaskMap.ContainsKey(requestId))
            {
                SetChannelMetadataResult setChannelMetadataResult = new SetChannelMetadataResult();
                setChannelMetadataResult.ChannelName = channelName;
                setChannelMetadataResult.ChannelType = channelType;
                setChannelMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMSetChannelMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<SetChannelMetadataResult> rtmResult = new RtmResult<SetChannelMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = setChannelMetadataResult;

                var task = setChannelMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                setChannelMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnSetChannelMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnUpdateChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, OPERATION_ERROR_CODE errorCode)
        {
            if (updateChannelMetadataResultTaskMap.ContainsKey(requestId))
            {
                UpdateChannelMetadataResult updateChannelMetadataResult = new UpdateChannelMetadataResult();
                updateChannelMetadataResult.ChannelName = channelName;
                updateChannelMetadataResult.ChannelType = channelType;
                updateChannelMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMUpdateChannelMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<UpdateChannelMetadataResult> rtmResult = new RtmResult<UpdateChannelMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = updateChannelMetadataResult;

                var task = updateChannelMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                updateChannelMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnUpdateChannelMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnRemoveChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, OPERATION_ERROR_CODE errorCode)
        {
            if (removeChannelMetadataResultTaskMap.ContainsKey(requestId))
            {
                RemoveChannelMetadataResult removeChannelMetadataResult = new RemoveChannelMetadataResult();
                removeChannelMetadataResult.ChannelName = channelName;
                removeChannelMetadataResult.ChannelType = channelType;
                removeChannelMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMRemoveChannelMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<RemoveChannelMetadataResult> rtmResult = new RtmResult<RemoveChannelMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = removeChannelMetadataResult;

                var task = removeChannelMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                removeChannelMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnRemoveChannelMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnGetChannelMetadataResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, RtmMetadata data, OPERATION_ERROR_CODE errorCode)
        {
            if (getChannelMetadataResultTaskMap.ContainsKey(requestId))
            {
                GetChannelMetadataResult getChannelMetadataResult = new GetChannelMetadataResult();
                getChannelMetadataResult.ChannelName = channelName;
                getChannelMetadataResult.ChannelType = channelType;
                getChannelMetadataResult.Data = data;
                getChannelMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMGetChannelMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<GetChannelMetadataResult> rtmResult = new RtmResult<GetChannelMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = getChannelMetadataResult;

                var task = getChannelMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                getChannelMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnGetChannelMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnSetUserMetadataResult(UInt64 requestId, string userId, OPERATION_ERROR_CODE errorCode)
        {
            if (setUserMetadataResultTaskMap.ContainsKey(requestId))
            {
                SetUserMetadataResult setUserMetadataResult = new SetUserMetadataResult();
                setUserMetadataResult.UserId = userId;
                setUserMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMSetUserMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<SetUserMetadataResult> rtmResult = new RtmResult<SetUserMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = setUserMetadataResult;

                var task = setUserMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                setUserMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnSetUserMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnUpdateUserMetadataResult(UInt64 requestId, string userId, OPERATION_ERROR_CODE errorCode)
        {
            if (updateUserMetadataResultTaskMap.ContainsKey(requestId))
            {
                UpdateUserMetadataResult updateUserMetadataResult = new UpdateUserMetadataResult();
                updateUserMetadataResult.UserId = userId;
                updateUserMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMUpdateUserMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<UpdateUserMetadataResult> rtmResult = new RtmResult<UpdateUserMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = updateUserMetadataResult;

                var task = updateUserMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                updateUserMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnUpdateUserMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnRemoveUserMetadataResult(UInt64 requestId, string userId, OPERATION_ERROR_CODE errorCode)
        {
            if (removeUserMetadataResultTaskMap.ContainsKey(requestId))
            {
                RemoveUserMetadataResult removeUserMetadataResult = new RemoveUserMetadataResult();
                removeUserMetadataResult.UserId = userId;
                removeUserMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMRemoveUserMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<RemoveUserMetadataResult> rtmResult = new RtmResult<RemoveUserMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = removeUserMetadataResult;

                var task = removeUserMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                removeUserMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnRemoveUserMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnGetUserMetadataResult(UInt64 requestId, string userId, RtmMetadata data, OPERATION_ERROR_CODE errorCode)
        {
            if (getUserMetadataResultTaskMap.ContainsKey(requestId))
            {
                GetUserMetadataResult getUserMetadataResult = new GetUserMetadataResult();
                getUserMetadataResult.UserId = userId;
                getUserMetadataResult.Data = data;
                getUserMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMGetUserMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<GetUserMetadataResult> rtmResult = new RtmResult<GetUserMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = getUserMetadataResult;

                var task = getUserMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                getUserMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnGetUserMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnSubscribeUserMetadataResult(UInt64 requestId, string userId, OPERATION_ERROR_CODE errorCode)
        {
            if (subscribeUserMetadataResultTaskMap.ContainsKey(requestId))
            {
                SubscribeUserMetadataResult subscribeUserMetadataResult = new SubscribeUserMetadataResult();
                subscribeUserMetadataResult.UserId = userId;
                subscribeUserMetadataResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMSubscribeUserMetadataOperation, rtmClient.GetInternalRtmClient());

                RtmResult<SubscribeUserMetadataResult> rtmResult = new RtmResult<SubscribeUserMetadataResult>();
                rtmResult.Status = status;
                rtmResult.Response = subscribeUserMetadataResult;

                var task = subscribeUserMetadataResultTaskMap[requestId];
                task.SetResult(rtmResult);

                subscribeUserMetadataResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnSubscribeUserMetadataResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnSetLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, OPERATION_ERROR_CODE errorCode)
        {
            if (setLockResultTaskMap.ContainsKey(requestId))
            {
                SetLockResult setLockResult = new SetLockResult();
                setLockResult.ChannelName = channelName;
                setLockResult.ChannelType = channelType;
                setLockResult.LockName = lockName;
                setLockResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMSetLockOperation, rtmClient.GetInternalRtmClient());

                RtmResult<SetLockResult> rtmResult = new RtmResult<SetLockResult>();
                rtmResult.Status = status;
                rtmResult.Response = setLockResult;

                var task = setLockResultTaskMap[requestId];
                task.SetResult(rtmResult);

                setLockResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnSetLockResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnRemoveLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, OPERATION_ERROR_CODE errorCode)
        {
            if (removeLockResultTaskMap.ContainsKey(requestId))
            {
                RemoveLockResult removeLockResult = new RemoveLockResult();
                removeLockResult.ChannelName = channelName;
                removeLockResult.ChannelType = channelType;
                removeLockResult.LockName = lockName;
                removeLockResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMRemoveLockOperation, rtmClient.GetInternalRtmClient());

                RtmResult<RemoveLockResult> rtmResult = new RtmResult<RemoveLockResult>();
                rtmResult.Status = status;
                rtmResult.Response = removeLockResult;

                var task = removeLockResultTaskMap[requestId];
                task.SetResult(rtmResult);

                removeLockResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnRemoveLockResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnReleaseLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, OPERATION_ERROR_CODE errorCode)
        {
            if (releaseLockResultTaskMap.ContainsKey(requestId))
            {
                ReleaseLockResult releaseLockResult = new ReleaseLockResult();
                releaseLockResult.ChannelName = channelName;
                releaseLockResult.ChannelType = channelType;
                releaseLockResult.LockName = lockName;
                releaseLockResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMReleaseLockOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<ReleaseLockResult> rtmResult = new RtmResult<ReleaseLockResult>();
                rtmResult.Status = status;
                rtmResult.Response = releaseLockResult;

                var task = releaseLockResultTaskMap[requestId];
                task.SetResult(rtmResult);

                releaseLockResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnReleaseLockResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnAcquireLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, OPERATION_ERROR_CODE errorCode, string errorDetails)
        {
            if (acquireLockResultTaskMap.ContainsKey(requestId))
            {
                AcquireLockResult acquireLockResult = new AcquireLockResult();
                acquireLockResult.ChannelName = channelName;
                acquireLockResult.ChannelType = channelType;
                acquireLockResult.LockName = lockName;
                acquireLockResult.ErrorCode = errorCode;
                acquireLockResult.ErrorDetails = errorDetails;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMAcquireLockOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<AcquireLockResult> rtmResult = new RtmResult<AcquireLockResult>();
                rtmResult.Status = status;
                rtmResult.Response = acquireLockResult;

                var task = acquireLockResultTaskMap[requestId];
                task.SetResult(rtmResult);

                acquireLockResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnAcquireLockResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnRevokeLockResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, string lockName, OPERATION_ERROR_CODE errorCode)
        {
            if (revokeLockResultTaskMap.ContainsKey(requestId))
            {
                RevokeLockResult revokeLockResult = new RevokeLockResult();
                revokeLockResult.ChannelName = channelName;
                revokeLockResult.ChannelType = channelType;
                revokeLockResult.LockName = lockName;
                revokeLockResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMRevokeLockOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<RevokeLockResult> rtmResult = new RtmResult<RevokeLockResult>();
                rtmResult.Status = status;
                rtmResult.Response = revokeLockResult;

                var task = revokeLockResultTaskMap[requestId];
                task.SetResult(rtmResult);

                revokeLockResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnRevokeLockResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnGetLocksResult(UInt64 requestId, string channelName, RTM_CHANNEL_TYPE channelType, LockDetail[] lockDetailList, UInt64 count, OPERATION_ERROR_CODE errorCode)
        {
            if (getLocksResultTaskMap.ContainsKey(requestId))
            {
                GetLocksResult getLocksResult = new GetLocksResult();
                getLocksResult.ChannelName = channelName;
                getLocksResult.ChannelType = channelType;
                getLocksResult.LockDetailList = lockDetailList;
                getLocksResult.Count = count;
                getLocksResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMGetLocksOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<GetLocksResult> rtmResult = new RtmResult<GetLocksResult>();
                rtmResult.Status = status;
                rtmResult.Response = getLocksResult;

                var task = getLocksResultTaskMap[requestId];
                task.SetResult(rtmResult);

                getLocksResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnGetLocksResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnWhoNowResult(UInt64 requestId, UserState[] userStateList, UInt64 count, string nextPage, OPERATION_ERROR_CODE errorCode)
        {
            if (whoNowResultTaskMap.ContainsKey(requestId))
            {
                WhoNowResult whoNowResult = new WhoNowResult();
                whoNowResult.UserStateList = userStateList;
                whoNowResult.Count = count;
                whoNowResult.NextPage = nextPage;
                whoNowResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMWhoNowOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<WhoNowResult> rtmResult = new RtmResult<WhoNowResult>();
                rtmResult.Status = status;
                rtmResult.Response = whoNowResult;

                var task = whoNowResultTaskMap[requestId];
                task.SetResult(rtmResult);

                whoNowResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("WhoNowResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnWhereNowResult(UInt64 requestId, ChannelInfo[] channels, UInt64 count, OPERATION_ERROR_CODE errorCode)
        {
            if (whereNowResultTaskMap.ContainsKey(requestId))
            {
                WhereNowResult whereNowResult = new WhereNowResult();
                whereNowResult.Channels = channels;
                whereNowResult.Count = count;
                whereNowResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMWhereNowOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<WhereNowResult> rtmResult = new RtmResult<WhereNowResult>();
                rtmResult.Status = status;
                rtmResult.Response = whereNowResult;

                var task = whereNowResultTaskMap[requestId];
                task.SetResult(rtmResult);

                whereNowResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("WhereNowResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnPresenceSetStateResult(UInt64 requestId, OPERATION_ERROR_CODE errorCode)
        {
            if (presenceSetStateResultTaskMap.ContainsKey(requestId))
            {
                SetStateResult presenceSetStateResult = new SetStateResult();
                presenceSetStateResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMSetStateOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<SetStateResult> rtmResult = new RtmResult<SetStateResult>();
                rtmResult.Status = status;
                rtmResult.Response = presenceSetStateResult;

                var task = presenceSetStateResultTaskMap[requestId];
                task.SetResult(rtmResult);

                presenceSetStateResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnPresenceSetStateResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnPresenceRemoveStateResult(UInt64 requestId, OPERATION_ERROR_CODE errorCode)
        {
            if (presenceRemoveStateResultTaskMap.ContainsKey(requestId))
            {
                RemoveStateResult presenceRemoveStateResult = new RemoveStateResult();
                presenceRemoveStateResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMRemoveStateOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<RemoveStateResult> rtmResult = new RtmResult<RemoveStateResult>();
                rtmResult.Status = status;
                rtmResult.Response = presenceRemoveStateResult;

                var task = presenceRemoveStateResultTaskMap[requestId];
                task.SetResult(rtmResult);

                presenceRemoveStateResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnPresenceRemoveStateResult unrecorded requestId: " + requestId);
            }
        }

        public override void OnPresenceGetStateResult(UInt64 requestId, UserState state, OPERATION_ERROR_CODE errorCode)
        {
            if (presenceGetStateResultTaskMap.ContainsKey(requestId))
            {
                GetStateResult presenceGetStateResult = new GetStateResult();
                presenceGetStateResult.State = state;
                presenceGetStateResult.ErrorCode = errorCode;

                RtmStatus status = Tools.GenerateStatus(0, RtmOperation.RTMGetStateOperation, this.rtmClient.GetInternalRtmClient());

                RtmResult<GetStateResult> rtmResult = new RtmResult<GetStateResult>();
                rtmResult.Status = status;
                rtmResult.Response = presenceGetStateResult;

                var task = presenceGetStateResultTaskMap[requestId];
                task.SetResult(rtmResult);

                presenceGetStateResultTaskMap.Remove(requestId);
            }
            else
            {
                Agora.Rtc.AgoraLog.LogWarning("OnPresenceGetStateResult unrecorded requestId: " + requestId);
            }

            #endregion

        }
    }
}
