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
        //Is the call successful
        public bool Error;

        //The error code.See RTM_ERROR_CODE
        public int ErrorCode;

        //The operation of rtm call 
        public string Operation;

        //The reason of error
        public string Reason;
    }

    public class JoinResult
    {
        //The name of the channel.
        public string ChannelName;

        //The id of the user.
        public string UserId;
    };

    public class LeaveResult
    {
        //The name of the channel.
        public string ChannelName;

        //The id of the user.
        public string UserId;
    };

    public class JoinTopicResult
    {
        //The name of the channel.
        public string ChannelName;

        //The id of the user.
        public string UserId;

        //The name of the topic.
        public string Topic;

        //The meta of the topic.
        public string Meta;
    };

    public class PublishTopicMessageResult
    {

    }

    public class LeaveTopicResult
    {
        //The name of the channel.
        public string ChannelName;

        //The id of the user.
        public string UserId;

        //The name of the topic.
        public string Topic;

        //The meta of the topic.
        public string Meta;
    };

    public class SubscribeTopicResult
    {
        //The name of the channel.
        public string ChannelName;

        //The id of the user.
        public string UserId;

        //The name of the topic.
        public string Topic;

        //The subscribed users.
        public string[] SucceedUsers;

        //The failed to subscribe users.
        public string[] FailedUsers;
    };

    public class UnsubscribeTopicResult
    {

    };

    public class GetSubscribedUserListResult
    {
        //The subscribed users
        public string[] Users;
    }

    public class ConnectionStateChange
    {
        //The name of the channel.
        public string ChannelName;

        //The new connection state.
        public RTM_CONNECTION_STATE State;

        //The reason for the connection state change.
        public RTM_CONNECTION_CHANGE_REASON Reason;
    };

    public class TokenPrivilegeWillExpire
    {
        //The name of the channel.
        public string ChannelName;
    };

    public class SubscribeResult
    {
        //The name of the channel.
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
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class UpdateChannelMetadataResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class RemoveChannelMetadataResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class GetChannelMetadataResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;

        //The result metadata of getting operation.
        public RtmMetadata Data;
    };

    public class SetUserMetadataResult
    {
        //The id of the user.
        public string UserId;
    };

    public class UpdateUserMetadataResult
    {
        //The id of the user.
        public string UserId;
    };

    public class RemoveUserMetadataResult
    {
        //The id of the user.
        public string UserId;
    };

    public class GetUserMetadataResult
    {
        //The id of the user.
        public string UserId;

        //The result metadata of getting operation.
        public RtmMetadata Data;
    };

    public class SubscribeUserMetadataResult
    {
        //The id of the user.
        public string UserId;
    };

    public class UnsubscribeUserMetadataResult
    {

    };

    public class SetLockResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;

        //The name of the lock.
        public string LockName;
    };

    public class RemoveLockResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;

        //The name of the lock.
        public string LockName;
    };

    public class ReleaseLockResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;

        //The name of the lock.
        public string LockName;
    };

    public class AcquireLockResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;

        //The name of the lock.
        public string LockName;

        //The detail of error.
        public string ErrorDetails;
    };

    public class RevokeLockResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;

        //The name of the lock.
        public string LockName;
    };

    public class GetLocksResult
    {
        //The name of the channel.
        public string ChannelName;

        //The type of the channel.
        public RTM_CHANNEL_TYPE ChannelType;

        //The details of the locks.
        public LockDetail[] LockDetailList;
    };

    public class WhoNowResult
    {
        //The states the users.
        public UserState[] UserStateList;

        //The next page.
        public string NextPage;
    };

    public class WhereNowResult
    {
        //The channel informations.
        public ChannelInfo[] Channels;
    };

    public class SetStateResult
    { 
    };

    public class RemoveStateResult
    {
    };

    public class GetStateResult
    {
        //The states the users.
        public UserState State;
    };

    
    //The exception with rtm
    public class RTMException : Exception
    {
        //Te status of rtm
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
