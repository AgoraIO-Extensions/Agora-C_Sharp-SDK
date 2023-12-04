using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMusicContentCenterEventHandler : IMusicContentCenterEventHandler
    {

        #region terra IMusicContentCenterEventHandler
        public bool OnMusicChartsResult_be_trigger = false;
        public string OnMusicChartsResult_requestId;
        public MusicChartInfo[] OnMusicChartsResult_result;
        public MusicContentCenterStatusCode OnMusicChartsResult_status;

        public override void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode status)
        {
            OnMusicChartsResult_be_trigger = true;
            OnMusicChartsResult_requestId = requestId;
            OnMusicChartsResult_result = result;
            OnMusicChartsResult_status = status;

        }

        public bool OnMusicChartsResultPassed(string requestId, MusicChartInfo[] result, MusicContentCenterStatusCode status)
        {

            if (OnMusicChartsResult_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnMusicChartsResult_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicChartInfo[]>(OnMusicChartsResult_result, result) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStatusCode>(OnMusicChartsResult_status, status) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnMusicCollectionResult_be_trigger = false;
        public string OnMusicCollectionResult_requestId;
        public MusicCollection OnMusicCollectionResult_result;
        public MusicContentCenterStatusCode OnMusicCollectionResult_status;

        public override void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStatusCode status)
        {
            OnMusicCollectionResult_be_trigger = true;
            OnMusicCollectionResult_requestId = requestId;
            OnMusicCollectionResult_result = result;
            OnMusicCollectionResult_status = status;

        }

        public bool OnMusicCollectionResultPassed(string requestId, MusicCollection result, MusicContentCenterStatusCode status)
        {

            if (OnMusicCollectionResult_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnMusicCollectionResult_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicCollection>(OnMusicCollectionResult_result, result) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStatusCode>(OnMusicCollectionResult_status, status) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnLyricResult_be_trigger = false;
        public string OnLyricResult_requestId;
        public long OnLyricResult_songCode;
        public string OnLyricResult_lyricUrl;
        public MusicContentCenterStatusCode OnLyricResult_status;

        public override void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStatusCode status)
        {
            OnLyricResult_be_trigger = true;
            OnLyricResult_requestId = requestId;
            OnLyricResult_songCode = songCode;
            OnLyricResult_lyricUrl = lyricUrl;
            OnLyricResult_status = status;

        }

        public bool OnLyricResultPassed(string requestId, long songCode, string lyricUrl, MusicContentCenterStatusCode status)
        {

            if (OnLyricResult_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnLyricResult_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<long>(OnLyricResult_songCode, songCode) == false)
            //return false;
            // if (ParamsHelper.Compare<string>(OnLyricResult_lyricUrl, lyricUrl) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStatusCode>(OnLyricResult_status, status) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnSongSimpleInfoResult_be_trigger = false;
        public string OnSongSimpleInfoResult_requestId;
        public long OnSongSimpleInfoResult_songCode;
        public string OnSongSimpleInfoResult_simpleInfo;
        public MusicContentCenterStatusCode OnSongSimpleInfoResult_status;

        public override void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStatusCode status)
        {
            OnSongSimpleInfoResult_be_trigger = true;
            OnSongSimpleInfoResult_requestId = requestId;
            OnSongSimpleInfoResult_songCode = songCode;
            OnSongSimpleInfoResult_simpleInfo = simpleInfo;
            OnSongSimpleInfoResult_status = status;

        }

        public bool OnSongSimpleInfoResultPassed(string requestId, long songCode, string simpleInfo, MusicContentCenterStatusCode status)
        {

            if (OnSongSimpleInfoResult_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnSongSimpleInfoResult_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<long>(OnSongSimpleInfoResult_songCode, songCode) == false)
            //return false;
            // if (ParamsHelper.Compare<string>(OnSongSimpleInfoResult_simpleInfo, simpleInfo) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStatusCode>(OnSongSimpleInfoResult_status, status) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnPreLoadEvent_be_trigger = false;
        public string OnPreLoadEvent_requestId;
        public long OnPreLoadEvent_songCode;
        public int OnPreLoadEvent_percent;
        public string OnPreLoadEvent_lyricUrl;
        public PreloadStatusCode OnPreLoadEvent_preloadStatus;
        public MusicContentCenterStatusCode OnPreLoadEvent_mccStatus;

        public override void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadStatusCode preloadStatus, MusicContentCenterStatusCode mccStatus)
        {
            OnPreLoadEvent_be_trigger = true;
            OnPreLoadEvent_requestId = requestId;
            OnPreLoadEvent_songCode = songCode;
            OnPreLoadEvent_percent = percent;
            OnPreLoadEvent_lyricUrl = lyricUrl;
            OnPreLoadEvent_preloadStatus = preloadStatus;
            OnPreLoadEvent_mccStatus = mccStatus;

        }

        public bool OnPreLoadEventPassed(string requestId, long songCode, int percent, string lyricUrl, PreloadStatusCode preloadStatus, MusicContentCenterStatusCode mccStatus)
        {

            if (OnPreLoadEvent_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnPreLoadEvent_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<long>(OnPreLoadEvent_songCode, songCode) == false)
            //return false;
            // if (ParamsHelper.Compare<int>(OnPreLoadEvent_percent, percent) == false)
            //return false;
            // if (ParamsHelper.Compare<string>(OnPreLoadEvent_lyricUrl, lyricUrl) == false)
            //return false;
            // if (ParamsHelper.Compare<PreloadStatusCode>(OnPreLoadEvent_preloadStatus, preloadStatus) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStatusCode>(OnPreLoadEvent_mccStatus, mccStatus) == false)
            //return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IMusicContentCenterEventHandler
    }
}
