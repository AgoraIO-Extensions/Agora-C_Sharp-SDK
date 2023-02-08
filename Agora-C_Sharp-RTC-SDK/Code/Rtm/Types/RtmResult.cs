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

    public class RtmOperation
    {
        public static string RTMInitializeOperation = "RTMInitializeOperation";
        public static string RTMReleaseOperation = "RTMReleaseOperation";
        public static string RTMLoginOperation = "RTMLoginOperation";
        public static string RTMLogoutOperation = "RTMLogoutOperation";
        public static string RTMGetStorageOperation = "RTMGetStorageOperation";
        public static string RTMGetLockOperation = "RTMGetLockOperation";
        public static string RTMGetPresenceOperation = "RTMGetPresenceOperation";
        public static string RTMRenewTokenOperation = "RTMRenewTokenOperation";
        public static string RTMPublishOperation = "RTMPublishOperation";
        public static string RTMSubscribeOperation = "RTMSubscribeOperation";
        public static string RTMUnsubscribeOperation = "RTMUnsubscribeOperation";
        public static string RTMCreateStreamChannelOperation = "RTMCreateStreamChannelOperation";
        public static string RTMSetParametersOperation = "RTMSetParametersOperation";

        public static string RTMSetLockOperation = "RTMSetLockOperation";
        public static string RTMGetLocksOperation = "RTMGetLocksOperation";
        public static string RTMRemoveLockOperation = "RTMRemoveLockOperation";
        public static string RTMAcquireLockOperation = "RTMAcquireLockOperation";
        public static string RTMReleaseLockOperation = "RTMReleaseLockOperation";
        public static string RTMRevokeLockOperation = "RTMRevokeLockOperation";

        public static string RTMWhoNowOperation = "RTMWhoNowOperation";
        public static string RTMWhereNowOperation = "RTMWhereNowOperation";
        public static string RTMSetStateOperation = "RTMSetStateOperation";
        public static string RTMRemoveStateOperation = "RTMRemoveStateOperation";
        public static string RTMGetStateOperation = "RTMGetStateOperation";

        public static string RTMCreateMetadataOperation = "RTMCreateMetadataOperation";
        public static string RTMSetChannelMetadataOperation = "RTMSetChannelMetadataOperation";
        public static string RTMUpdateChannelMetadataOperation = "RTMUpdateChannelMetadataOperation";
        public static string RTMRemoveChannelMetadataOperation = "RTMRemoveChannelMetadataOperation";
        public static string RTMGetChannelMetadataOperation = "RTMGetChannelMetadataOperation";
        public static string RTMSetUserMetadataOperation = "RTMSetUserMetadataOperation";
        public static string RTMUpdateUserMetadataOperation = "RTMUpdateUserMetadataOperation";
        public static string RTMRemoveUserMetadataOperation = "RTMRemoveUserMetadataOperation";
        public static string RTMGetUserMetadataOperation = "RTMGetUserMetadataOperation";
        public static string RTMSubscribeUserMetadataOperation = "RTMSubscribeUserMetadataOperation";
        public static string RTMUnsubscribeUserMetadataOperation = "RTMUnsubscribeUserMetadataOperation";

        public static string RTMJoinOperation = "RTMJoinOperation";
        public static string RTMLeaveOperation = "RTMLeaveOperation";
        public static string RTMGetChannelNameOperation = "RTMGetChannelNameOperation";
        public static string RTMJoinTopicOperation = "RTMJoinTopicOperation";
        public static string RTMPublishTopicMessageOperation = "RTMPublishTopicMessageOperation";
        public static string RTMLeaveTopicOperation = "RTMLeaveTopicOperation";
        public static string RTMSubscribeTopicOperation = "RTMSubscribeTopicOperation";
        public static string RTMUnsubscribeTopicOperation = "RTMUnsubscribeTopicOperation";
        public static string RTMGetSubscribedUserListOperation = "RTMGetSubscribedUserListOperation";
    }
}
