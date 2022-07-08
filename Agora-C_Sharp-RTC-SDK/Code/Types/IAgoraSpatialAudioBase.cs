namespace Agora.Rtc
{
    #region IAgoraSpatialAudio.h
    ///
    /// <summary>
    /// SDK 与 Agora 空间音效服务器的连接状态。
    /// </summary>
    ///
    public enum SAE_CONNECTION_STATE_TYPE
    {
        ///
        /// <summary>
        /// 0: 建立连接中。
        /// </summary>
        ///
        SAE_CONNECTION_STATE_CONNECTING = 0,

        ///
        /// <summary>
        /// 1: 已连接。 该状态下， UpdateSelfPosition 等空间音效设置才会生效。
        /// </summary>
        ///
        SAE_CONNECTION_STATE_CONNECTED = 1,

        ///
        /// <summary>
        /// 2: 连接断开。
        /// </summary>
        ///
        SAE_CONNECTION_STATE_DISCONNECTED = 2,

        ///
        /// <summary>
        /// 3: 重新建立连接中。
        /// </summary>
        ///
        SAE_CONNECTION_STATE_RECONNECTING = 3,

        ///
        /// <summary>
        /// 4: 已重新建立连接。
        /// </summary>
        ///
        SAE_CONNECTION_STATE_RECONNECTED = 4
    };

    ///
    /// <summary>
    /// SDK 与 Agora 空间音效服务器连接状态发生改变的原因。
    /// </summary>
    ///
    public enum SAE_CONNECTION_CHANGED_REASON_TYPE
    {
        ///
        /// <summary>
        /// 0: 正常。
        /// </summary>
        ///
        SAE_CONNECTION_CHANGED_DEFAULT = 0,

        ///
        /// <summary>
        /// 1: SDK 建立连接中。
        /// </summary>
        ///
        SAE_CONNECTION_CHANGED_CONNECTING = 1,

        ///
        /// <summary>
        /// 2: SDK 创建房间失败。
        /// </summary>
        ///
        SAE_CONNECTION_CHANGED_CREATE_ROOM_FAIL = 2,

        ///
        /// <summary>
        /// 3: SDK 与 RTM 系统连接中断。
        /// </summary>
        ///
        SAE_CONNECTION_CHANGED_RTM_DISCONNECT = 3,

        ///
        /// <summary>
        /// 4: 用户被 RTM 系统踢出。
        /// </summary>
        ///
        SAE_CONNECTION_CHANGED_RTM_ABORTED = 4,

        ///
        /// <summary>
        /// 5: SDK 超过 15 秒未收到 Agora 空间音效服务器的消息。
        /// </summary>
        ///
        SAE_CONNECTION_CHANGED_LOST_SYNC = 5
    };

    ///
    /// <summary>
    /// The audio range mode.
    /// </summary>
    ///
    public enum AUDIO_RANGE_MODE_TYPE
    {
        ///
        /// TODO(doc)
        ///
        AUDIO_RANGE_MODE_WORLD = 0,

        ///
        /// TODO(doc)
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
    /// <summary>
    /// Agora 空间音效服务器的访问区域。
    /// </summary>
    ///
    public enum SAE_DEPLOY_REGION
    {
        ///
        /// <summary>
        /// （默认）中国大陆。
        /// </summary>
        ///
        SAE_DEPLOY_REGION_CN = 0x00000001,

        ///
        /// <summary>
        /// North America.
        /// </summary>
        ///
        SAE_DEPLOY_REGION_NA = 0x00000002,

        ///
        /// <summary>
        /// Europe.
        /// </summary>
        ///
        SAE_DEPLOY_REGION_EU = 0x00000004,

        ///
        /// <summary>
        /// Asia, excluding Mainland China.
        /// </summary>
        ///
        SAE_DEPLOY_REGION_AS = 0x00000008
    };

    ///
    /// <summary>
    /// The configuration of ICloudSpatialAudioEngine.
    /// </summary>
    ///
    public class CloudSpatialAudioConfig
    {
        public CloudSpatialAudioConfig()
        {
            rtcEngine = null;
            eventHandler = null;
            appId = null;
            deployRegion = (int)SAE_DEPLOY_REGION.SAE_DEPLOY_REGION_CN;
        }

        ///
        /// TODO(doc)
        ///
        public IRtcEngine rtcEngine { set; get; }

        ///
        /// TODO(doc)
        ///
        public ICloudSpatialAudioEventHandler eventHandler { set; get; }

        ///
        /// TODO(doc)
        ///
        public string appId { set; get; }

        ///
        /// TODO(doc)
        ///
        public uint deployRegion { set; get; }
    }

    ///
    /// <summary>
    /// The configuration of ILocalSpatialAudioEngine .
    /// </summary>
    ///
    public class LocalSpatialAudioConfig
    {
        ///
        /// TODO(doc)
        ///
        public IRtcEngine rtcEngine { set; get; }

        public LocalSpatialAudioConfig()
        {
            rtcEngine = null;
        }
    };
    #endregion
}