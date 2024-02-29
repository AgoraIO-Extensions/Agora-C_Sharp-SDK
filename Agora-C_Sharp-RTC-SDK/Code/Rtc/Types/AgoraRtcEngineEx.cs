namespace Agora.Rtc
{
    #region terra IAgoraRtcEngineEx.h
    ///
    /// <summary>
    /// Contains connection information.
    /// </summary>
    ///
    public class RtcConnection
    {
        ///
        /// <summary>
        /// The channel name.
        /// </summary>
        ///
        public string channelId;

        ///
        /// <summary>
        /// The ID of the local user.
        /// </summary>
        ///
        public uint localUid;

        public RtcConnection()
        {
            this.channelId = "";
            this.localUid = 0;
        }

        public RtcConnection(string channel_id, uint local_uid)
        {
            this.channelId = channel_id;
            this.localUid = local_uid;
        }

    }

    #endregion terra IAgoraRtcEngineEx.h
}