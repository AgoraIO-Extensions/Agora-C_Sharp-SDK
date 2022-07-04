using System;

namespace Agora.Rtc
{
    #region IAgoraRhythmPlayer.h

    /**
   The states of the rhythm player.
   */
    public enum RHYTHM_PLAYER_STATE_TYPE
    {
        /** 810: The rhythm player is idle. */
        RHYTHM_PLAYER_STATE_IDLE = 810,
        /** 811: The rhythm player is opening files. */
        RHYTHM_PLAYER_STATE_OPENING,
        /** 812: Files opened successfully, the rhythm player starts decoding files. */
        RHYTHM_PLAYER_STATE_DECODING,
        /** 813: Files decoded successfully, the rhythm player starts mixing the two files and playing back them locally. */
        RHYTHM_PLAYER_STATE_PLAYING,
        /** 814: The rhythm player is starting to fail, and you need to check the error code for detailed failure reasons. */
        RHYTHM_PLAYER_STATE_FAILED,
    };


    /**
    The error codes of the rhythm player.
    */
    public enum RHYTHM_PLAYER_ERROR_TYPE
    {
        /** 0: The rhythm player works well. */
        RHYTHM_PLAYER_ERROR_OK = 0,
        /** 1: The rhythm player occurs a internal error. */
        RHYTHM_PLAYER_ERROR_FAILED = 1,
        /** 801: The rhythm player can not open the file. */
        RHYTHM_PLAYER_ERROR_CAN_NOT_OPEN = 801,
        /** 802: The rhythm player can not play the file. */
        RHYTHM_PLAYER_ERROR_CAN_NOT_PLAY,
        /** 803: The file duration over the limit. The file duration limit is 1.2 seconds */
        RHYTHM_PLAYER_ERROR_FILE_OVER_DURATION_LIMIT,
    };

    /**
    * The configuration of rhythm player,
    * which is set in startRhythmPlayer or configRhythmPlayer.
*/
    public class AgoraRhythmPlayerConfig
    {
        public AgoraRhythmPlayerConfig()
        {
            beatsPerMeasure = 4;
            beatsPerMinute = 60;
        }

        /**
        * The number of beats per measure. The range is 1 to 9.
        * The default value is 4,
        * which means that each measure contains one downbeat and three upbeats.
        */
        public int beatsPerMeasure { set; get; }
        /*
        * The range is 60 to 360.
        * The default value is 60,
        * which means that the rhythm player plays 60 beats in one minute.
        */
        public int beatsPerMinute { set; get; }
    };

    #endregion
}
