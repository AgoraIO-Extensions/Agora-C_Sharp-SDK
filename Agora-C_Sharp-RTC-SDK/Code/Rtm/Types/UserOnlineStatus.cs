namespace Agora.Rtm
{
    /// <summary>User identity and active RTM login state returned by Presence.</summary>
    public class UserOnlineStatus
    {
        public string userId;
        public bool online;
    }

    public class GetUserOnlineStatusResult
    {
        /// <summary>Null when the operation fails; inspect RtmResult.Status first.</summary>
        public UserOnlineStatus Status;
    }
}
