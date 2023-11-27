using System;
using int64_t = System.Int64;
namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMusicContentCenterEventHandler
    {

        #region terra IMusicContentCenterEventHandler
        public abstract void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode status);

        public abstract void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStatusCode status);

        public abstract void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStatusCode status);

        public abstract void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStatusCode status);

        public abstract void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadStatusCode preloadStatus, MusicContentCenterStatusCode mccStatus);
        #endregion terra IMusicContentCenterEventHandler
    }
}