using System;

namespace Agora.Rtc
{

    /* class_musiccollection */
    public class MusicCollection
    {
        /* class_musiccollection_count */
        public int count;
        /* class_musiccollection_total */
        public int total;
        /* class_musiccollection_page */
        public int page;
        /* class_musiccollection_pageSize */
        public int pageSize;
        public Music[] music;
    };

#region terra IAgoraMusicContentCenter.h

    /* enum_preloadstatuscode */
    public enum PreloadStatusCode
    {
        /* enum_preloadstatuscode_kPreloadStatusCompleted */
        kPreloadStatusCompleted = 0,

        /* enum_preloadstatuscode_kPreloadStatusFailed */
        kPreloadStatusFailed = 1,

        /* enum_preloadstatuscode_kPreloadStatusPreloading */
        kPreloadStatusPreloading = 2,

        /* enum_preloadstatuscode_kPreloadStatusRemoved */
        kPreloadStatusRemoved = 3,
    }

    /* enum_musiccontentcenterstatuscode */
    public enum MusicContentCenterStatusCode
    {
        /* enum_musiccontentcenterstatuscode_kMusicContentCenterStatusOk */
        kMusicContentCenterStatusOk = 0,

        /* enum_musiccontentcenterstatuscode_kMusicContentCenterStatusErr */
        kMusicContentCenterStatusErr = 1,

        /* enum_musiccontentcenterstatuscode_kMusicContentCenterStatusErrGateway */
        kMusicContentCenterStatusErrGateway = 2,

        /* enum_musiccontentcenterstatuscode_kMusicContentCenterStatusErrPermissionAndResource */
        kMusicContentCenterStatusErrPermissionAndResource = 3,

        /* enum_musiccontentcenterstatuscode_kMusicContentCenterStatusErrInternalDataParse */
        kMusicContentCenterStatusErrInternalDataParse = 4,

        /* enum_musiccontentcenterstatuscode_kMusicContentCenterStatusErrMusicLoading */
        kMusicContentCenterStatusErrMusicLoading = 5,

        /* enum_musiccontentcenterstatuscode_kMusicContentCenterStatusErrMusicDecryption */
        kMusicContentCenterStatusErrMusicDecryption = 6,
    }

    /* class_musicchartinfo */
    public class MusicChartInfo
    {
        /* class_musicchartinfo_chartName */
        public string chartName;

        /* class_musicchartinfo_id */
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

    /* enum_musiccachestatustype */
    public enum MUSIC_CACHE_STATUS_TYPE
    {
        /* enum_musiccachestatustype_MUSIC_CACHE_STATUS_TYPE_CACHED */
        MUSIC_CACHE_STATUS_TYPE_CACHED = 0,

        /* enum_musiccachestatustype_MUSIC_CACHE_STATUS_TYPE_CACHING */
        MUSIC_CACHE_STATUS_TYPE_CACHING = 1,
    }

    /* class_musiccacheinfo */
    public class MusicCacheInfo
    {
        /* class_musiccacheinfo_songCode */
        public long songCode;

        /* class_musiccacheinfo_status */
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

    /* class_mvproperty */
    public class MvProperty
    {
        /* class_mvproperty_resolution */
        public string resolution;

        /* class_mvproperty_bandwidth */
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

    /* class_climaxsegment */
    public class ClimaxSegment
    {
        /* class_climaxsegment_startTimeMs */
        public int startTimeMs;

        /* class_climaxsegment_endTimeMs */
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

    /* class_music */
    public class Music
    {
        /* class_music_songCode */
        public long songCode;

        /* class_music_name */
        public string name;

        /* class_music_singer */
        public string singer;

        /* class_music_poster */
        public string poster;

        /* class_music_releaseTime */
        public string releaseTime;

        /* class_music_durationS */
        public int durationS;

        /* class_music_type */
        public int type;

        /* class_music_pitchType */
        public int pitchType;

        /* class_music_lyricCount */
        public int lyricCount;

        public int[] lyricList;

        /* class_music_climaxSegmentCount */
        public int climaxSegmentCount;

        public ClimaxSegment[] climaxSegmentList;

        /* class_music_mvPropertyCount */
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

    /* class_musiccontentcenterconfiguration */
    public class MusicContentCenterConfiguration
    {
        /* class_musiccontentcenterconfiguration_appId */
        public string appId;

        /* class_musiccontentcenterconfiguration_token */
        public string token;

        /* class_musiccontentcenterconfiguration_mccUid */
        public long mccUid;

        /* class_musiccontentcenterconfiguration_maxCacheSize */
        public int maxCacheSize;

        public MusicContentCenterConfiguration()
        {
            this.appId = "";
            this.token = "";
            this.mccUid = 0;
            this.maxCacheSize = 10;
        }

        public MusicContentCenterConfiguration(string appid, string token, long id, int maxSize = 10)
        {
            this.appId = appid;
            this.token = token;
            this.mccUid = id;
            this.maxCacheSize = maxSize;
        }
    }

#endregion terra IAgoraMusicContentCenter.h
}