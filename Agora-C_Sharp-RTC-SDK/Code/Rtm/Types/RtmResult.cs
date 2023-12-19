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
        ///
        /// <summary>
        /// Is the call successful
        /// </summary>
        ///
        public bool Error;

        ///
        /// <summary>
        /// The error code.See RTM_ERROR_CODE
        /// </summary>
        ///
        public int ErrorCode;

        ///
        /// <summary>
        /// The operation of rtm call
        /// </summary>
        ///
        public string Operation;

        ///
        /// <summary>
        /// The reason of error
        /// </summary>
        ///
        public string Reason;
    }

    public class JoinResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;
    };

    public class LeaveResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;
    };

    public class JoinTopicResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;

        ///
        /// <summary>
        /// The name of the topic.
        /// </summary>
        ///
        public string Topic;

        ///
        /// <summary>
        /// The meta of the topic.
        /// </summary>
        ///
        public string Meta;
    };

    public class PublishTopicMessageResult
    {
    }

    public class LeaveTopicResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;

        ///
        /// <summary>
        /// The name of the topic.
        /// </summary>
        ///
        public string Topic;

        ///
        /// <summary>
        /// The meta of the topic.
        /// </summary>
        ///
        public string Meta;
    };

    public class SubscribeTopicResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;

        ///
        /// <summary>
        /// The name of the topic.
        /// </summary>
        ///
        public string Topic;

        ///
        /// <summary>
        /// The subscribed users.
        /// </summary>
        ///
        public string[] SucceedUsers;

        ///
        /// <summary>
        /// The failed to subscribe users.
        /// </summary>
        ///
        public string[] FailedUsers;
    };

    public class UnsubscribeTopicResult
    {
    };

    public class GetSubscribedUserListResult
    {
        ///
        /// <summary>
        /// The subscribed users
        /// </summary>
        ///
        public string[] Users;
    }

    public class ConnectionStateChange
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The new connection state.
        /// </summary>
        ///
        public RTM_CONNECTION_STATE State;

        ///
        /// <summary>
        /// The reason for the connection state change.
        /// </summary>
        ///
        public RTM_CONNECTION_CHANGE_REASON Reason;
    };

    public class TokenPrivilegeWillExpire
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;
    };

    public class SubscribeResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
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
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class UpdateChannelMetadataResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class RemoveChannelMetadataResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;
    };

    public class GetChannelMetadataResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;

        ///
        /// <summary>
        /// The result metadata of getting operation.
        /// </summary>
        ///
        public RtmMetadata Data;
    };

    public class SetUserMetadataResult
    {
        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;
    };

    public class UpdateUserMetadataResult
    {
        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;
    };

    public class RemoveUserMetadataResult
    {
        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;
    };

    public class GetUserMetadataResult
    {
        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;

        ///
        /// <summary>
        /// The result metadata of getting operation.
        /// </summary>
        ///
        public RtmMetadata Data;
    };

    public class SubscribeUserMetadataResult
    {
        ///
        /// <summary>
        /// The id of the user.
        /// </summary>
        ///
        public string UserId;
    };

    public class UnsubscribeUserMetadataResult
    {
    };

    public class SetLockResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;

        ///
        /// <summary>
        /// The name of the lock.
        /// </summary>
        ///
        public string LockName;
    };

    public class RemoveLockResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;

        ///
        /// <summary>
        /// The name of the lock.
        /// </summary>
        ///
        public string LockName;
    };

    public class ReleaseLockResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;

        ///
        /// <summary>
        /// The name of the lock.
        /// </summary>
        ///
        public string LockName;
    };

    public class AcquireLockResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;

        ///
        /// <summary>
        /// The name of the lock.
        /// </summary>
        ///
        public string LockName;

        ///
        /// <summary>
        /// The detail of error.
        /// </summary>
        ///
        public string ErrorDetails;
    };

    public class RevokeLockResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;

        ///
        /// <summary>
        /// The name of the lock.
        /// </summary>
        ///
        public string LockName;
    };

    public class GetLocksResult
    {
        ///
        /// <summary>
        /// The name of the channel.
        /// </summary>
        ///
        public string ChannelName;

        ///
        /// <summary>
        /// The type of the channel.
        /// </summary>
        ///
        public RTM_CHANNEL_TYPE ChannelType;

        ///
        /// <summary>
        /// The details of the locks.
        /// </summary>
        ///
        public LockDetail[] LockDetailList;
    };

    public class WhoNowResult
    {
        ///
        /// <summary>
        /// The states the users.
        /// </summary>
        ///
        public UserState[] UserStateList;

        ///
        /// <summary>
        /// The next page.
        /// </summary>
        ///
        public string NextPage;

        ///
        /// <summary>
        /// count of members in channel
        /// </summary>
        ///
        public int TotalOccupancy;
    };

    public class WhereNowResult
    {
        ///
        /// <summary>
        /// The channel informations.
        /// </summary>
        ///
        public ChannelInfo[] Channels;
    };

    public class GetOnlineUsersResult
    {
        ///
        /// <summary>
        /// The states the users.
        /// </summary>
        ///
        public UserState[] UserStateList;

        ///
        /// <summary>
        /// The next page.
        /// </summary>
        ///
        public string NextPage;

        ///
        /// <summary>
        /// count of members in channel
        /// </summary>
        ///
        public int TotalOccupancy;
    };

    public class GetUserChannelsResult
    {
        ///
        /// <summary>
        /// The channel informations.
        /// </summary>
        ///
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
        ///
        /// <summary>
        /// The states the users.
        /// </summary>
        ///
        public UserState State;
    };

    ///
    /// <summary>
    /// The exception with rtm
    /// </summary>
    ///
    public class RTMException : Exception
    {
        ///
        /// <summary>
        /// Te status of rtm
        /// </summary>
        ///
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
