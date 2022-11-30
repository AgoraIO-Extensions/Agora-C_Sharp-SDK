using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMusicContentCenterEventHandler : IMusicContentCenterEventHandler
    {
        public override void OnLyricResult(string requestId, string lyricUrl)
        {
            throw new NotImplementedException();
        }

        public override void OnMusicChartsResult(string requestId, MusicContentCenterStatusCode status, MusicChartInfo[] result)
        {
            throw new NotImplementedException();
        }

        public override void OnMusicCollectionResult(string requestId, MusicContentCenterStatusCode status, MusicCollection result)
        {
            throw new NotImplementedException();
        }

        public override void OnPreLoadEvent(long songCode, int percent, PreloadStatusCode status, string msg, string lyricUrl)
        {
            throw new NotImplementedException();
        }
    }
}
