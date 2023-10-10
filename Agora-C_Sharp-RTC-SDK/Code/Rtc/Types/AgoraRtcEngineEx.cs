namespace Agora.Rtc
{
    #region terra IAgoraRtcEngineEx.h

    public class RtcConnection
    {
        public string channelId;

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