namespace Agora.Rtc
{
#region terra IAgoraSpatialAudio.h

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

    public class SpatialAudioZone
    {
        public int zoneSetId;

        public float[] position;

        public float[] forward;

        public float[] right;

        public float[] up;

        public float forwardLength;

        public float rightLength;

        public float upLength;

        public float audioAttenuation;
    }

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