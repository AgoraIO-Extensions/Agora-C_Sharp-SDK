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
        public abstract int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// @ignore
        ///
        public abstract int UnregisterAudioFrameObserver();

        #region terra IMusicContentCenter
        ///
        /// @ignore
        ///
        public abstract int Initialize(MusicContentCenterConfiguration configuration);

        ///
        /// @ignore
        ///
        public abstract int AddVendor(MusicContentCenterVendorID vendorId, string jsonVendorConfig);

        ///
        /// @ignore
        ///
        public abstract int RemoveVendor(MusicContentCenterVendorID vendorId);

        ///
        /// @ignore
        ///
        public abstract int RenewToken(MusicContentCenterVendorID vendorID, string token);

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
        public abstract int Preload(ref string requestId, long internalSongCode);

        ///
        /// @ignore
        ///
        public abstract int RegisterScoreEventHandler(IScoreEventHandler scoreEventHandler);

        ///
        /// @ignore
        ///
        public abstract int UnregisterScoreEventHandler();

        ///
        /// @ignore
        ///
        public abstract int SetScoreLevel(ScoreLevel level);

        ///
        /// @ignore
        ///
        public abstract int StartScore(long internalSongCode);

        ///
        /// @ignore
        ///
        public abstract int StopScore();

        ///
        /// @ignore
        ///
        public abstract int PauseScore();

        ///
        /// @ignore
        ///
        public abstract int ResumeScore();

        ///
        /// @ignore
        ///
        public abstract int GetCumulativeScoreData(ref CumulativeScoreData cumulativeScoreData);

        ///
        /// @ignore
        ///
        public abstract int RemoveCache(long internalSongCode);

        ///
        /// @ignore
        ///
        public abstract int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize);

        ///
        /// @ignore
        ///
        public abstract int IsPreloaded(long internalSongCode);

        ///
        /// @ignore
        ///
        public abstract int GetLyric(ref string requestId, long internalSongCode, int lyricType = 0);

        ///
        /// @ignore
        ///
        public abstract int GetLyricInfo(ref string requestId, long internalSongCode);

        ///
        /// @ignore
        ///
        public abstract int GetSongSimpleInfo(ref string requestId, long internalSongCode);

        ///
        /// @ignore
        ///
        public abstract int GetInternalSongCode(MusicContentCenterVendorID vendorId, string songCode, string jsonOption, ref long internalSongCode);
        #endregion terra IMusicContentCenter
    }
}