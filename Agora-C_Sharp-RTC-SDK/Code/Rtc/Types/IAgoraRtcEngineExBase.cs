namespace Agora.Rtc
{
    #region IAgoraRtcEngineEx

    ///
    /// <summary>
    /// Contains connection information.
    /// </summary>
    ///
    public class RtcConnection
    {
        public RtcConnection()
        {

        }

        public RtcConnection(string channelId, uint localUid)
        {
            this.channelId = channelId;
            this.localUid = localUid;
        }

        ///
        /// <summary>
        /// The channel name.
        /// </summary>
        ///
        public string channelId { set; get; }
        
        ///
        /// <summary>
        /// The ID of the local user.
        /// </summary>
        ///
        public uint localUid { set; get; }
    };

    #endregion
}