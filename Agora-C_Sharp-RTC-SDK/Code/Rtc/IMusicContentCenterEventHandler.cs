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
        public abstract void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStateReason reason);

        ///
        /// @ignore
        ///
        public abstract void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStateReason reason);

        ///
        /// @ignore
        ///
        public abstract void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadState state, MusicContentCenterStateReason reason);
        #endregion terra IMusicContentCenterEventHandler
    }
}