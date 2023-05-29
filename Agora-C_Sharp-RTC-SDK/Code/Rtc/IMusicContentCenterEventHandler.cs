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
        public abstract void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode error_code);

        ///
        /// @ignore
        ///
        public abstract void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStatusCode error_code);

        ///
        /// @ignore
        ///
        public abstract void OnLyricResult(string requestId, string lyricUrl, MusicContentCenterStatusCode error_code);
    
        ///
        /// @ignore
        ///
        public abstract void OnPreLoadEvent(Int64 songCode, int percent,string lyricUrl, PreloadStatusCode status, MusicContentCenterStatusCode error_code);
    }
}