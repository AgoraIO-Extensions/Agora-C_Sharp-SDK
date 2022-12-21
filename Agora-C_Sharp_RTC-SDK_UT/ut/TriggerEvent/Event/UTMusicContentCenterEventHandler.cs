using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMusicContentCenterEventHandler : IMusicContentCenterEventHandler
    {


        public bool OnMusicChartsResult_be_trigger = false;
        public string OnMusicChartsResult_requestId = null;
        public MusicContentCenterStatusCode OnMusicChartsResult_status;
        public MusicChartInfo[] OnMusicChartsResult_result = null;

        public override void OnMusicChartsResult(string requestId, MusicContentCenterStatusCode status, MusicChartInfo[] result)
        {
            OnMusicChartsResult_be_trigger = true;
            OnMusicChartsResult_requestId = requestId;
            OnMusicChartsResult_status = status;
            OnMusicChartsResult_result = result;
        }

        public bool OnMusicChartsResultPassed(string requestId, MusicContentCenterStatusCode status, MusicChartInfo[] result)
        {
            if (OnMusicChartsResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnMusicChartsResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnMusicChartsResult_status, status) == false)
                return false;
            if (ParamsHelper.compareMusicChartInfoArray(OnMusicChartsResult_result, result) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnMusicCollectionResult_be_trigger = false;
        public string OnMusicCollectionResult_requestId = null;
        public MusicContentCenterStatusCode OnMusicCollectionResult_status;
        public MusicCollection OnMusicCollectionResult_result = null;

        public override void OnMusicCollectionResult(string requestId, MusicContentCenterStatusCode status, MusicCollection result)
        {
            OnMusicCollectionResult_be_trigger = true;
            OnMusicCollectionResult_requestId = requestId;
            OnMusicCollectionResult_status = status;
            OnMusicCollectionResult_result = result;
        }

        public bool OnMusicCollectionResultPassed(string requestId, MusicContentCenterStatusCode status, MusicCollection result)
        {
            if (OnMusicCollectionResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnMusicCollectionResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnMusicCollectionResult_status, status) == false)
                return false;
            if (ParamsHelper.compareMusicCollection(OnMusicCollectionResult_result, result) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLyricResult_be_trigger = false;
        public string OnLyricResult_requestId = null;
        public string OnLyricResult_lyricUrl = null;

        public override void OnLyricResult(string requestId, string lyricUrl)
        {
            OnLyricResult_be_trigger = true;
            OnLyricResult_requestId = requestId;
            OnLyricResult_lyricUrl = lyricUrl;
        }

        public bool OnLyricResultPassed(string requestId, string lyricUrl)
        {
            if (OnLyricResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnLyricResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnLyricResult_lyricUrl, lyricUrl) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPreLoadEvent_be_trigger = false;
        public long OnPreLoadEvent_songCode = 0;
        public int OnPreLoadEvent_percent = 0;
        public PreloadStatusCode OnPreLoadEvent_status;
        public string OnPreLoadEvent_msg = null;
        public string OnPreLoadEvent_lyricUrl = null;

        public override void OnPreLoadEvent(long songCode, int percent, PreloadStatusCode status, string msg, string lyricUrl)
        {
            OnPreLoadEvent_be_trigger = true;
            OnPreLoadEvent_songCode = songCode;
            OnPreLoadEvent_percent = percent;
            OnPreLoadEvent_status = status;
            OnPreLoadEvent_msg = msg;
            OnPreLoadEvent_lyricUrl = lyricUrl;
        }

        public bool OnPreLoadEventPassed(long songCode, int percent, PreloadStatusCode status, string msg, string lyricUrl)
        {
            if (OnPreLoadEvent_be_trigger == false)
                return false;

            if (ParamsHelper.compareLong(OnPreLoadEvent_songCode, songCode) == false)
                return false;
            if (ParamsHelper.compareInt(OnPreLoadEvent_percent, percent) == false)
                return false;
            if (ParamsHelper.comparePreloadStatusCode(OnPreLoadEvent_status, status) == false)
                return false;
            if (ParamsHelper.compareString(OnPreLoadEvent_msg, msg) == false)
                return false;
            if (ParamsHelper.compareString(OnPreLoadEvent_lyricUrl, lyricUrl) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
