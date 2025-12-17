using System;
using int64_t = System.Int64;
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
        public abstract void OnLyricResult(string requestId, int64_t songCode, string lyricUrl, MusicContentCenterStatusCode errorCode);

        ///
        /// @ignore
        ///
        public abstract void OnSongSimpleInfoResult(string requestId, int64_t songCode, string simpleInfo, MusicContentCenterStatusCode errorCode);

        ///
        /// @ignore
        ///
        public abstract void OnPreLoadEvent(string requestId, Int64 songCode, int percent, string lyricUrl, PreloadStatusCode status, MusicContentCenterStatusCode errorCode);
    }
}