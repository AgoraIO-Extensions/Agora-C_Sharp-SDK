using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// IMusicContentCenterEventHandler 接口类，用于 SDK 向客户端发送音乐内容中心事件通知。
    /// </summary>
    ///
    public abstract class IMusicContentCenterEventHandler
    {
        ///
        /// @ignore
        ///
        public abstract void OnMusicChartsResult(string requestId, MusicContentCenterStatusCode status, MusicChartInfo[] result);

        ///
        /// @ignore
        ///
        public abstract void OnMusicCollectionResult(string requestId, MusicContentCenterStatusCode status, MusicCollection result);

        ///
        /// @ignore
        ///
        public abstract void OnLyricResult(string requestId, string lyricUrl);
    
        ///
        /// @ignore
        ///
        public abstract void OnPreLoadEvent(Int64 songCode, int percent, PreloadStatusCode status, string msg, string lyricUrl);
    }
}