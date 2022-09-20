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
        public RemoteVoicePositionInfo(float[] position, float[] forward)
        {
            this.position = position;
            this.forward = forward;
        }
        
        ///
        /// <summary>
        /// The coordinates in the world coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.
        /// </summary>
        ///
        public float[] position { set; get; }

        ///
        /// <summary>
        /// The unit vector of the x axis in the coordinate system. This parameter is an array of length 3, and the three values represent the front, right, and top coordinates in turn.
        /// </summary>
        ///
        public float[] forward { set; get; }
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

        public LocalSpatialAudioConfig()
        {
            rtcEngine = null;
        }
    };

    #endregion
}