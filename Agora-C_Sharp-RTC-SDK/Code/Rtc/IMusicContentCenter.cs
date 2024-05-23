using System;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMusicContentCenter
    {
        #region terra IMusicContentCenter
        ///
        /// @ignore
        ///
        public abstract int Initialize(MusicContentCenterConfiguration configuration);

        ///
        /// @ignore
        ///
        public abstract int RenewToken(string token);

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
        public abstract int DestroyMusicPlayer(IMusicPlayer music_player);

        ///
        /// @ignore
        ///
        public abstract int GetMusicCharts(ref string requestId);

        ///
        /// @ignore
        ///
        public abstract int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "");

        ///
        /// @ignore
        ///
        public abstract int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "");

        ///
        /// @ignore
        ///
        [Obsolete("This method is deprecated. Use preload(int64_t songCode) instead.")]
        public abstract int Preload(long songCode, string jsonOption);

        ///
        /// @ignore
        ///
        public abstract int Preload(ref string requestId, long songCode);

        ///
        /// @ignore
        ///
        public abstract int RemoveCache(long songCode);

        ///
        /// @ignore
        ///
        public abstract int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize);

        ///
        /// @ignore
        ///
        public abstract int IsPreloaded(long songCode);

        ///
        /// @ignore
        ///
        public abstract int GetLyric(ref string requestId, long songCode, int lyricType = 0);

        ///
        /// @ignore
        ///
        public abstract int GetSongSimpleInfo(ref string requestId, long songCode);

        ///
        /// @ignore
        ///
        public abstract int GetInternalSongCode(long songCode, string jsonOption, ref long internalSongCode);
        #endregion terra IMusicContentCenter
    }
}