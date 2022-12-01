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
        public abstract void OnMusicChartsResult(string requestId, MusicContentCenterStatusCode status, MusicChartInfo[] result);

        ///
        /// @ignore
        ///
        public abstract void OnMusicCollectionResult(string requestId, MusicContentCenterStatusCode status, MusicCollection result);

        ///
        /// @ignore
        ///
        public abstract void OnLyricResult(string requestId, string lyricUrl);
    
        ///
        /// @ignore
        ///
        public abstract void OnPreLoadEvent(Int64 songCode, int percent, PreloadStatusCode status, string msg, string lyricUrl);
    }
}