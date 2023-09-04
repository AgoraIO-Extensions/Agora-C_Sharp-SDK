using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The loading statuses of music assets.
    /// </summary>
    ///
    public enum PreloadStatusCode
    {
        ///
        /// <summary>
        /// 0: The preload of music assets is complete.
        /// </summary>
        ///
        kPreloadStatusCompleted = 0,

        ///
        /// <summary>
        /// 1: The preload of music assets fails.
        /// </summary>
        ///
        kPreloadStatusFailed = 1,

        ///
        /// <summary>
        /// 2: The music assets are preloading.
        /// </summary>
        ///
        kPreloadStatusPreloading = 2,

        kPreloadStatusRemoved = 3,
    };

    ///
    /// @ignore
    ///
    public enum MusicContentCenterStatusCode
    {
        ///
        /// @ignore
        ///
        kMusicContentCenterStatusOk = 0,

        ///
        /// @ignore
        ///
        kMusicContentCenterStatusErr = 1,

        kMusicContentCenterStatusErrGateway = 2,

        kMusicContentCenterStatusErrPermissionAndResource = 3,

        kMusicContentCenterStatusErrInternalDataParse = 4,

        kMusicContentCenterStatusErrMusicLoading = 5,

        kMusicContentCenterStatusErrMusicDecryption = 6,

        kMusicContentCenterStatusErHttpInternalError = 7,
    };

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
    };

    public enum MUSIC_CACHE_STATUS_TYPE
    {
        MUSIC_CACHE_STATUS_TYPE_CACHED = 0,
     
        MUSIC_CACHE_STATUS_TYPE_CACHING = 1
    };

    public class MusicCacheInfo
    {
        public Int64 songCode;
     
        public MUSIC_CACHE_STATUS_TYPE status;

        public MusicCacheInfo()
        {
            songCode = 0;
            status = MUSIC_CACHE_STATUS_TYPE.MUSIC_CACHE_STATUS_TYPE_CACHED;
        }
    };

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
    };

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
    };

    ///
    /// @ignore
    ///
    public class Music
    {
        ///
        /// @ignore
        ///
        public Int64 songCode;

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
    }

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
        public UInt64 mccUid;

        public UInt64 maxCacheSize;

        public string mccDomain;

        public MusicContentCenterConfiguration()
        {
            appId = "";
            token = "";
            mccUid = 0;
            maxCacheSize = 0;
            mccDomain = "";
        }

        public MusicContentCenterConfiguration(string appId, string token, UInt64 uid, UInt64 maxCacheSize, string mccDomain)
        {
            this.appId = appId;
            this.token = token;
            this.mccUid = uid;
            this.maxCacheSize = maxCacheSize;
            this.mccDomain = mccDomain;
        }
    }
}