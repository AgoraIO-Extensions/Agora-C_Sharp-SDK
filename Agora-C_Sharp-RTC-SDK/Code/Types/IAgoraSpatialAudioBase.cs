namespace Agora.Rtc
{
    #region IAgoraSpatialAudio.h
    public enum SAE_CONNECTION_STATE_TYPE
    {
        /* The SDK is connecting to the spatial audio server. */
        SAE_CONNECTION_STATE_CONNECTING = 0,
        /* The SDK is connected to the spatial audio server. */
        SAE_CONNECTION_STATE_CONNECTED,
        /* The SDK is disconnected from the spatial audio server. */
        SAE_CONNECTION_STATE_DISCONNECTED,
        /* The SDK is reconnecting to the spatial audio server. */
        SAE_CONNECTION_STATE_RECONNECTING,
        /* The SDK is reconnected to the spatial audio server. */
        SAE_CONNECTION_STATE_RECONNECTED
    };

    /** reason of connection state change of GME
*/
    public enum SAE_CONNECTION_CHANGED_REASON_TYPE
    {
        /* The connection state is changed. */
        SAE_CONNECTION_CHANGED_DEFAULT = 0,
        /* The SDK is connecting to the game server. */
        SAE_CONNECTION_CHANGED_CONNECTING,
        /* The SDK fails to create the game room. */
        SAE_CONNECTION_CHANGED_CREATE_ROOM_FAIL,
        /* The SDK is disconnected from the Agora RTM system. */
        SAE_CONNECTION_CHANGED_RTM_DISCONNECT,
        /* The SDK is kicked out of the Agora RTM system. */
        SAE_CONNECTION_CHANGED_RTM_ABORTED,
        /* The SDK recieved no message from server after long time */
        SAE_CONNECTION_CHANGED_LOST_SYNC
    };

    /** audio range mode type
 */
    public enum AUDIO_RANGE_MODE_TYPE
    {
        /* In world mode, you can hear players whose mode are also world mode in other teams */
        AUDIO_RANGE_MODE_WORLD = 0,
        /* In team mode, you can hear teammates only */
        AUDIO_RANGE_MODE_TEAM
    };

    // The information of remote voice position
    public class RemoteVoicePositionInfo
    {
        public RemoteVoicePositionInfo(float[] position, float[] forward)
        {
            this.position = position;
            this.forward = forward;
        }
        // The coordnate of remote voice source, (x, y, z)
        public float[] position { set; get; }
        // The forward vector of remote voice, (x, y, z). When it's not set, the vector is forward to listner.
        public float[] forward { set; get; }
    };

    /** IP areas.
*/
    public enum SAE_DEPLOY_REGION
    {
        /**
        * Mainland China.
        */
        SAE_DEPLOY_REGION_CN = 0x00000001,
        /**
        * North America.
        */
        SAE_DEPLOY_REGION_NA = 0x00000002,
        /**
        * Europe.
        */
        SAE_DEPLOY_REGION_EU = 0x00000004,
        /**
        * Asia, excluding Mainland China.
        */
        SAE_DEPLOY_REGION_AS = 0x00000008
    };

    /** The definition of GMEngineContext
*/
    //public class CloudSpatialAudioConfig
    //{
    //    public CloudSpatialAudioConfig()
    //    {
    //        rtcEngine = null;
    //        eventHandler = null;
    //        appId = null;
    //        deployRegion = (int)SAE_DEPLOY_REGION.SAE_DEPLOY_REGION_CN;
    //    }

    //    /*The reference to \ref IRtcEngine, which is the base interface class of the Agora RTC SDK and provides
    //       * the real-time audio and video communication functionality.
    //       */
    //    public IRtcEngine rtcEngine { set; get; }
    //    /** The SDK uses the eventHandler interface class to send callbacks to the app.
    //       */
    //    public ICloudSpatialAudioEventHandler eventHandler { set; get; }
    //    /** The App ID must be the same App ID used for initializing the IRtcEngine object.
    //       */
    //    public string appId { set; get; }
    //    /**
    //       * The region for connection. This advanced feature applies to scenarios that have regional restrictions.
    //       *
    //       * For the regions that Agora supports, see #SAE_DEPLOY_REGION. The area codes support bitwise operation.
    //       *
    //       * After specifying the region, the SDK connects to the Agora servers within that region.
    //       */
    //    public uint deployRegion { set; get; }
    //}

    /** The definition of LocalSpatialAudioConfig
 */
    public class LocalSpatialAudioConfig
    {
        /*The reference to \ref IRtcEngine, which is the base interface class of the Agora RTC SDK and provides
         * the real-time audio and video communication functionality.
         */
        public IRtcEngine rtcEngine { set; get; }

        public LocalSpatialAudioConfig()
        {
            rtcEngine = null;
        }
    };
    #endregion

}
