using System;

namespace Agora.Rtc
{
    #region IAgoraRhythmPlayer.h

    ///
    /// @ignore
    ///
    public enum RHYTHM_PLAYER_STATE_TYPE
    {
        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_STATE_IDLE = 810,

        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_STATE_OPENING = 811,

        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_STATE_DECODING = 812,

        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_STATE_PLAYING = 813,

        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_STATE_FAILED = 814,
    };

    ///
    /// @ignore
    ///
    public enum RHYTHM_PLAYER_ERROR_TYPE
    {
        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_ERROR_OK = 0,

        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_ERROR_FAILED = 1,

        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_ERROR_CAN_NOT_OPEN = 801,

        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_ERROR_CAN_NOT_PLAY = 802,

        ///
        /// @ignore
        ///
        RHYTHM_PLAYER_ERROR_FILE_OVER_DURATION_LIMIT = 803,
    };

    ///
    /// <summary>
    /// The metronome configuration.
    /// </summary>
    ///
    public class AgoraRhythmPlayerConfig
    {
        public AgoraRhythmPlayerConfig()
        {
            beatsPerMeasure = 4;
            beatsPerMinute = 60;
        }

        ///
        /// <summary>
        /// The number of beats per measure, which ranges from 1 to 9. The default value is 4, which means that each measure contains one downbeat and three upbeats.
        /// </summary>
        ///
        public int beatsPerMeasure { set; get; }

        ///
        /// <summary>
        /// The beat speed (beats/minute), which ranges from 60 to 360. The default value is 60, which means that the metronome plays 60 beats in one minute.
        /// </summary>
        ///
        public int beatsPerMinute { set; get; }
    };

    #endregion
}