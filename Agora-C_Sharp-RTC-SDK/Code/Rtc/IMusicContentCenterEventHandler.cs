using System;

namespace Agora.Rtc
{
    public abstract class IMusicContentCenterEventHandler
    {
        public abstract void OnMusicChartsResult(string requestId, MusicContentCenterStatusCode status, MusicChartInfo[] result);

        public abstract void OnMusicCollectionResult(string requestId, MusicContentCenterStatusCode status, MusicCollection result);

        public abstract void OnLyricResult(string requestId, string lyricUrl);
    
        public abstract void OnPreLoadEvent(Int64 songCode, int percent, PreloadStatusCode status, string msg, string lyricUrl);
    }
}