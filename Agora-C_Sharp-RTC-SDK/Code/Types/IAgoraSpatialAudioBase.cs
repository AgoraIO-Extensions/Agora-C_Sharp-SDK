namespace Agora.Rtc
{
    #region IAgoraSpatialAudio.h
    public enum SAE_CONNECTION_STATE_TYPE
    {
        SAE_CONNECTION_STATE_CONNECTING = 0,

        SAE_CONNECTION_STATE_CONNECTED = 1,

        SAE_CONNECTION_STATE_DISCONNECTED = 2,

        SAE_CONNECTION_STATE_RECONNECTING = 3,

        SAE_CONNECTION_STATE_RECONNECTED = 4
    };

    public enum SAE_CONNECTION_CHANGED_REASON_TYPE
    {
        SAE_CONNECTION_CHANGED_DEFAULT = 0,

        SAE_CONNECTION_CHANGED_CONNECTING = 1,

        SAE_CONNECTION_CHANGED_CREATE_ROOM_FAIL = 2,

        SAE_CONNECTION_CHANGED_RTM_DISCONNECT = 3,

        SAE_CONNECTION_CHANGED_RTM_ABORTED = 4,

        SAE_CONNECTION_CHANGED_LOST_SYNC = 5
    };

    ///
    /// <summary>
    /// The audio range mode.
    /// </summary>
    ///
    public enum AUDIO_RANGE_MODE_TYPE
    {
        AUDIO_RANGE_MODE_WORLD = 0,

        AUDIO_RANGE_MODE_TEAM = 1
    };

    public class RemoteVoicePositionInfo
    {
        public RemoteVoicePositionInfo(float[] position, float[] forward)
        {
            this.position = position;
            this.forward = forward;
        }

        public float[] position { set; get; }

        public float[] forward { set; get; }
    };

    public enum SAE_DEPLOY_REGION
    {
        SAE_DEPLOY_REGION_CN = 0x00000001,

        SAE_DEPLOY_REGION_NA = 0x00000002,

        SAE_DEPLOY_REGION_EU = 0x00000004,

        SAE_DEPLOY_REGION_AS = 0x00000008
    };

    public class CloudSpatialAudioConfig
    {
        public CloudSpatialAudioConfig()
        {
            rtcEngine = null;
            eventHandler = null;
            appId = null;
            deployRegion = (int)SAE_DEPLOY_REGION.SAE_DEPLOY_REGION_CN;
        }

        public IRtcEngine rtcEngine { set; get; }

        public ICloudSpatialAudioEventHandler eventHandler { set; get; }

        public string appId { set; get; }

        public uint deployRegion { set; get; }
    }

    public class LocalSpatialAudioConfig
    {
        public IRtcEngine rtcEngine { set; get; }

        public LocalSpatialAudioConfig()
        {
            rtcEngine = null;
        }
    };
    #endregion
}