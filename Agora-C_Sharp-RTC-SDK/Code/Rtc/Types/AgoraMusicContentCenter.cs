using System;

namespace Agora.Rtc
{

    ///
    /// @ignore
    ///
    public class MusicContentCenterConfiguration
    {
        ///
        /// @ignore
        ///
        public int maxCacheSize;

        public MusicContentCenterConfiguration()
        {
            maxCacheSize = 20;
        }

        public MusicContentCenterConfiguration(int maxCacheSize)
        {
            this.maxCacheSize = maxCacheSize;
        }
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
    }

    ///
    /// @ignore
    ///
    public class IWord
    {
        ///
        /// @ignore
        ///
        public int begin;

        ///
        /// @ignore
        ///
        public int duration;

        ///
        /// @ignore
        ///
        public double refPitch;

        ///
        /// @ignore
        ///
        public string word;

        ///
        /// @ignore
        ///
        public int score;
    }

    ///
    /// @ignore
    ///
    public class ISentence
    {
        ///
        /// @ignore
        ///
        public string content;

        ///
        /// @ignore
        ///
        public int begin;

        ///
        /// @ignore
        ///
        public int duration;

        ///
        /// @ignore
        ///
        public IWord[] word;

        ///
        /// @ignore
        ///
        public int wordCount;

        ///
        /// @ignore
        ///
        public int score;
    }

    ///
    /// @ignore
    ///
    public class ILyricInfo
    {
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
        public int preludeEndPosition;

        ///
        /// @ignore
        ///
        public int duration;

        ///
        /// @ignore
        ///
        public bool hasPitch;

        ///
        /// @ignore
        ///
        public LyricSourceType sourceType;

        ///
        /// @ignore
        ///
        public ISentence[] sentence;

        ///
        /// @ignore
        ///
        public int sentenceCount;
    }

    #region terra IAgoraMusicContentCenter.h
    ///
    /// @ignore
    ///
    public enum MusicContentCenterVendorID
    {
        ///
        /// @ignore
        ///
        kMusicContentCenterVendorDefault = 1,

        ///
        /// @ignore
        ///
        kMusicContentCenterVendor2 = 2,
    }

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
    public enum MusicContentCenterState
    {
        ///
        /// @ignore
        ///
        kMusicContentCenterStatePreloadOk = 0,

        ///
        /// @ignore
        ///
        kMusicContentCenterStatePreloadFailed = 1,

        ///
        /// @ignore
        ///
        kMusicContentCenterStatePreloading = 2,

        ///
        /// @ignore
        ///
        kMusicContentCenterStatePreloadRemoved = 3,

        ///
        /// @ignore
        ///
        kMusicContentCenterStateStartScoreCompleted = 4,

        ///
        /// @ignore
        ///
        kMusicContentCenterStateStartScoreFailed = 5,
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

        ///
        /// @ignore
        ///
        MUSIC_CACHE_STATUS_TYPE_NO_CACHED = 2,

        ///
        /// @ignore
        ///
        MUSIC_CACHE_STATUS_TYPE_NO_RESOURCE = 3,
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
        public MUSIC_CACHE_STATUS_TYPE musicStatus;

        ///
        /// @ignore
        ///
        public MUSIC_CACHE_STATUS_TYPE lyricStatus;

        public MusicCacheInfo(long songCode, MUSIC_CACHE_STATUS_TYPE musicStatus, MUSIC_CACHE_STATUS_TYPE lyricStatus)
        {
            this.songCode = songCode;
            this.musicStatus = musicStatus;
            this.lyricStatus = lyricStatus;
        }
        public MusicCacheInfo()
        {
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
    public enum LyricSourceType
    {
        ///
        /// @ignore
        ///
        kLyricSourceXml = 0,

        ///
        /// @ignore
        ///
        kLyricSourceLrc = 1,

        ///
        /// @ignore
        ///
        kLyricSourceLrcWithPitches = 2,

        ///
        /// @ignore
        ///
        kLyricSourceKrc = 3,
    }

    ///
    /// @ignore
    ///
    public enum ScoreLevel
    {
        ///
        /// @ignore
        ///
        kScoreLevel1 = 1,

        ///
        /// @ignore
        ///
        kScoreLevel2 = 2,

        ///
        /// @ignore
        ///
        kScoreLevel3 = 3,

        ///
        /// @ignore
        ///
        kScoreLevel4 = 4,

        ///
        /// @ignore
        ///
        kScoreLevel5 = 5,
    }

    ///
    /// @ignore
    ///
    public class RawScoreData
    {
        ///
        /// @ignore
        ///
        public int progressInMs;

        ///
        /// @ignore
        ///
        public float speakerPitch;

        ///
        /// @ignore
        ///
        public float pitchScore;

        public RawScoreData(int progressInMs, float speakerPitch, float pitchScore)
        {
            this.progressInMs = progressInMs;
            this.speakerPitch = speakerPitch;
            this.pitchScore = pitchScore;
        }
        public RawScoreData()
        {
        }

    }

    ///
    /// @ignore
    ///
    public class LineScoreData
    {
        ///
        /// @ignore
        ///
        public int progressInMs;

        ///
        /// @ignore
        ///
        public int index;

        ///
        /// @ignore
        ///
        public int totalLines;

        ///
        /// @ignore
        ///
        public float pitchScore;

        ///
        /// @ignore
        ///
        public float cumulativePitchScore;

        ///
        /// @ignore
        ///
        public float energyScore;

        public LineScoreData(int progressInMs, int index, int totalLines, float pitchScore, float cumulativePitchScore, float energyScore)
        {
            this.progressInMs = progressInMs;
            this.index = index;
            this.totalLines = totalLines;
            this.pitchScore = pitchScore;
            this.cumulativePitchScore = cumulativePitchScore;
            this.energyScore = energyScore;
        }
        public LineScoreData()
        {
        }

    }

    ///
    /// @ignore
    ///
    public class CumulativeScoreData
    {
        ///
        /// @ignore
        ///
        public int progressInMs;

        ///
        /// @ignore
        ///
        public float cumulativePitchScore;

        ///
        /// @ignore
        ///
        public float energyScore;

        public CumulativeScoreData(int progressInMs, float cumulativePitchScore, float energyScore)
        {
            this.progressInMs = progressInMs;
            this.cumulativePitchScore = cumulativePitchScore;
            this.energyScore = energyScore;
        }
        public CumulativeScoreData()
        {
        }

    }

    ///
    /// @ignore
    ///
    public enum ChargeMode
    {
        ///
        /// @ignore
        ///
        kChargeModeMonthly = 1,

        ///
        /// @ignore
        ///
        kChargeModeOnce = 2,
    }

    ///
    /// @ignore
    ///
    public class MusicContentCenterVendorDefaultConfiguration
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
        public string userId;

        ///
        /// @ignore
        ///
        public string mccDomain;

        public MusicContentCenterVendorDefaultConfiguration(string appId, string token, string userId, string mccDomain)
        {
            this.appId = appId;
            this.token = token;
            this.userId = userId;
            this.mccDomain = mccDomain;
        }
        public MusicContentCenterVendorDefaultConfiguration()
        {
        }

    }

    ///
    /// @ignore
    ///
    public class MusicContentCenterVendor2Configuration
    {
        ///
        /// @ignore
        ///
        public string appId;

        ///
        /// @ignore
        ///
        public string appKey;

        ///
        /// @ignore
        ///
        public string token;

        ///
        /// @ignore
        ///
        public string userId;

        ///
        /// @ignore
        ///
        public string deviceId;

        ///
        /// @ignore
        ///
        public int urlTokenExpireTime;

        ///
        /// @ignore
        ///
        public int chargeMode;

        public MusicContentCenterVendor2Configuration(string appId, string appKey, string token, string userId, string deviceId, int urlTokenExpireTime, int chargeMode)
        {
            this.appId = appId;
            this.appKey = appKey;
            this.token = token;
            this.userId = userId;
            this.deviceId = deviceId;
            this.urlTokenExpireTime = urlTokenExpireTime;
            this.chargeMode = chargeMode;
        }
        public MusicContentCenterVendor2Configuration()
        {
        }

    }

    #endregion terra IAgoraMusicContentCenter.h
}