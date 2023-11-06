using System;

namespace Agora.Rtc
{

    #region terra AgoraMediaBaseS.h
    public class UserAudioSpectrumInfoS : UserAudioSpectrumInfoBase
    {
        public string userAccount;

        public UserAudioSpectrumInfoS()
        {
            this.userAccount = "";
        }

        public UserAudioSpectrumInfoS(string account, float[] data, int length)
        : base(data, length)
        {
            this.userAccount = account;
        }

        public UserAudioSpectrumInfoS(AudioSpectrumData spectrumData, string userAccount)
        : base(spectrumData)
        {
            this.userAccount = userAccount;
        }
    }




    #endregion terra AgoraMediaBaseS.h
}