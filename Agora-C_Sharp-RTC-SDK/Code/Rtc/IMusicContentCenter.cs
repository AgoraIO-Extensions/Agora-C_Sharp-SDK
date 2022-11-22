using System;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMusicContentCenter
    {
        ///
        /// @ignore
        ///
        public abstract int Initialize(MusicContentCenterConfiguration configuration);

        ///
        /// @ignore
        ///
        public abstract int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler);

        ///
        /// @ignore
        ///
        public abstract int UnregisterEventHandler();

        ///
        /// @ignore
        ///
        public abstract IMusicPlayer CreateMusicPlayer();

        ///
        /// @ignore
        ///
        public abstract int DestroyMusicPlayer(IMusicPlayer player);

        ///
        /// @ignore
        ///
        public abstract int GetMusicCharts(ref string requestId);

        ///
        /// @ignore
        ///
        public abstract int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartType, int page, int pageSize, string jsonOption = "");

        ///
        /// @ignore
        ///
        public abstract int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "");

        ///
        /// @ignore
        ///
        public abstract int Preload(Int64 songCode, string jsonOption = "");

        ///
        /// @ignore
        ///
        public abstract int IsPreloaded(Int64 songCode);

        ///
        /// @ignore
        ///
        public abstract int GetLyric(ref string requestId, Int64 songCode, int LyricType = 0);

        ///
        /// @ignore
        ///
        public abstract int RenewToken(string token);
    }
}