using System;

namespace Agora.Rtc
{
    public enum PreloadStatusCode {
        /**
        * 0: No error occurs and preload successed.
        */
        PreloadStatusCode_ok = 0,

        /**
         * 1: A general error occurs.
         */
        PreloadStatusCode_err = 1,

        /**
         * 2: The media is preloading.
         */
        PreloadStatusCode_preloading = 2,
    };


    public enum CopyRightMusicStatusCode {
        CopyRightMusicStatusCode_ok = 0,
        CopyRightMusicStatusCode_err = 1,
    };

    public enum AgoraMediaType {
        /**
        * 1: MP3 media.
        */
        AgoraMediaType_audio = 1,

        /**
         * 1: MV media.
         */
        AgoraMediaType_mv = 2,
    };

    public class MusicChartsType {
        public string chartName { get; set; }
        public int id { get; set; }
    }

    public class MusicChartsResult
    {
        public int count { get; set; }

        public MusicChartsType[] type;
    };

    public class MvProperty
    {
        public string resolution { get; set; }
        public string bw { get; set; }
    }

    public class ClimaxSegment
    {
        public int startTime { get; set; }
        public int endTime { get; set; }
    };


    public class Music {
        public Int64 songCode { get; set; }
        public string  name { get; set; }
        public string singer { get; set; }
        public string poster { get; set; }
        public string releaseTime { get; set; }
        public int duration { get; set; }
        public int type { get; set; }

        public int lyricCount { get; set; }
        public int[] lyric;

        public int climaxSegmentCount { get; set; }
        public ClimaxSegment[] climaxSegment;

        public int mvCount { get; set; }
        public MvProperty[] mv;

    }

    public class MusicListResult {
        public int count { get; set; }
        public Music[] music;

        public int total { get; set; }
        public int page { get; set; }

        public int pageSize { get; set; }
     
    }


    public class AgoraMusicContentCenterConfiguration {
        public string appId;
        public string rtmToken;
        public UInt64 uid;

        public AgoraMusicContentCenterConfiguration() {
            appId = "";
            rtmToken = "";
            uid = 0;
        }

        public AgoraMusicContentCenterConfiguration(string appId, string rtmToken, UInt64 uid) {
            this.appId = appId;
            this.rtmToken = rtmToken;
            this.uid = uid;
        }
    }







}
