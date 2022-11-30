using System;

namespace Agora.Rtc
{
    public enum PreloadStatusCode
    {
        kPreloadStatusCompleted = 0,

        kPreloadStatusFailed = 1,

        kPreloadStatusPreloading = 2,
    };

    public enum MusicContentCenterStatusCode
    {
        kMusicContentCenterStatusOk = 0,

        kMusicContentCenterStatusErr = 1,
    };

    public class MusicChartInfo
    {
        public string chartName;

        public int id;
    };

    public class MvProperty
    {
        public string resolution;

        public string bandWidth;
    };

    public class ClimaxSegment
    {
        public int startTimeMs;

        public int endTimeMs;
    };

    public class Music
    {
        public Int64 songCode;

        public string name;

        public string singer;

        public string poster;

        public string releaseTime;

        public int durationS;

        public int type;

        public int pitchType;
        public int lyricCount;

        public int[] lyricList;

        public int climaxSegmentCount;

        public ClimaxSegment[] climaxSegmentList;

        public int mvPropertyCount;

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

        public string token;

        public UInt64 mccUid;

        public MusicContentCenterConfiguration()
        {
            appId = "";
            token = "";
            mccUid = 0;
        }

        public MusicContentCenterConfiguration(string appId, string token, UInt64 uid)
        {
            this.appId = appId;
            this.token = token;
            this.mccUid = uid;
        }
    }
}