using System;

namespace Agora.Rtc
{

    ///
    /// @ignore
    ///
    public class MusicCollection
    {
        ///
        /// @ignore
        ///
        public int count;
        ///
        /// @ignore
        ///
        public int total;
        ///
        /// @ignore
        ///
        public int page;
        ///
        /// @ignore
        ///
        public int pageSize;
        ///
        /// @ignore
        ///
        public Music[] music;
    };

    #region terra IAgoraMusicContentCenter.h
    public enum PreloadStatusCode
    {
        kPreloadStatusCompleted = 0,

        kPreloadStatusFailed = 1,

        kPreloadStatusPreloading = 2,

        kPreloadStatusRemoved = 3,
    }

    public enum MusicContentCenterStatusCode
    {
        kMusicContentCenterStatusOk = 0,

        kMusicContentCenterStatusError = 1,

        kMusicContentCenterStatusGateway = 2,

        kMusicContentCenterStatusPermissionAndResource = 3,

        kMusicContentCenterStatusInternalDataParse = 4,

        kMusicContentCenterStatusMusicLoading = 5,

        kMusicContentCenterStatusMusicDecryption = 6,

        kMusicContentCenterStatusHttpInternalError = 7,
    }

    public class MusicChartInfo
    {
        public string chartName;

        public int id;

        public MusicChartInfo(string chartName, int id)
        {
            this.chartName = chartName;
            this.id = id;
        }
        public MusicChartInfo()
        {
        }

    }

    public enum MUSIC_CACHE_STATUS_TYPE
    {
        MUSIC_CACHE_STATUS_TYPE_CACHED = 0,

        MUSIC_CACHE_STATUS_TYPE_CACHING = 1,
    }

    public class MusicCacheInfo
    {
        public long songCode;

        public MUSIC_CACHE_STATUS_TYPE status;

        public MusicCacheInfo()
        {
            this.songCode = 0;
            this.status = MUSIC_CACHE_STATUS_TYPE.MUSIC_CACHE_STATUS_TYPE_CACHED;
        }

        public MusicCacheInfo(long songCode, MUSIC_CACHE_STATUS_TYPE status)
        {
            this.songCode = songCode;
            this.status = status;
        }
    }

    public class MvProperty
    {
        public string resolution;

        public string bandwidth;

        public MvProperty(string resolution, string bandwidth)
        {
            this.resolution = resolution;
            this.bandwidth = bandwidth;
        }
        public MvProperty()
        {
        }

    }

    public class ClimaxSegment
    {
        public int startTimeMs;

        public int endTimeMs;

        public ClimaxSegment(int startTimeMs, int endTimeMs)
        {
            this.startTimeMs = startTimeMs;
            this.endTimeMs = endTimeMs;
        }
        public ClimaxSegment()
        {
        }

    }

    public class Music
    {
        public long songCode;

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

        public Music(long songCode, string name, string singer, string poster, string releaseTime, int durationS, int type, int pitchType, int lyricCount, int[] lyricList, int climaxSegmentCount, ClimaxSegment[] climaxSegmentList, int mvPropertyCount, MvProperty[] mvPropertyList)
        {
            this.songCode = songCode;
            this.name = name;
            this.singer = singer;
            this.poster = poster;
            this.releaseTime = releaseTime;
            this.durationS = durationS;
            this.type = type;
            this.pitchType = pitchType;
            this.lyricCount = lyricCount;
            this.lyricList = lyricList;
            this.climaxSegmentCount = climaxSegmentCount;
            this.climaxSegmentList = climaxSegmentList;
            this.mvPropertyCount = mvPropertyCount;
            this.mvPropertyList = mvPropertyList;
        }
        public Music()
        {
        }

    }

    public class MusicContentCenterConfiguration
    {
        public string appId;

        public string token;

        public long mccUid;

        public int maxCacheSize;

        public string mccDomain;

        public MusicContentCenterConfiguration()
        {
            this.appId = "";
            this.token = "";
            this.mccUid = 0;
            this.maxCacheSize = 10;
            this.mccDomain = "";
        }

        public MusicContentCenterConfiguration(string appid, string token, long id, int maxSize = 10, string apiurl = "")
        {
            this.appId = appid;
            this.token = token;
            this.mccUid = id;
            this.maxCacheSize = maxSize;
            this.mccDomain = apiurl;
        }

    }


    #endregion terra IAgoraMusicContentCenter.h
}