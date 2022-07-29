namespace Agora.Rtc
{
    #region IAgoraRtcEngineEx

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

        public string channelId { set; get; }
        
        public uint localUid { set; get; }
    };

    #endregion
}
