using System;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public enum PreloadStatusCode
    {
        ///
        /// @ignore
        ///
        kPreloadStatusCompleted = 0,

        ///
        /// @ignore
        ///
        kPreloadStatusFailed = 1,

        ///
        /// @ignore
        ///
        kPreloadStatusPreloading = 2,

        ///
        /// @ignore
        ///
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

        ///
        /// @ignore
        ///
        kMusicContentCenterStatusErrGateway = 2,

        ///
        /// @ignore
        ///
        kMusicContentCenterStatusErrPermissionAndResource = 3,

        ///
        /// @ignore
        ///
        kMusicContentCenterStatusErrInternalDataParse = 4,

        ///
        /// @ignore
        ///
        kMusicContentCenterStatusErrMusicLoading = 5,

        ///
        /// @ignore
        ///
        kMusicContentCenterStatusErrMusicDecryption = 6,
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
        MUSIC_CACHE_STATUS_TYPE_CACHING = 1
    };

    ///
    /// @ignore
    ///
    public class MusicCacheInfo
    {
        ///
        /// @ignore
        ///
        public Int64 songCode;

        ///
        /// @ignore
        ///
        public MUSIC_CACHE_STATUS_TYPE status;

        public MusicCacheInfo()
        {
            songCode = 0;
            status = MUSIC_CACHE_STATUS_TYPE.MUSIC_CACHE_STATUS_TYPE_CACHED;
        }

        public MusicCacheInfo(Int64 songCode, MUSIC_CACHE_STATUS_TYPE status)
        {
            this.songCode = songCode;
            this.status = status;
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


        ///
        /// @ignore
        ///
        public UInt32 maxCacheSize;

        public MusicContentCenterConfiguration()
        {
            appId = "";
            token = "";
            mccUid = 0;
            maxCacheSize = 10;
        }

        public MusicContentCenterConfiguration(string appId, string token, UInt64 uid, UInt32 maxCacheSize)
        {
            this.appId = appId;
            this.token = token;
            this.mccUid = uid;
            this.maxCacheSize = maxCacheSize;
        }
    }
}