using System;

namespace Agora.Rtc
{

    #region terra AgoraMediaBase.h
    public class UserAudioSpectrumInfo : UserAudioSpectrumInfoBase
    {
        public uint uid;

        public UserAudioSpectrumInfo()
        {
            this.uid = 0;
        }

        public UserAudioSpectrumInfo(uint uid, float[] data, int length)
        : base(data, length)
        {
            this.uid = uid;
        }

        public UserAudioSpectrumInfo(AudioSpectrumData spectrumData, uint uid)
        : base(spectrumData)
        {
            this.uid = uid;
        }
    }




    #endregion terra AgoraMediaBase.h
}