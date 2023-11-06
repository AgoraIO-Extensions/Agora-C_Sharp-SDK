namespace Agora.Rtc
{
    #region terra IAgoraSpatialAudioS.h
    public class LocalSpatialAudioConfigS
    {
        public IRtcEngineS rtcEngine;

        public LocalSpatialAudioConfigS()
        {
            this.rtcEngine = null;
        }

        public LocalSpatialAudioConfigS(IRtcEngineS rtcEngine)
        {
            this.rtcEngine = rtcEngine;
        }
    }




    #endregion terra IAgoraSpatialAudioS.h
}