namespace Agora.Rtc
{
    #region IAgoraSpatialAudio.h

///
/// @ignore
///
    public enum SAE_CONNECTION_STATE_TYPE
    {
///
/// @ignore
///
        SAE_CONNECTION_STATE_CONNECTING = 0,

///
/// @ignore
///
        SAE_CONNECTION_STATE_CONNECTED = 1,

///
/// @ignore
///
        SAE_CONNECTION_STATE_DISCONNECTED = 2,

///
/// @ignore
///
        SAE_CONNECTION_STATE_RECONNECTING = 3,

///
/// @ignore
///
        SAE_CONNECTION_STATE_RECONNECTED = 4,
    };

///
/// @ignore
///
    public enum SAE_CONNECTION_CHANGED_REASON_TYPE
    {
///
/// @ignore
///
        SAE_CONNECTION_CHANGED_DEFAULT = 0,

///
/// @ignore
///
        SAE_CONNECTION_CHANGED_CONNECTING = 1,

///
/// @ignore
///
        SAE_CONNECTION_CHANGED_CREATE_ROOM_FAIL = 2,

///
/// @ignore
///
        SAE_CONNECTION_CHANGED_RTM_DISCONNECT = 3,

///
/// @ignore
///
        SAE_CONNECTION_CHANGED_RTM_ABORTED = 4,

///
/// @ignore
///
        SAE_CONNECTION_CHANGED_LOST_SYNC = 5,
    };

  ///
  /// @ignore
  ///
    public enum AUDIO_RANGE_MODE_TYPE
    {
  ///
  /// @ignore
  ///
        AUDIO_RANGE_MODE_WORLD = 0,

  ///
  /// @ignore
  ///
        AUDIO_RANGE_MODE_TEAM = 1
    };

///
/// <summary>
/// The spatial position of the remote user or the media player.
/// </summary>
///
    public class RemoteVoicePositionInfo
    {
  ///
  /// @ignore
  ///
        public RemoteVoicePositionInfo(float[] position, float[] forward)
        {
            this.position = position;
            this.forward = forward;
        }

        public float[] position { set; get; }

        public float[] forward { set; get; }
    };

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
/// The entire sound insulation area is regarded as a cube; this represents the length of the forward side in the unit length of the game engine.
/// </summary>
///
        public float[] position;
        public float[] forward;
        public float[] right;
        public float[] up;
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
/// The sound attenuation coefficient when users within the sound insulation area communicate with external users. The value range is [0,1]. The values are as follows:0: Broadcast mode, where the volume and timbre are not attenuated with distance, and the volume and timbre heard by local users do not change regardless of distance.(0,0.5): Weak attenuation mode, that is, the volume and timbre are only weakly attenuated during the propagation process, and the sound can travel farther than the real environment.0.5: (Default) simulates the attenuation of the volume in the real environment; the effect is equivalent to not setting the audioAttenuation parameter.(0.5,1]: Strong attenuation mode (default value is 1), that is, the volume and timbre attenuate rapidly during propagation.
/// </summary>
///
        public float audioAttenuation;
    };

///
/// @ignore
///
    public enum SAE_DEPLOY_REGION
    {
///
/// @ignore
///
        SAE_DEPLOY_REGION_CN = 0x00000001,

///
/// @ignore
///
        SAE_DEPLOY_REGION_NA = 0x00000002,

///
/// @ignore
///
        SAE_DEPLOY_REGION_EU = 0x00000004,

///
/// @ignore
///
        SAE_DEPLOY_REGION_AS = 0x00000008
    };

///
/// <summary>
/// The configuration of ILocalSpatialAudioEngine .
/// </summary>
///
    public class LocalSpatialAudioConfig
    {
///
/// <summary>
///  IRtcEngine .
/// </summary>
///
        public IRtcEngine rtcEngine { set; get; }

///
/// <summary>
/// Destroys the specified video track.
/// </summary>
///
/// <returns>
/// 0: Success.< 0: Failure.
/// </returns>
///
        public LocalSpatialAudioConfig()
        {
            rtcEngine = null;
        }
    };

    #endregion
}