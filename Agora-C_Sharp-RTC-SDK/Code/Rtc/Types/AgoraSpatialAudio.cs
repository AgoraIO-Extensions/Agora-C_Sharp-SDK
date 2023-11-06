namespace Agora.Rtc
{
    #region terra IAgoraSpatialAudio.h
    public class LocalSpatialAudioConfig
    {
        public IRtcEngine rtcEngine;

        public LocalSpatialAudioConfig()
        {
            this.rtcEngine = null;
        }

        public LocalSpatialAudioConfig(IRtcEngine rtcEngine)
        {
            this.rtcEngine = rtcEngine;
        }
    }




    #endregion terra IAgoraSpatialAudio.h
}