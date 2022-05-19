using System;

namespace agora.rtc
{
    
    using int64_t = Int64;
    using view_t = UInt64;
    using uint64_t = UInt64;

  
  




//    #region IAgoraSpatialAudio.h
//    public enum SAE_CONNECTION_STATE_TYPE
//    {
//        /* The SDK is connecting to the spatial audio server. */
//        SAE_CONNECTION_STATE_CONNECTING = 0,
//        /* The SDK is connected to the spatial audio server. */
//        SAE_CONNECTION_STATE_CONNECTED,
//        /* The SDK is disconnected from the spatial audio server. */
//        SAE_CONNECTION_STATE_DISCONNECTED,
//        /* The SDK is reconnecting to the spatial audio server. */
//        SAE_CONNECTION_STATE_RECONNECTING,
//        /* The SDK is reconnected to the spatial audio server. */
//        SAE_CONNECTION_STATE_RECONNECTED
//    };

//    /** reason of connection state change of GME
//*/
//    public enum SAE_CONNECTION_CHANGED_REASON_TYPE
//    {
//        /* The connection state is changed. */
//        SAE_CONNECTION_CHANGED_DEFAULT = 0,
//        /* The SDK is connecting to the game server. */
//        SAE_CONNECTION_CHANGED_CONNECTING,
//        /* The SDK fails to create the game room. */
//        SAE_CONNECTION_CHANGED_CREATE_ROOM_FAIL,
//        /* The SDK is disconnected from the Agora RTM system. */
//        SAE_CONNECTION_CHANGED_RTM_DISCONNECT,
//        /* The SDK is kicked out of the Agora RTM system. */
//        SAE_CONNECTION_CHANGED_RTM_ABORTED,
//        /* The SDK recieved no message from server after long time */
//        SAE_CONNECTION_CHANGED_LOST_SYNC
//    };

//    /** audio range mode type
// */
//    public enum AUDIO_RANGE_MODE_TYPE
//    {
//        /* In world mode, you can hear players whose mode are also world mode in other teams */
//        AUDIO_RANGE_MODE_WORLD = 0,
//        /* In team mode, you can hear teammates only */
//        AUDIO_RANGE_MODE_TEAM
//    };

//    // The information of remote voice position
//    public class RemoteVoicePositionInfo
//    {
//        public RemoteVoicePositionInfo(float[] position, float[] forward)
//        {
//            this.position = position;
//            this.forward = forward;
//        }
//        // The coordnate of remote voice source, (x, y, z)
//        public float[] position { set; get; }
//        // The forward vector of remote voice, (x, y, z). When it's not set, the vector is forward to listner.
//        public float[] forward { set; get; }
//    };

//    /** IP areas.
//*/
//    public enum SAE_DEPLOY_REGION
//    {
//        /**
//        * Mainland China.
//        */
//        SAE_DEPLOY_REGION_CN = 0x00000001,
//        /**
//        * North America.
//        */
//        SAE_DEPLOY_REGION_NA = 0x00000002,
//        /**
//        * Europe.
//        */
//        SAE_DEPLOY_REGION_EU = 0x00000004,
//        /**
//        * Asia, excluding Mainland China.
//        */
//        SAE_DEPLOY_REGION_AS = 0x00000008
//    };

//    /** The definition of GMEngineContext
//*/
//    public class CloudSpatialAudioConfig
//    {
//        public CloudSpatialAudioConfig()
//        {
//            rtcEngine = null;
//            eventHandler = null;
//            appId = null;
//            deployRegion = (int)SAE_DEPLOY_REGION.SAE_DEPLOY_REGION_CN;
//        }

//        /*The reference to \ref IRtcEngine, which is the base interface class of the Agora RTC SDK and provides
//           * the real-time audio and video communication functionality.
//           */
//        public IAgoraRtcEngine rtcEngine { set; get; }
//        /** The SDK uses the eventHandler interface class to send callbacks to the app.
//           */
//        public IAgoraRtcCloudSpatialAudioEngineEventHandler eventHandler { set; get; }
//        /** The App ID must be the same App ID used for initializing the IRtcEngine object.
//           */
//        public string appId { set; get; }
//        /**
//           * The region for connection. This advanced feature applies to scenarios that have regional restrictions.
//           *
//           * For the regions that Agora supports, see #SAE_DEPLOY_REGION. The area codes support bitwise operation.
//           *
//           * After specifying the region, the SDK connects to the Agora servers within that region.
//           */
//        public uint deployRegion { set; get; }
//    }

//    /** The definition of LocalSpatialAudioConfig
// */
//    public class LocalSpatialAudioConfig
//    {
//        /*The reference to \ref IRtcEngine, which is the base interface class of the Agora RTC SDK and provides
//         * the real-time audio and video communication functionality.
//         */
//        public IAgoraRtcEngine rtcEngine { set; get; }

//        public LocalSpatialAudioConfig()
//        {
//            rtcEngine = null;
//        }
//    };
//    #endregion

   

//    #region IAgoraRhythmPlayer.h

//    /**
//   The states of the rhythm player.
//   */
//    public enum RHYTHM_PLAYER_STATE_TYPE
//    {
//        /** 810: The rhythm player is idle. */
//        RHYTHM_PLAYER_STATE_IDLE = 810,
//        /** 811: The rhythm player is opening files. */
//        RHYTHM_PLAYER_STATE_OPENING,
//        /** 812: Files opened successfully, the rhythm player starts decoding files. */
//        RHYTHM_PLAYER_STATE_DECODING,
//        /** 813: Files decoded successfully, the rhythm player starts mixing the two files and playing back them locally. */
//        RHYTHM_PLAYER_STATE_PLAYING,
//        /** 814: The rhythm player is starting to fail, and you need to check the error code for detailed failure reasons. */
//        RHYTHM_PLAYER_STATE_FAILED,
//    };


//    /**
//    The error codes of the rhythm player.
//    */
//    public enum RHYTHM_PLAYER_ERROR_TYPE
//    {
//        /** 0: The rhythm player works well. */
//        RHYTHM_PLAYER_ERROR_OK = 0,
//        /** 1: The rhythm player occurs a internal error. */
//        RHYTHM_PLAYER_ERROR_FAILED = 1,
//        /** 801: The rhythm player can not open the file. */
//        RHYTHM_PLAYER_ERROR_CAN_NOT_OPEN = 801,
//        /** 802: The rhythm player can not play the file. */
//        RHYTHM_PLAYER_ERROR_CAN_NOT_PLAY,
//        /** 803: The file duration over the limit. The file duration limit is 1.2 seconds */
//        RHYTHM_PLAYER_ERROR_FILE_OVER_DURATION_LIMIT,
//    };

//    /**
//    * The configuration of rhythm player,
//    * which is set in startRhythmPlayer or configRhythmPlayer.
//*/
//    public class AgoraRhythmPlayerConfig
//    {
//        public AgoraRhythmPlayerConfig()
//        {
//            beatsPerMeasure = 4;
//            beatsPerMinute = 60;
//        }

//        /**
//        * The number of beats per measure. The range is 1 to 9.
//        * The default value is 4,
//        * which means that each measure contains one downbeat and three upbeats.
//        */
//        public int beatsPerMeasure { set; get; }
//        /*
//        * The range is 60 to 360.
//        * The default value is 60,
//        * which means that the rhythm player plays 60 beats in one minute.
//        */
//        public int beatsPerMinute { set; get; }
//    };

//    #endregion
};
