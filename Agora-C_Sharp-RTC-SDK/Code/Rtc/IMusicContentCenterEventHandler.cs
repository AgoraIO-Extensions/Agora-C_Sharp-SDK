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
        ///
        /// @ignore
        ///
        public abstract void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStateReason reason);

        ///
        /// @ignore
        ///
        public abstract void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStateReason reason);

        ///
        /// @ignore
        ///
        public abstract void OnLyricResult(string requestId, long internalSongCode, string payload, MusicContentCenterStateReason reason);

        ///
        /// @ignore
        ///
        public abstract void OnLyricInfoResult(string requestId, long songCode, ILyricInfo lyricInfo, MusicContentCenterStateReason reason);

        ///
        /// @ignore
        ///
        public abstract void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStateReason reason);

        ///
        /// @ignore
        ///
        public abstract void OnPreLoadEvent(string requestId, long internalSongCode, int percent, string payload, MusicContentCenterState status, MusicContentCenterStateReason reason);

        ///
        /// @ignore
        ///
        public abstract void OnStartScoreResult(long internalSongCode, MusicContentCenterState status, MusicContentCenterStateReason reason);
        #endregion terra IMusicContentCenterEventHandler
    }
}