using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMusicContentCenterEventHandler : IMusicContentCenterEventHandler
    {


        public bool OnMusicChartsResult_be_trigger = false;
        public string OnMusicChartsResult_requestId = null;
        public MusicChartInfo[] OnMusicChartsResult_result = null;
        public MusicContentCenterStatusCode OnMusicChartsResult_error_code;

        public override void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode error_code)
        {
            OnMusicChartsResult_be_trigger = true;
            OnMusicChartsResult_requestId = requestId;
            OnMusicChartsResult_result = result;
            OnMusicChartsResult_error_code = error_code;
        }

        public bool OnMusicChartsResultPassed(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode error_code)
        {
            if (OnMusicChartsResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnMusicChartsResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareMusicChartInfoArray(OnMusicChartsResult_result, result) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnMusicChartsResult_error_code, error_code) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnMusicCollectionResult_be_trigger = false;
        public string OnMusicCollectionResult_requestId = null;
        public MusicCollection OnMusicCollectionResult_result = null;
        public MusicContentCenterStatusCode OnMusicCollectionResult_error_code;

        public override void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStatusCode error_code)
        {
            OnMusicCollectionResult_be_trigger = true;
            OnMusicCollectionResult_requestId = requestId;
            OnMusicCollectionResult_result = result;
            OnMusicCollectionResult_error_code = error_code;
        }

        public bool OnMusicCollectionResultPassed(string requestId, MusicCollection result, MusicContentCenterStatusCode error_code)
        {
            if (OnMusicCollectionResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnMusicCollectionResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareMusicCollection(OnMusicCollectionResult_result, result) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnMusicCollectionResult_error_code, error_code) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLyricResult_be_trigger = false;
        public string OnLyricResult_requestId = null;
        public string OnLyricResult_lyricUrl = null;
        public MusicContentCenterStatusCode OnLyricResult_error_code;

        public override void OnLyricResult(string requestId, string lyricUrl, MusicContentCenterStatusCode error_code)
        {
            OnLyricResult_be_trigger = true;
            OnLyricResult_requestId = requestId;
            OnLyricResult_lyricUrl = lyricUrl;
            OnLyricResult_error_code = error_code;
        }

        public bool OnLyricResultPassed(string requestId, string lyricUrl, MusicContentCenterStatusCode error_code)
        {
            if (OnLyricResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnLyricResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareString(OnLyricResult_lyricUrl, lyricUrl) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnLyricResult_error_code, error_code) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPreLoadEvent_be_trigger = false;
        public long OnPreLoadEvent_songCode = 0;
        public int OnPreLoadEvent_percent = 0;
        public string OnPreLoadEvent_lyricUrl = null;
        public PreloadStatusCode OnPreLoadEvent_status;
        public MusicContentCenterStatusCode OnPreLoadEvent_error_code;

        public override void OnPreLoadEvent(long songCode, int percent, string lyricUrl, PreloadStatusCode status, MusicContentCenterStatusCode error_code)
        {
            OnPreLoadEvent_be_trigger = true;
            OnPreLoadEvent_songCode = songCode;
            OnPreLoadEvent_percent = percent;
            OnPreLoadEvent_lyricUrl = lyricUrl;
            OnPreLoadEvent_status = status;
            OnPreLoadEvent_error_code = error_code;
        }

        public bool OnPreLoadEventPassed(long songCode, int percent, string lyricUrl, PreloadStatusCode status, MusicContentCenterStatusCode error_code)
        {
            if (OnPreLoadEvent_be_trigger == false)
                return false;

            if (ParamsHelper.compareLong(OnPreLoadEvent_songCode, songCode) == false)
                return false;
            if (ParamsHelper.compareInt(OnPreLoadEvent_percent, percent) == false)
                return false;
            if (ParamsHelper.compareString(OnPreLoadEvent_lyricUrl, lyricUrl) == false)
                return false;
            if (ParamsHelper.comparePreloadStatusCode(OnPreLoadEvent_status, status) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnPreLoadEvent_error_code, error_code) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
