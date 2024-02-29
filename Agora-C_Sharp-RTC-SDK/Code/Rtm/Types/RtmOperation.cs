using System;
namespace Agora.Rtm
{
    public class RtmOperation
    {
        public static readonly string RTMInitializeOperation = "RTMInitializeOperation";
        public static readonly string RTMReleaseOperation = "RTMReleaseOperation";
        public static readonly string RTMLoginOperation = "RTMLoginOperation";
        public static readonly string RTMLogoutOperation = "RTMLogoutOperation";
        public static readonly string RTMGetStorageOperation = "RTMGetStorageOperation";
        public static readonly string RTMGetLockOperation = "RTMGetLockOperation";
        public static readonly string RTMGetPresenceOperation = "RTMGetPresenceOperation";
        public static readonly string RTMRenewTokenOperation = "RTMRenewTokenOperation";
        public static readonly string RTMPublishOperation = "RTMPublishOperation";
        public static readonly string RTMSubscribeOperation = "RTMSubscribeOperation";
        public static readonly string RTMUnsubscribeOperation = "RTMUnsubscribeOperation";
        public static readonly string RTMCreateStreamChannelOperation = "RTMCreateStreamChannelOperation";
        public static readonly string RTMSetParametersOperation = "RTMSetParametersOperation";
        public static readonly string RTMDisposeOperation = "RTMDisposeOperation";
        public static readonly string RTMSetLogFileOperation = "RTMSetLogFileOperation";
        public static readonly string RTMSetLogLevelOperation = "RTMSetLogLevelOperation";
        public static readonly string RTMSetLogFileSizeOperation = "RTMSetLogFileSizeOperation";

        public static readonly string RTMSetLockOperation = "RTMSetLockOperation";
        public static readonly string RTMGetLocksOperation = "RTMGetLocksOperation";
        public static readonly string RTMRemoveLockOperation = "RTMRemoveLockOperation";
        public static readonly string RTMAcquireLockOperation = "RTMAcquireLockOperation";
        public static readonly string RTMReleaseLockOperation = "RTMReleaseLockOperation";
        public static readonly string RTMRevokeLockOperation = "RTMRevokeLockOperation";

        public static readonly string RTMWhoNowOperation = "RTMWhoNowOperation";
        public static readonly string RTMWhereNowOperation = "RTMWhereNowOperation";
        public static readonly string RTMGetOnlineUsersOperation = "RTMGetOnlineUsersOperation";
        public static readonly string RTMGetUserChannelsOperation = "RTMGetUserChannelsOperation";
        public static readonly string RTMSetStateOperation = "RTMSetStateOperation";
        public static readonly string RTMRemoveStateOperation = "RTMRemoveStateOperation";
        public static readonly string RTMGetStateOperation = "RTMGetStateOperation";

        public static readonly string RTMCreateMetadataOperation = "RTMCreateMetadataOperation";
        public static readonly string RTMSetChannelMetadataOperation = "RTMSetChannelMetadataOperation";
        public static readonly string RTMUpdateChannelMetadataOperation = "RTMUpdateChannelMetadataOperation";
        public static readonly string RTMRemoveChannelMetadataOperation = "RTMRemoveChannelMetadataOperation";
        public static readonly string RTMGetChannelMetadataOperation = "RTMGetChannelMetadataOperation";
        public static readonly string RTMSetUserMetadataOperation = "RTMSetUserMetadataOperation";
        public static readonly string RTMUpdateUserMetadataOperation = "RTMUpdateUserMetadataOperation";
        public static readonly string RTMRemoveUserMetadataOperation = "RTMRemoveUserMetadataOperation";
        public static readonly string RTMGetUserMetadataOperation = "RTMGetUserMetadataOperation";
        public static readonly string RTMSubscribeUserMetadataOperation = "RTMSubscribeUserMetadataOperation";
        public static readonly string RTMUnsubscribeUserMetadataOperation = "RTMUnsubscribeUserMetadataOperation";

        public static readonly string RTMJoinOperation = "RTMJoinOperation";
        public static readonly string RTMLeaveOperation = "RTMLeaveOperation";
        public static readonly string RTMGetChannelNameOperation = "RTMGetChannelNameOperation";
        public static readonly string RTMJoinTopicOperation = "RTMJoinTopicOperation";
        public static readonly string RTMPublishTopicMessageOperation = "RTMPublishTopicMessageOperation";
        public static readonly string RTMLeaveTopicOperation = "RTMLeaveTopicOperation";
        public static readonly string RTMSubscribeTopicOperation = "RTMSubscribeTopicOperation";
        public static readonly string RTMUnsubscribeTopicOperation = "RTMUnsubscribeTopicOperation";
        public static readonly string RTMGetSubscribedUserListOperation = "RTMGetSubscribedUserListOperation";
    }
}
