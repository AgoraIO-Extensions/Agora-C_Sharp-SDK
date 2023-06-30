using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMusicContentCenterEventHandler : IMusicContentCenterEventHandler
    {


        public bool OnMusicChartsResult_be_trigger = false;
        public string OnMusicChartsResult_requestId = null;
        public MusicChartInfo[] OnMusicChartsResult_result = null;
        public MusicContentCenterStatusCode OnMusicChartsResult_errorCode = MusicContentCenterStatusCode.kMusicContentCenterStatusErr;

        public override void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode errorCode)
        {
            OnMusicChartsResult_be_trigger = true;
            OnMusicChartsResult_requestId = requestId;
            OnMusicChartsResult_result = result;
            OnMusicChartsResult_errorCode = errorCode;
        }

        public bool OnMusicChartsResultPassed(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode errorCode)
        {
            if (OnMusicChartsResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnMusicChartsResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareMusicChartInfoArray(OnMusicChartsResult_result, result) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnMusicChartsResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnMusicCollectionResult_be_trigger = false;
        public string OnMusicCollectionResult_requestId = null;
        public MusicCollection OnMusicCollectionResult_result = null;
        public MusicContentCenterStatusCode OnMusicCollectionResult_errorCode = MusicContentCenterStatusCode.kMusicContentCenterStatusErr;

        public override void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStatusCode errorCode)
        {
            OnMusicCollectionResult_be_trigger = true;
            OnMusicCollectionResult_requestId = requestId;
            OnMusicCollectionResult_result = result;
            OnMusicCollectionResult_errorCode = errorCode;
        }

        public bool OnMusicCollectionResultPassed(string requestId, MusicCollection result, MusicContentCenterStatusCode errorCode)
        {
            if (OnMusicCollectionResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnMusicCollectionResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareMusicCollection(OnMusicCollectionResult_result, result) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnMusicCollectionResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLyricResult_be_trigger = false;
        public string OnLyricResult_requestId = null;
        public long OnLyricResult_songCode = 0;
        public string OnLyricResult_lyricUrl = null;
        public MusicContentCenterStatusCode OnLyricResult_errorCode = MusicContentCenterStatusCode.kMusicContentCenterStatusErr;

        public override void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStatusCode errorCode)
        {
            OnLyricResult_be_trigger = true;
            OnLyricResult_requestId = requestId;
            OnLyricResult_songCode = songCode;
            OnLyricResult_lyricUrl = lyricUrl;
            OnLyricResult_errorCode = errorCode;
        }

        public bool OnLyricResultPassed(string requestId, long songCode, string lyricUrl, MusicContentCenterStatusCode errorCode)
        {
            if (OnLyricResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnLyricResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareLong(OnLyricResult_songCode, songCode) == false)
                return false;
            if (ParamsHelper.compareString(OnLyricResult_lyricUrl, lyricUrl) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnLyricResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnSongSimpleInfoResult_be_trigger = false;
        public string OnSongSimpleInfoResult_requestId = null;
        public long OnSongSimpleInfoResult_songCode = 0;
        public string OnSongSimpleInfoResult_simpleInfo = null;
        public MusicContentCenterStatusCode OnSongSimpleInfoResult_errorCode = MusicContentCenterStatusCode.kMusicContentCenterStatusErr;

        public override void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStatusCode errorCode)
        {
            OnSongSimpleInfoResult_be_trigger = true;
            OnSongSimpleInfoResult_requestId = requestId;
            OnSongSimpleInfoResult_songCode = songCode;
            OnSongSimpleInfoResult_simpleInfo = simpleInfo;
            OnSongSimpleInfoResult_errorCode = errorCode;
        }

        public bool OnSongSimpleInfoResultPassed(string requestId, long songCode, string simpleInfo, MusicContentCenterStatusCode errorCode)
        {
            if (OnSongSimpleInfoResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnSongSimpleInfoResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareLong(OnSongSimpleInfoResult_songCode, songCode) == false)
                return false;
            if (ParamsHelper.compareString(OnSongSimpleInfoResult_simpleInfo, simpleInfo) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnSongSimpleInfoResult_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPreLoadEvent_be_trigger = false;
        public string OnPreLoadEvent_requestId = null;
        public long OnPreLoadEvent_songCode = 0;
        public int OnPreLoadEvent_percent = 0;
        public string OnPreLoadEvent_lyricUrl = null;
        public PreloadStatusCode OnPreLoadEvent_status = PreloadStatusCode.kPreloadStatusCompleted;
        public MusicContentCenterStatusCode OnPreLoadEvent_errorCode = MusicContentCenterStatusCode.kMusicContentCenterStatusErr;

        public override void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadStatusCode status, MusicContentCenterStatusCode errorCode)
        {
            OnPreLoadEvent_be_trigger = true;
            OnPreLoadEvent_requestId = requestId;
            OnPreLoadEvent_songCode = songCode;
            OnPreLoadEvent_percent = percent;
            OnPreLoadEvent_lyricUrl = lyricUrl;
            OnPreLoadEvent_status = status;
            OnPreLoadEvent_errorCode = errorCode;
        }

        public bool OnPreLoadEventPassed(string requestId, long songCode, int percent, string lyricUrl, PreloadStatusCode status, MusicContentCenterStatusCode errorCode)
        {
            if (OnPreLoadEvent_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnPreLoadEvent_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareLong(OnPreLoadEvent_songCode, songCode) == false)
                return false;
            if (ParamsHelper.compareInt(OnPreLoadEvent_percent, percent) == false)
                return false;
            if (ParamsHelper.compareString(OnPreLoadEvent_lyricUrl, lyricUrl) == false)
                return false;
            if (ParamsHelper.comparePreloadStatusCode(OnPreLoadEvent_status, status) == false)
                return false;
            if (ParamsHelper.compareMusicContentCenterStatusCode(OnPreLoadEvent_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
