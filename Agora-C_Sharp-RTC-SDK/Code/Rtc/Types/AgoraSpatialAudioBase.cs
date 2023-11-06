namespace Agora.Rtc
{
    #region terra IAgoraSpatialAudioBase.h
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

    }




    #endregion terra IAgoraSpatialAudioBase.h
}