namespace Agora.Rtc
{
    #region terra IAgoraSpatialAudio.h
    ///
    /// <summary>
    /// The spatial position of the remote user or the media player.
    /// </summary>
    ///
    public class RemoteVoicePositionInfo
    {
        ///
        /// <summary>
        /// The coordinates in the world coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn. And the front, right, and top coordinates correspond to the positive directions of Unity's Vector3 axes (z, x, and y, respectively).
        /// </summary>
        ///
        public float[] position;

        ///
        /// <summary>
        /// The unit vector of the x axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn. And the front, right, and top coordinates correspond to the positive directions of Unity's Vector3 axes (z, x, and y, respectively).
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// Sound insulation area settings.
    /// </summary>
    ///
    public class SpatialAudioZone
    {
        ///
        /// <summary>
        /// The ID of the sound insulation area.
        /// </summary>
        ///
        public int zoneSetId;

        ///
        /// <summary>
        /// The spatial center point of the sound insulation area. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.
        /// </summary>
        ///
        public float[] position;

        ///
        /// <summary>
        /// Starting at position, the forward unit vector. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.
        /// </summary>
        ///
        public float[] forward;

        ///
        /// <summary>
        /// Starting at position, the right unit vector. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.
        /// </summary>
        ///
        public float[] right;

        ///
        /// <summary>
        /// Starting at position, the up unit vector. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.
        /// </summary>
        ///
        public float[] up;

        ///
        /// <summary>
        /// The entire sound insulation area is regarded as a cube; this represents the length of the forward side in the unit length of the game engine.
        /// </summary>
        ///
        public float forwardLength;

        ///
        /// <summary>
        /// The entire sound insulation area is regarded as a cube; this represents the length of the right side in the unit length of the game engine.
        /// </summary>
        ///
        public float rightLength;

        ///
        /// <summary>
        /// The entire sound insulation area is regarded as a cube; this represents the length of the up side in the unit length of the game engine.
        /// </summary>
        ///
        public float upLength;

        ///
        /// <summary>
        /// The sound attenuation coefficient when users within the sound insulation area communicate with external users. The value range is [0,1]. The values are as follows:
        ///  0: Broadcast mode, where the volume and timbre are not attenuated with distance, and the volume and timbre heard by local users do not change regardless of distance.
        ///  (0,0.5): Weak attenuation mode, that is, the volume and timbre are only weakly attenuated during the propagation process, and the sound can travel farther than the real environment.
        ///  0.5: (Default) simulates the attenuation of the volume in the real environment; the effect is equivalent to not setting the audioAttenuation parameter.
        ///  (0.5,1]: Strong attenuation mode (default value is 1), that is, the volume and timbre attenuate rapidly during propagation.
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// The configuration of ILocalSpatialAudioEngine.
    /// </summary>
    ///
    public class LocalSpatialAudioConfig
    {
        ///
        /// <summary>
        /// IRtcEngine.
        /// </summary>
        ///
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