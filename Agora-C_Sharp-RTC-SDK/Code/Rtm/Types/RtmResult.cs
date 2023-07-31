using System;
namespace Agora.Rtm
{
    public class RtmResult<T>
    {
        public RtmStatus Status;
        public T Response;
    }

    public class RtmStatus
    {
        public bool Error;
        public int ErrorCode;
        public string Operation;
        public string Reason;
    }

    public class JoinResult
    {
        public string ChannelName;
        public string UserId;
    };

    public class LeaveResult
    {
        public string ChannelName;
        public string UserId;
    };

    public class JoinTopicResult
    {
        public string ChannelName;
        public string UserId;
        public string Topic;
        public string Meta;
    };

    public class PublishTopicMessageResult
    {

    }

    public class LeaveTopicResult
    {
        public string ChannelName;
        public string UserId;
        public string Topic;
        public string Meta;
    };

    public class SubscribeTopicResult
    {
        public string ChannelName;
        public string UserId;
        public string Topic;
        public string[] SucceedUsers;
        public string[] FailedUsers;
    };

    public class UnsubscribeTopicResult
    {

    };

    public class GetSubscribedUserListResult
    {
        public string[] Users;
    }

    public class ConnectionStateChange
    {
        public string ChannelName;
        public RTM_CONNECTION_STATE State;
        public RTM_CONNECTION_CHANGE_REASON Reason;
    };

    public class TokenPrivilegeWillExpire
    {
        public string ChannelName;
    };

    public class SubscribeResult
    {
        public string ChannelName;
    };

    public class UnsubscribeResult
    {

    };

    public class PublishResult
    {
      
    };

    public class LoginResult
    {
       
    };

    public class LogoutResult
    {

    };

    public class RenewTokenResult
    {

    };

    public class SetChannelMetadataResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class UpdateChannelMetadataResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class RemoveChannelMetadataResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class GetChannelMetadataResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public RtmMetadata Data;
    };

    public class SetUserMetadataResult
    {
        public string UserId;
    };

    public class UpdateUserMetadataResult
    {
        public string UserId;
    };

    public class RemoveUserMetadataResult
    {
        public string UserId;
    };

    public class GetUserMetadataResult
    {
        public string UserId;
        public RtmMetadata Data;
    };

    public class SubscribeUserMetadataResult
    {
        public string UserId;
    };

    public class UnsubscribeUserMetadataResult
    {

    };

    public class SetLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
    };

    public class RemoveLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
    };

    public class ReleaseLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
    };

    public class AcquireLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
        public string ErrorDetails;
    };

    public class RevokeLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
    };

    public class GetLocksResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public LockDetail[] LockDetailList;
    };

    public class WhoNowResult
    {
        public UserState[] UserStateList;
        public UInt64 Count;
        public string NextPage;
    };

    public class WhereNowResult
    {
        public ChannelInfo[] Channels;
        public UInt64 Count;
    };

    public class SetStateResult
    { 
    };

    public class RemoveStateResult
    {
    };

    public class GetStateResult
    {
        public UserState State;
    };

    public class RTMException : Exception
    {
        public RtmStatus Status;

        internal RTMException(RtmStatus rtmStatus)
        {
            this.Status = rtmStatus;
        }

        public override string ToString()
        {
            return Status.Reason;
        }
    }
}
