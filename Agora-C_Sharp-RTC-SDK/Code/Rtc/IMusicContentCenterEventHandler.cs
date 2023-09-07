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

        public abstract void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode errorCode);

        public abstract void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStatusCode errorCode);

        public abstract void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStatusCode errorCode);

        public abstract void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStatusCode errorCode);

        public abstract void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadStatusCode status, MusicContentCenterStatusCode errorCode);
#endregion terra IMusicContentCenterEventHandler
    }
}