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
    ///
    /// @ignore
    ///
    public enum MusicPlayMode
    {
        ///
        /// @ignore
        ///
        kMusicPlayModeOriginal = 0,

        ///
        /// @ignore
        ///
        kMusicPlayModeAccompany = 1,

        ///
        /// @ignore
        ///
        kMusicPlayModeLeadSing = 2,
    }

    ///
    /// @ignore
    ///
    public enum PreloadState
    {
        ///
        /// @ignore
        ///
        kPreloadStateCompleted = 0,

        ///
        /// @ignore
        ///
        kPreloadStateFailed = 1,

        ///
        /// @ignore
        ///
        kPreloadStatePreloading = 2,

        ///
        /// @ignore
        ///
        kPreloadStateRemoved = 3,
    }

    ///
    /// @ignore
    ///
    public enum MusicContentCenterStateReason
    {
        ///
        /// @ignore
        ///
        kMusicContentCenterReasonOk = 0,

        ///
        /// @ignore
        ///
        kMusicContentCenterReasonError = 1,

        ///
        /// @ignore
        ///
        kMusicContentCenterReasonGateway = 2,

        ///
        /// @ignore
        ///
        kMusicContentCenterReasonPermissionAndResource = 3,

        ///
        /// @ignore
        ///
        kMusicContentCenterReasonInternalDataParse = 4,

        ///
        /// @ignore
        ///
        kMusicContentCenterReasonMusicLoading = 5,

        ///
        /// @ignore
        ///
        kMusicContentCenterReasonMusicDecryption = 6,

        ///
        /// @ignore
        ///
        kMusicContentCenterReasonHttpInternalError = 7,
    }

    ///
    /// @ignore
    ///
    public class MusicChartInfo
    {
        ///
        /// @ignore
        ///
        public string chartName;

        ///
        /// @ignore
        ///
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

    ///
    /// @ignore
    ///
    public enum MUSIC_CACHE_STATUS_TYPE
    {
        ///
        /// @ignore
        ///
        MUSIC_CACHE_STATUS_TYPE_CACHED = 0,

        ///
        /// @ignore
        ///
        MUSIC_CACHE_STATUS_TYPE_CACHING = 1,
    }

    ///
    /// @ignore
    ///
    public class MusicCacheInfo
    {
        ///
        /// @ignore
        ///
        public long songCode;

        ///
        /// @ignore
        ///
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

    ///
    /// @ignore
    ///
    public class MvProperty
    {
        ///
        /// @ignore
        ///
        public string resolution;

        ///
        /// @ignore
        ///
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

    ///
    /// <summary>
    /// The climax parts of the music.
    /// </summary>
    ///
    public class ClimaxSegment
    {
        ///
        /// <summary>
        /// The time (ms) when the climax part begins.
        /// </summary>
        ///
        public int startTimeMs;

        ///
        /// <summary>
        /// The time (ms) when the climax part ends.
        /// </summary>
        ///
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

    ///
    /// @ignore
    ///
    public class Music
    {
        ///
        /// @ignore
        ///
        public long songCode;

        ///
        /// @ignore
        ///
        public string name;

        ///
        /// @ignore
        ///
        public string singer;

        ///
        /// @ignore
        ///
        public string poster;

        ///
        /// @ignore
        ///
        public string releaseTime;

        ///
        /// @ignore
        ///
        public int durationS;

        ///
        /// @ignore
        ///
        public int type;

        ///
        /// @ignore
        ///
        public int pitchType;

        ///
        /// @ignore
        ///
        public int lyricCount;

        ///
        /// @ignore
        ///
        public int[] lyricList;

        ///
        /// @ignore
        ///
        public int climaxSegmentCount;

        ///
        /// @ignore
        ///
        public ClimaxSegment[] climaxSegmentList;

        ///
        /// @ignore
        ///
        public int mvPropertyCount;

        ///
        /// @ignore
        ///
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

    ///
    /// @ignore
    ///
    public class MusicContentCenterConfiguration
    {
        ///
        /// @ignore
        ///
        public string appId;

        ///
        /// @ignore
        ///
        public string token;

        ///
        /// @ignore
        ///
        public long mccUid;

        ///
        /// @ignore
        ///
        public int maxCacheSize;

        ///
        /// @ignore
        ///
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