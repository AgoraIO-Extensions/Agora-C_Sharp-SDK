namespace Agora.Rtc
{
    #region terra IAgoraRtcEngineExS.h

    public class RtcConnectionS
    {
        public string channelId;

        public string localUserAccount;

        public RtcConnectionS()
        {
            this.channelId = "";
            this.localUserAccount = "";
        }

        public RtcConnectionS(string channel_id, string local_user_account)
        {
            this.channelId = channel_id;
            this.localUserAccount = local_user_account;
        }

    }




    #endregion terra IAgoraRtcEngineExS.h
}