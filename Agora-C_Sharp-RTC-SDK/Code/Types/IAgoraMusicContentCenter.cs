using System;

namespace Agora.Rtc
{

    public enum PreloadStatusCode
    {
        /**
         * 0: No error occurs and preload successed.
         */
        kPreloadStatusCompleted = 0,

        /**
         * 1: A general error occurs.
         */
        kPreloadStatusFailed = 1,

        /**
         * 2: The media is preloading.
         */
        kPreloadStatusPreloading = 2,
    };

    public enum MusicContentCenterStatusCode
    {
        kMusicContentCenterStatusOk = 0,
        kMusicContentCenterStatusErr = 1,
    };

    public enum MusicMediaType
    {
        /**
         * 1: Audio media.
         */
        kMusicMediaTypeAudio = 1,

        /**
         * 2: MV media.
         */
        kMusicMediaTypeMv = 2,
    };

    public class MusicChartInfo
    {
        /**
         * Name of the music chart
         */
        public string chartName;
        /**
         * Id of the music chart, use to get music list
         */
        public int id;
    };


    public class MusicChartCollection
    {
        public int count;
        public MusicChartInfo[] musicChartInfo;
    }

    public class MvProperty
    {
        public string resolution;
        public string bandWidth;
    }

    public class ClimaxSegment
    {
        /**
         * the start time of climax segment
         */
        public int startTimeMs;
        /**
         * the end time of climax segment
         */
        public int endTimeMs;
    };

    public class Music
    {
        /**
        * the songCode of music
        */
        public Int64 songCode;
        /**
         * the name of music
         */
        public string name;
        /**
         * the singer of music
         */
        public string singer;
        /**
         * the poster url of music
         */
        public string poster;
        /**
         * the release time of music
         */
        public string releaseTime;
        /**
         * the duration of music, second
         */
        public int durationS;
        /**
         * the type of music
         * 1, mp3 with accompany and original
         * 2, mp3 only with accompany
         * 3, mp3 only with original
         * 4, mp4 with accompany and original
         * 5, mv only
         * 6, new type mp4 with accompany and original
         * detail at document of music media center
         */
        public int type;
        /**
         * the lyric count of music
         */
        public int lyricCount;
        /**
         * the lyric list of music
         * 0, xml
         * 1, lrc
         */
        public int[] lyricList;
        /**
         * the climax segment count of music
         */
        public int climaxSegmentCount;
        /**
         * the climax segment list of music
         */
        public ClimaxSegment[] climaxSegmentList;
        /**
         * the mv property count of music
         * this music has mv resource if this count great than zero.
         */
        public int mvPropertyCount;
        /**
         * the mv property list of music
         */
        public MvProperty[] mvPropertyList;
    }

    public class MusicCollection
    {
        public int count;
        public int total;
        public int page;
        public int pageSize;
        public Music[] music;
    };


    public class MusicContentCenterConfiguration
    {
        public string appId;
        public string rtmToken;
        public UInt64 mccUid;

        public MusicContentCenterConfiguration()
        {
            appId = "";
            rtmToken = "";
            mccUid = 0;
        }

        public MusicContentCenterConfiguration(string appId, string rtmToken, UInt64 uid)
        {
            this.appId = appId;
            this.rtmToken = rtmToken;
            this.mccUid = uid;
        }
    }


}
