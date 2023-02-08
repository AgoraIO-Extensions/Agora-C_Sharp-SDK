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
        public RTM_CHANNEL_ERROR_CODE ErrorCode;
    };

    public class LeaveResult
    {
        public string ChannelName;
        public string UserId;
        public RTM_CHANNEL_ERROR_CODE ErrorCode;
    };

    public class JoinTopicResult
    {
        public string ChannelName;
        public string UserId;
        public string Topic;
        public string Meta;
        public RTM_CHANNEL_ERROR_CODE ErrorCode;
    };

    public class LeaveTopicResult
    {
        public string ChannelName;
        public string UserId;
        public string Topic;
        public string Meta;
        public RTM_CHANNEL_ERROR_CODE ErrorCode;
    };

    public class SubscribeTopicResult
    {
        public string ChannelName;
        public string UserId;
        public string Topic;
        public UserList SucceedUsers;
        public UserList FailedUsers;
        public RTM_CHANNEL_ERROR_CODE ErrorCode;
    };

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
        public RTM_CHANNEL_ERROR_CODE ErrorCode;
    };

    public class PublishResult
    {
        public RTM_CHANNEL_ERROR_CODE ErrorCode;
    };

    public class LoginResult
    {
        public RTM_LOGIN_ERROR_CODE ErrorCode;
    };

    public class SetChannelMetadataResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class UpdateChannelMetadataResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class RemoveChannelMetadataResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class GetChannelMetadataResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public RtmMetadata Data;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class SetUserMetadataResult
    {
        public string UserId;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class UpdateUserMetadataResult
    {
        public string UserId;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class RemoveUserMetadataResult
    {
        public string UserId;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class GetUserMetadataResult
    {
        public string UserId;
        public RtmMetadata Data;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class SubscribeUserMetadataResult
    {
        public string UserId;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class SetLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class RemoveLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class ReleaseLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class AcquireLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
        public OPERATION_ERROR_CODE ErrorCode;
        public string ErrorDetails;
    };

    public class RevokeLockResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public string LockName;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class GetLocksResult
    {
        public string ChannelName;
        public RTM_CHANNEL_TYPE ChannelType;
        public LockDetail[] LockDetailList;
        public UInt64 Count;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class WhoNowResult
    {
        public UserState[] UserStateList;
        public UInt64 Count;
        public string NextPage;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class WhereNowResult
    {
        public ChannelInfo[] Channels;
        public UInt64 Count;
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class SetStateResult
    {
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class RemoveStateResult
    {
        public OPERATION_ERROR_CODE ErrorCode;
    };

    public class GetStateResult
    {
        public UserState State;
        public OPERATION_ERROR_CODE ErrorCode;
    };
}
