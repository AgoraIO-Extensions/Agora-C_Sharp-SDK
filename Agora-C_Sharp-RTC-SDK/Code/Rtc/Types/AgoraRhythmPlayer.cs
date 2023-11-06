﻿using System;

namespace Agora.Rtc
{
    #region terra IAgoraRhythmPlayer.h
    public enum RHYTHM_PLAYER_STATE_TYPE
    {
        RHYTHM_PLAYER_STATE_IDLE = 810,

        RHYTHM_PLAYER_STATE_OPENING,

        RHYTHM_PLAYER_STATE_DECODING,

        RHYTHM_PLAYER_STATE_PLAYING,

        RHYTHM_PLAYER_STATE_FAILED,
    }


    public enum RHYTHM_PLAYER_ERROR_TYPE
    {
        RHYTHM_PLAYER_ERROR_OK = 0,

        RHYTHM_PLAYER_ERROR_FAILED = 1,

        RHYTHM_PLAYER_ERROR_CAN_NOT_OPEN = 801,

        RHYTHM_PLAYER_ERROR_CAN_NOT_PLAY,

        RHYTHM_PLAYER_ERROR_FILE_OVER_DURATION_LIMIT,
    }


    public class AgoraRhythmPlayerConfig
    {
        public int beatsPerMeasure;

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