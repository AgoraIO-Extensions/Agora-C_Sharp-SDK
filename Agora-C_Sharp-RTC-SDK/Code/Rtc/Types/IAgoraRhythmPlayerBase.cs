using System;

namespace Agora.Rtc
{
    #region IAgoraRhythmPlayer.h

    ///
    /// <summary>
    /// Virtual metronome state.
    /// </summary>
    ///
    public enum RHYTHM_PLAYER_STATE_TYPE
    {
        ///
        /// <summary>
        /// (810): The virtual metronome is not enabled or disabled already.
        /// </summary>
        ///
        RHYTHM_PLAYER_STATE_IDLE = 810,

        ///
        /// <summary>
        /// 811: Opening the beat files.
        /// </summary>
        ///
        RHYTHM_PLAYER_STATE_OPENING = 811,

        ///
        /// <summary>
        /// 812: Decoding the beat files.
        /// </summary>
        ///
        RHYTHM_PLAYER_STATE_DECODING = 812,

        ///
        /// <summary>
        /// 813: The beat files are playing.
        /// </summary>
        ///
        RHYTHM_PLAYER_STATE_PLAYING = 813,

        ///
        /// <summary>
        /// 814: Failed to start virtual metronome. You can use the reported errorcode to troubleshoot the cause of the error, or you can try to start the virtual metronome again.
        /// </summary>
        ///
        RHYTHM_PLAYER_STATE_FAILED = 814,
    };

    ///
    /// <summary>
    /// Virtual Metronome error message.
    /// </summary>
    ///
    public enum RHYTHM_PLAYER_ERROR_TYPE
    {
        ///
        /// <summary>
        /// (0): The beat files are played normally without errors.
        /// </summary>
        ///
        RHYTHM_PLAYER_ERROR_OK = 0,

        ///
        /// <summary>
        /// 1: General error; no clear reason.
        /// </summary>
        ///
        RHYTHM_PLAYER_ERROR_FAILED = 1,

        ///
        /// <summary>
        /// 801: There is an error when opening the beat files.
        /// </summary>
        ///
        RHYTHM_PLAYER_ERROR_CAN_NOT_OPEN = 801,

        ///
        /// <summary>
        /// 802: There is an error when playing the beat files.
        /// </summary>
        ///
        RHYTHM_PLAYER_ERROR_CAN_NOT_PLAY = 802,

        ///
        /// <summary>
        /// (803): The duration of the beat file exceeds the limit. The maximum duration is 1.2 seconds.
        /// </summary>
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
        public int beatsPerMeasure;

        ///
        /// <summary>
        /// The beat speed (beats/minute), which ranges from 60 to 360. The default value is 60, which means that the metronome plays 60 beats in one minute.
        /// </summary>
        ///
        public int beatsPerMinute;
    };

    #endregion
}