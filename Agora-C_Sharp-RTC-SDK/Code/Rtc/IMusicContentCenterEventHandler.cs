using System;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMusicContentCenterEventHandler
    {
        ///
        /// @ignore
        ///
        public abstract void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode errorCode);

        ///
        /// @ignore
        ///
        public abstract void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStatusCode errorCode);

        ///
        /// @ignore
        ///
        public abstract void OnLyricResult(string requestId, Int64 songCode, string lyricUrl, MusicContentCenterStatusCode error_code);


        public abstract void OnSongSimpleInfoResult(string requestId, Int64 songCode, string simpleInfo, MusicContentCenterStatusCode errorCode);

        ///
        /// @ignore
        ///
        public abstract void OnPreLoadEvent(string requestId, Int64 songCode, int percent, string lyricUrl, PreloadStatusCode status, MusicContentCenterStatusCode error_code);
    }
}