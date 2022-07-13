using System;

namespace Agora.Rtc
{
    #region IAgoraRhythmPlayer.h

    public enum RHYTHM_PLAYER_STATE_TYPE
    {
        RHYTHM_PLAYER_STATE_IDLE = 810,

        RHYTHM_PLAYER_STATE_OPENING = 811,

        RHYTHM_PLAYER_STATE_DECODING = 812,

        RHYTHM_PLAYER_STATE_PLAYING = 813,

        RHYTHM_PLAYER_STATE_FAILED = 814,
    };

    public enum RHYTHM_PLAYER_ERROR_TYPE
    {
        RHYTHM_PLAYER_ERROR_OK = 0,

        RHYTHM_PLAYER_ERROR_FAILED = 1,

        RHYTHM_PLAYER_ERROR_CAN_NOT_OPEN = 801,

        RHYTHM_PLAYER_ERROR_CAN_NOT_PLAY = 802,
        
        RHYTHM_PLAYER_ERROR_FILE_OVER_DURATION_LIMIT = 803,
    };

    public class AgoraRhythmPlayerConfig
    {
        public AgoraRhythmPlayerConfig()
        {
            beatsPerMeasure = 4;
            beatsPerMinute = 60;
        }

        public int beatsPerMeasure { set; get; }

        public int beatsPerMinute { set; get; }
    };

    #endregion
}
