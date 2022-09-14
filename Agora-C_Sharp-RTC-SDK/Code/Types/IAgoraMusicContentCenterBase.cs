using System;

namespace Agora.Rtc
{
    public enum PreloadStatusCode
    {
        ///
        /// <summary>
        /// 0: No error occurs and preload successed.
        /// </summary>
        ///
        kPreloadStatusCompleted = 0,

        ///
        /// <summary>
        /// 1: A general error occurs.
        /// </summary>
        ///
        kPreloadStatusFailed = 1,

        ///
        /// <summary>
        /// 2: The media is preloading.
        /// </summary>
        ///
        kPreloadStatusPreloading = 2,
    };

    public enum MusicContentCenterStatusCode
    {
        ///
        /// <summary>
        /// 0: No error occurs and request succeeds.
        /// </summary>
        ///
        kMusicContentCenterStatusOk = 0,

        ///
        /// <summary>
        /// 1: A general error occurs.
        /// </summary>
        ///
        kMusicContentCenterStatusErr = 1,
    };

    public class MusicChartInfo
    {
        ///
        /// <summary>
        /// Name of the music chart
        /// </summary>
        ///
        public string chartName;

        ///
        /// <summary>
        /// Id of the music chart, which is used to get music list
        /// </summary>
        ///
        public int id;
    };

    public class MvProperty
    {
        ///
        /// <summary>
        /// The resolution of the mv
        /// </summary>
        ///
        public string resolution;

        ///
        /// <summary>
        /// The bandwidth of the mv
        /// </summary>
        ///
        public string bandWidth;
    };

    public class ClimaxSegment
    {
        ///
        /// <summary>
        /// The start time of climax segment
        /// </summary>
        ///
        public int startTimeMs;

        ///
        /// <summary>
        /// The end time of climax segment
        /// </summary>
        ///
        public int endTimeMs;
    };

    public class Music
    {
        ///
        /// <summary>
        /// The songCode of music
        /// </summary>
        ///
        public Int64 songCode;

        ///
        /// <summary>
        /// The name of music
        /// </summary>
        ///
        public string name;

        ///
        /// <summary>
        /// The singer of music
        /// </summary>
        ///
        public string singer;

        ///
        /// <summary>
        /// The poster url of music
        /// </summary>
        ///
        public string poster;

        ///
        /// <summary>
        /// The release time of music
        /// </summary>
        ///
        public string releaseTime;

        ///
        /// <summary>
        /// The duration (in seconds) of music
        /// </summary>
        ///
        public int durationS;

        ///
        /// <summary>
        /// The type of music
        /// 1, mp3 with accompany and original
        /// 2, mp3 only with accompany
        /// 3, mp3 only with original
        /// 4, mp4 with accompany and original
        /// 5, mv only
        /// 6, new type mp4 with accompany and original
        /// detail at document of music media center
        /// <summary>
        ///
        public int type;

        ///
        /// <summary>
        /// The lyric count of music
        /// <summary>
        ///
        public int lyricCount;

        ///
        /// <summary>
        /// The lyric list of music
        /// 0, xml
        /// 1, lrc
        /// <summary>
        ///
        public int[] lyricList;

        ///
        /// <summary>
        /// The climax segment count of music
        /// <summary>
        ///
        public int climaxSegmentCount;

        ///
        /// <summary>
        /// The climax segment list of music
        /// <summary>
        ///
        public ClimaxSegment[] climaxSegmentList;

        ///
        /// <summary>
        /// The mv property count of music
        /// this music has mv resource if this count great than zero.
        /// <summary>
        ///
        public int mvPropertyCount;

        ///
        /// <summary>
        /// The mv property list of music
        /// <summary>
        ///
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
        ///
        /// <summary>
        /// The app ID of the project that has enabled the music content center
        /// <summary>
        ///
        public string appId;

        ///
        /// <summary>
        /// music content center need rtmToken to connect with server
        /// <summary>
        ///
        public string rtmToken;

        ///
        /// <summary>
        /// The user ID when using music content center. It can be different from that of the rtc product.
        /// <summary>
        ///
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