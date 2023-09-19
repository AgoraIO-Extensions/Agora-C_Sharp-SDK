namespace Agora.Rtc
{
#region terra IAgoraRtcEngineEx.h

    /* class_rtcconnection */
    public class RtcConnection
    {
        /* class_rtcconnection_channelId */
        public string channelId;

        /* class_rtcconnection_localUid */
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