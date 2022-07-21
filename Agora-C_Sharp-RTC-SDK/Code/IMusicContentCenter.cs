using System;
namespace Agora.Rtc
{
    public abstract class IMusicContentCenter
    {
        public abstract int Initialize(AgoraMusicContentCenterConfiguration configuration);

        public abstract int RegisterEventHandler(IAgoraMusicContentCenterEventHandler eventHandler);

        public abstract int UnregisterEventHandler();

        public abstract IMusicPlayer CreateMusicPlayer();

        public abstract int DestroyMusicPlayer(IMusicPlayer player);

        public abstract int GetMusicCharts(ref string requestId);

        public abstract int GetMusicChart(ref string requestId, int musicChartType, int page, int pageSize, string jsonOption = "");

        public abstract int SearchSong(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "");

        public abstract int Preload(Int64 songCode, AgoraMediaType type, string resolution);

        public abstract int IsPreloaded(Int64 songCode, AgoraMediaType type, string resolution);

        public abstract int GetLyric(ref string requestId, Int64 songCode, int LyricType = 0);
    }
}
