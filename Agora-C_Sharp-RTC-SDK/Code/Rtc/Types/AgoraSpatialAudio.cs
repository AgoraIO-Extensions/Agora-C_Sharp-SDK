namespace Agora.Rtc
{
    #region terra IAgoraSpatialAudio.h
    public class RemoteVoicePositionInfo
    {
        public float[] position;

        public float[] forward;

        public RemoteVoicePositionInfo(float[] position, float[] forward)
        {
            this.position = position;
            this.forward = forward;
        }
        public RemoteVoicePositionInfo()
        {
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

        public SpatialAudioZone(int zoneSetId, float[] position, float[] forward, float[] right, float[] up, float forwardLength, float rightLength, float upLength, float audioAttenuation)
        {
            this.zoneSetId = zoneSetId;
            this.position = position;
            this.forward = forward;
            this.right = right;
            this.up = up;
            this.forwardLength = forwardLength;
            this.rightLength = rightLength;
            this.upLength = upLength;
            this.audioAttenuation = audioAttenuation;
        }
        public SpatialAudioZone()
        {
        }

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