using System;

namespace Agora.Rtc
{
    /* class_imusiccontentcenter */
    public abstract class IMusicContentCenter
    {

        /* api_imusiccontentcenter_destroymusicplayer */
        public abstract int DestroyMusicPlayer(IMusicPlayer player);

#region terra IMusicContentCenter

        /* api_imusiccontentcenter_initialize */
        public abstract int Initialize(MusicContentCenterConfiguration configuration);

        /* api_imusiccontentcenter_renewtoken */
        public abstract int RenewToken(string token);

        /* api_imusiccontentcenter_registereventhandler */
        public abstract int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler);

        /* api_imusiccontentcenter_unregistereventhandler */
        public abstract int UnregisterEventHandler();

        /* api_imusiccontentcenter_createmusicplayer */
        public abstract IMusicPlayer CreateMusicPlayer();

        /* api_imusiccontentcenter_getmusiccharts */
        public abstract int GetMusicCharts(ref string requestId);

        /* api_imusiccontentcenter_getmusiccollectionbymusicchartid */
        public abstract int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "");

        /* api_imusiccontentcenter_searchmusic */
        public abstract int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "");

        /* api_imusiccontentcenter_preload */
        [Obsolete("This method is deprecated. Use preload(int64_t songCode) instead.")]
        public abstract int Preload(long songCode, string jsonOption);

        /* api_imusiccontentcenter_preload2 */
        public abstract int Preload(ref string requestId, long songCode);

        /* api_imusiccontentcenter_removecache */
        public abstract int RemoveCache(long songCode);

        /* api_imusiccontentcenter_getcaches */
        public abstract int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize);

        /* api_imusiccontentcenter_ispreloaded */
        public abstract int IsPreloaded(long songCode);

        /* api_imusiccontentcenter_getlyric */
        public abstract int GetLyric(ref string requestId, long songCode, int LyricType = 0);

        /* api_imusiccontentcenter_getsongsimpleinfo */
        public abstract int GetSongSimpleInfo(ref string requestId, long songCode);

        /* api_imusiccontentcenter_getinternalsongcode */
        public abstract int GetInternalSongCode(long songCode, string jsonOption, ref long internalSongCode);
#endregion terra IMusicContentCenter
    }
}