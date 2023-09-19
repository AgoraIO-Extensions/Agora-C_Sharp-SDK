using System;

namespace Agora.Rtc
{
#region terra IAgoraRhythmPlayer.h

    /* enum_rhythmplayerstatetype */
    public enum RHYTHM_PLAYER_STATE_TYPE
    {
        /* enum_rhythmplayerstatetype_RHYTHM_PLAYER_STATE_IDLE */
        RHYTHM_PLAYER_STATE_IDLE = 810,

        /* enum_rhythmplayerstatetype_RHYTHM_PLAYER_STATE_OPENING */
        RHYTHM_PLAYER_STATE_OPENING,

        /* enum_rhythmplayerstatetype_RHYTHM_PLAYER_STATE_DECODING */
        RHYTHM_PLAYER_STATE_DECODING,

        /* enum_rhythmplayerstatetype_RHYTHM_PLAYER_STATE_PLAYING */
        RHYTHM_PLAYER_STATE_PLAYING,

        /* enum_rhythmplayerstatetype_RHYTHM_PLAYER_STATE_FAILED */
        RHYTHM_PLAYER_STATE_FAILED,
    }

    /* enum_rhythmplayererrortype */
    public enum RHYTHM_PLAYER_ERROR_TYPE
    {
        /* enum_rhythmplayererrortype_RHYTHM_PLAYER_ERROR_OK */
        RHYTHM_PLAYER_ERROR_OK = 0,

        /* enum_rhythmplayererrortype_RHYTHM_PLAYER_ERROR_FAILED */
        RHYTHM_PLAYER_ERROR_FAILED = 1,

        /* enum_rhythmplayererrortype_RHYTHM_PLAYER_ERROR_CAN_NOT_OPEN */
        RHYTHM_PLAYER_ERROR_CAN_NOT_OPEN = 801,

        /* enum_rhythmplayererrortype_RHYTHM_PLAYER_ERROR_CAN_NOT_PLAY */
        RHYTHM_PLAYER_ERROR_CAN_NOT_PLAY,

        /* enum_rhythmplayererrortype_RHYTHM_PLAYER_ERROR_FILE_OVER_DURATION_LIMIT */
        RHYTHM_PLAYER_ERROR_FILE_OVER_DURATION_LIMIT,
    }

    /* class_agorarhythmplayerconfig */
    public class AgoraRhythmPlayerConfig
    {
        /* class_agorarhythmplayerconfig_beatsPerMeasure */
        public int beatsPerMeasure;

        /* class_agorarhythmplayerconfig_beatsPerMinute */
        public int beatsPerMinute;

        public AgoraRhythmPlayerConfig()
        {
            this.beatsPerMeasure = 4;
            this.beatsPerMinute = 60;
        }

        public AgoraRhythmPlayerConfig(int beatsPerMeasure, int beatsPerMinute)
        {
            this.beatsPerMeasure = beatsPerMeasure;
            this.beatsPerMinute = beatsPerMinute;
        }
    }

#endregion terra IAgoraRhythmPlayer.h
}