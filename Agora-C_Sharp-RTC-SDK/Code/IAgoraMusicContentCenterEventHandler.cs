using System;
namespace Agora.Rtc
{
    public abstract class IAgoraMusicContentCenterEventHandler
    {
        public abstract void OnMusicChartsTypeResult(string requestId, CopyRightMusicStatusCode status, MusicChartsResult result);

        public abstract void OnSongListResult(string requestId, CopyRightMusicStatusCode status, MusicListResult result);

        public abstract void OnLyricResult(string requestId, string lyricUrl);
    
        public abstract void OnPreLoadEvent(Int64 songCode, int percent, PreloadStatusCode status, string msg, string lyricUrl);
    }
}
