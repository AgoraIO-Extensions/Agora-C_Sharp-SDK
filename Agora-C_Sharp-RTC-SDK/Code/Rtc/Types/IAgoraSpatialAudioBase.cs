namespace Agora.Rtc
{
#region terra IAgoraSpatialAudio.h

    /* class_remotevoicepositioninfo */
    public class RemoteVoicePositionInfo
    {
        public float[] position;

        public float[] forward;

        public RemoteVoicePositionInfo()
        {
        }

        public RemoteVoicePositionInfo(float[] position, float[] forward)
        {
            this.position = position;
            this.forward = forward;
        }
    }

    /* class_spatialaudiozone */
    public class SpatialAudioZone
    {
        /* class_spatialaudiozone_zoneSetId */
        public int zoneSetId;

        public float[] position;

        public float[] forward;

        public float[] right;

        public float[] up;

        /* class_spatialaudiozone_forwardLength */
        public float forwardLength;

        /* class_spatialaudiozone_rightLength */
        public float rightLength;

        /* class_spatialaudiozone_upLength */
        public float upLength;

        /* class_spatialaudiozone_audioAttenuation */
        public float audioAttenuation;
    }

    /* class_localspatialaudioconfig */
    public class LocalSpatialAudioConfig
    {
        /* class_localspatialaudioconfig_rtcEngine */
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