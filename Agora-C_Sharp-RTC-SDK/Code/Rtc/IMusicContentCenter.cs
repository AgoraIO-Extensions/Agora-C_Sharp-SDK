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
        public abstract int DestroyMusicPlayer(IMusicPlayer player);

        #region terra IMusicContentCenter
        public abstract int Initialize(MusicContentCenterConfiguration configuration);

        public abstract int RenewToken(string token);

        public abstract int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler);

        public abstract int UnregisterEventHandler();

        public abstract IMusicPlayer CreateMusicPlayer();

        public abstract int GetMusicCharts(ref string requestId);

        public abstract int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "");

        public abstract int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "");

        [Obsolete("This method is deprecated. Use preload(int64_t songCode) instead.")]
        public abstract int Preload(long songCode, string jsonOption);

        public abstract int Preload(ref string requestId, long songCode);

        public abstract int RemoveCache(long songCode);

        public abstract int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize);

        public abstract int IsPreloaded(long songCode);

        public abstract int GetLyric(ref string requestId, long songCode, int LyricType = 0);

        public abstract int GetSongSimpleInfo(ref string requestId, long songCode);

        public abstract int GetInternalSongCode(long songCode, string jsonOption, ref long internalSongCode);
        #endregion terra IMusicContentCenter
    }
}