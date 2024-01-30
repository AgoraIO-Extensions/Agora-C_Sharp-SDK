using System;

namespace Agora.Rtc
{
    #region terra IAgoraRhythmPlayer.h
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
        RHYTHM_PLAYER_STATE_OPENING,

        ///
        /// <summary>
        /// 812: Decoding the beat files.
        /// </summary>
        ///
        RHYTHM_PLAYER_STATE_DECODING,

        ///
        /// <summary>
        /// 813: The beat files are playing.
        /// </summary>
        ///
        RHYTHM_PLAYER_STATE_PLAYING,

        ///
        /// <summary>
        /// 814: Failed to start virtual metronome. You can use the reported errorCode to troubleshoot the cause of the error, or you can try to start the virtual metronome again.
        /// </summary>
        ///
        RHYTHM_PLAYER_STATE_FAILED,
    }

    ///
    /// <summary>
    /// Virtual Metronome error message.
    /// </summary>
    ///
    public enum RHYTHM_PLAYER_REASON
    {
        ///
        /// <summary>
        /// (0): The beat files are played normally without errors.
        /// </summary>
        ///
        RHYTHM_PLAYER_REASON_OK = 0,

        ///
        /// <summary>
        /// 1: A general error; no specific reason.
        /// </summary>
        ///
        RHYTHM_PLAYER_REASON_FAILED = 1,

        ///
        /// <summary>
        /// 801: There is an error when opening the beat files.
        /// </summary>
        ///
        RHYTHM_PLAYER_REASON_CAN_NOT_OPEN = 801,

        ///
        /// <summary>
        /// 802: There is an error when playing the beat files.
        /// </summary>
        ///
        RHYTHM_PLAYER_REASON_CAN_NOT_PLAY,

        ///
        /// <summary>
        /// (803): The duration of the beat file exceeds the limit. The maximum duration is 1.2 seconds.
        /// </summary>
        ///
        RHYTHM_PLAYER_REASON_FILE_OVER_DURATION_LIMIT,
    }

    ///
    /// <summary>
    /// The metronome configuration.
    /// </summary>
    ///
    public class AgoraRhythmPlayerConfig
    {
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